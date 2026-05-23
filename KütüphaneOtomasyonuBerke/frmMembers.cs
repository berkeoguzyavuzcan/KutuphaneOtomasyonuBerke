using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmMembers : Form
    {
        int _selectedUserId;

        public frmMembers()
        {
            InitializeComponent();
        }

        private void BringAndSearchMemberDatas()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                string query = @"SELECT au.UserId, au.FirstName, au.LastName, 
                                STRING_AGG(ar.RoleName, ', ') as Roles, 
                                au.IdentityNumber, au.BirthDate, au.CreatedDate 
                         FROM AppUsers au 
                         LEFT JOIN UserRoles ur ON au.UserId = ur.UserId 
                         LEFT JOIN AppRoles ar ON ur.RoleId = ar.RoleId 
                         WHERE (au.Status = 1 OR au.Status IS NULL) 
                         GROUP BY au.UserId, au.FirstName, au.LastName, au.IdentityNumber, au.BirthDate, au.CreatedDate 
                         HAVING (au.FirstName + ' ' + au.LastName LIKE @memberName) 
                            OR (au.IdentityNumber LIKE @identityNumber)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@memberName", '%' + tbxMember.Text + '%');
                    cmd.Parameters.AddWithValue("@identityNumber", '%' + tbxMember.Text + '%');

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dgwMembers.DataSource = dt;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // --- 1. KORUMA KALKANI: BOŞ ALAN KONTROLÜ ---
            if (string.IsNullOrWhiteSpace(tbxFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbxLastName.Text) ||
                string.IsNullOrWhiteSpace(tbxIdentityNumber.Text))
            {
                MessageBox.Show("Ad, Soyad ve TC Kimlik numarası boş bırakılamaz!", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Hata varsa kodu burada kes, aşağıya inme
            }


            if (tbxIdentityNumber.Text.Length != 11 || !long.TryParse(tbxIdentityNumber.Text, out _))
            {
                MessageBox.Show("TC Kimlik Numarası tam 11 haneli olmalı ve sadece rakamlardan oluşmalıdır!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((chkAdmin.Checked || chkSuperAdmin.Checked) &&
                (string.IsNullOrWhiteSpace(tbxUserName.Text) || string.IsNullOrWhiteSpace(tbxPassword.Text)))
            {
                MessageBox.Show("Yönetici yetkisi veriyorsanız Kullanıcı Adı ve Şifre boş bırakılamaz!", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkSuperAdmin.Checked && Session.ActiveRoleId != 1)
            {
                MessageBox.Show("Yetkiniz yönetici eklemek için yetersiz!", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string queryForUser = @"INSERT INTO AppUsers (FirstName, LastName, IdentityNumber, Username, Password, BirthDate, Gender) 
                                   VALUES (@firstName, @lastName, @identityNumber, @userName, @password, @birthDate, @gender); 
                                   SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmdForUser = new SqlCommand(queryForUser, conn, transaction))
                    {
                        cmdForUser.Parameters.AddWithValue("@firstName", tbxFirstName.Text);
                        cmdForUser.Parameters.AddWithValue("@lastName", tbxLastName.Text);
                        cmdForUser.Parameters.AddWithValue("@identityNumber", tbxIdentityNumber.Text);
                        cmdForUser.Parameters.AddWithValue("@userName", tbxUserName.Text);
                        cmdForUser.Parameters.AddWithValue("@password", tbxPassword.Text);
                        cmdForUser.Parameters.AddWithValue("@birthDate", dtpBirthDate.Value);
                        cmdForUser.Parameters.AddWithValue("@gender", rbMan.Checked);

                        int insertedUserId = Convert.ToInt32(cmdForUser.ExecuteScalar());

                        if (chkMember.Checked) AssignRoleToUser(conn, transaction, insertedUserId, 3);
                        if (chkAdmin.Checked) AssignRoleToUser(conn, transaction, insertedUserId, 2);
                        if (chkSuperAdmin.Checked) AssignRoleToUser(conn, transaction, insertedUserId, 1);

                        transaction.Commit();
                        MessageBox.Show("Üye başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BringAndSearchMemberDatas();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Kayıt sırasında bir SQL hatası oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AssignRoleToUser(SqlConnection conn, SqlTransaction transaction, int insertedUserId, int roleId)
        {
            string queryForRole = "INSERT INTO UserRoles (RoleId, UserId) VALUES (@roleId, @userId)";
            using (SqlCommand cmdForRole = new SqlCommand(queryForRole, conn, transaction))
            {
                cmdForRole.Parameters.AddWithValue("@roleId", roleId);
                cmdForRole.Parameters.AddWithValue("@userId", insertedUserId);
                cmdForRole.ExecuteNonQuery();
            }
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            dgwMembers.ReadOnly = true;
            dgwMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwMembers.AllowUserToAddRows = false;
            tbxIdentityNumber.MaxLength = 11;

            ChangePassive();
            BringAndSearchMemberDatas();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId > 0)
            {
                frmUpdateMembers frm = new frmUpdateMembers(_selectedUserId);
                frm.ShowDialog();
                BringAndSearchMemberDatas();
            }
            else MessageBox.Show("Lütfen bir satır seçin.");
        }

        private void dgwMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwMembers.Rows[e.RowIndex];
                if (row.Cells["UserId"].Value != DBNull.Value)
                {
                    _selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);

                    tbxUpdateName.Text = row.Cells["FirstName"].Value?.ToString();
                    tbxUpdateLastName.Text = row.Cells["LastName"].Value?.ToString();
                    tbxUpdateIdentity.Text = row.Cells["IdentityNumber"].Value?.ToString();
                    tbxUpdateRoles.Text = row.Cells["Roles"].Value?.ToString();

                    tbxUpdateName.Enabled = false;
                    tbxUpdateLastName.Enabled = false;
                    tbxUpdateIdentity.Enabled = false;
                    tbxUpdateRoles.Enabled = false;
                }
            }
        }

        void ChangePassive() { tbxUserName.Enabled = false; tbxPassword.Enabled = false; }
        private void chkAdmin_CheckedChanged(object sender, EventArgs e) { if (chkAdmin.Checked) { tbxUserName.Enabled = true; tbxPassword.Enabled = true; } else ChangePassive(); }
        private void chkSuperAdmin_CheckedChanged(object sender, EventArgs e) { if (chkSuperAdmin.Checked) { tbxUserName.Enabled = true; tbxPassword.Enabled = true; } else ChangePassive(); }
        private void tbxMember_TextChanged(object sender, EventArgs e) { BringAndSearchMemberDatas(); }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId > 0)
            {
                DialogResult result = MessageBox.Show("Bu üyeyi sildiğinizde, ona ait tüm ödünç kayıtları da işleme alınacaktır. Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = SqlCon.Connect())
                        {
                            conn.Open();
                            SqlTransaction transaction = conn.BeginTransaction();

                            try
                            {
                                // 1. Üyenin durumunu pasife al
                                string queryUser = "UPDATE AppUsers SET Status = 0 WHERE UserId = @id";
                                SqlCommand cmdUser = new SqlCommand(queryUser, conn, transaction);
                                cmdUser.Parameters.AddWithValue("@id", _selectedUserId);
                                cmdUser.ExecuteNonQuery();

                                // STOK DÜZELTMESİ: Üyenin elindeki tüm aktif kitapların stoğunu kütüphaneye geri yükle
                                string queryReturnStocks = @"UPDATE Books SET QuantityInStocks = QuantityInStocks + 1 
                                                             WHERE BookId IN (SELECT BookId FROM BookLoans WHERE UserId = @id AND Status = 1)";
                                SqlCommand cmdReturnStocks = new SqlCommand(queryReturnStocks, conn, transaction);
                                cmdReturnStocks.Parameters.AddWithValue("@id", _selectedUserId);
                                cmdReturnStocks.ExecuteNonQuery();

                                // 2. Üyeye ait aktif ödünçleri pasife al (Kapat)
                                string queryLoans = "UPDATE BookLoans SET Status = 0 WHERE UserId = @id AND Status = 1";
                                SqlCommand cmdLoans = new SqlCommand(queryLoans, conn, transaction);
                                cmdLoans.Parameters.AddWithValue("@id", _selectedUserId);
                                cmdLoans.ExecuteNonQuery();

                                transaction.Commit();
                                MessageBox.Show("Üye silindi, elindeki aktif kitaplar kütüphane stoğuna başarıyla geri iade edildi.");
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                        BringAndSearchMemberDatas();
                        _selectedUserId = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için önce listeden bir üye seçin.");
            }
        }

        private void btnÜyeGeri_Click(object sender, EventArgs e)
        {
            // RAM DOSTU GERİ DÖNÜŞ: Yeni form oluşturma, arkadaki gizli ana formu bul ve göster
            Form frmMainInstance = Application.OpenForms["frmMain"];
            if (frmMainInstance != null)
            {
                frmMainInstance.Show();
            }
            this.Close(); // Bu formu tamamen kapat, RAM'den temizlensin
        }
    }
}