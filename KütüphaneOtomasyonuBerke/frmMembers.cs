using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmMembers : Form
    {
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
                        if (chkSuperAdmin.Checked)
                        {
                            if (Session.ActiveRoleId != 1) MessageBox.Show("Yetkiniz yönetici eklemek için yetersiz!");
                            else AssignRoleToUser(conn, transaction, insertedUserId, 1);
                        }

                        transaction.Commit();
                        MessageBox.Show("Veriler Eklendi.");
                        BringAndSearchMemberDatas(); 
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Hata: " + ex.Message);
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
        private void btnÜyeGeri_Click(object sender, EventArgs e) { new frmMain().Show(); this.Close(); }
        private void tbxMember_TextChanged(object sender, EventArgs e) { BringAndSearchMemberDatas(); }
        int _selectedUserId;
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
                            SqlTransaction transaction = conn.BeginTransaction(); // İşlemleri tek seferde yapalım

                            try
                            {
                                // 1. Üyenin durumunu pasife al
                                string queryUser = "UPDATE AppUsers SET Status = 0 WHERE UserId = @id";
                                SqlCommand cmdUser = new SqlCommand(queryUser, conn, transaction);
                                cmdUser.Parameters.AddWithValue("@id", _selectedUserId);
                                cmdUser.ExecuteNonQuery();

                                // 2. ÖNEMLİ: Bu üyeye ait aktif ödünçleri de pasife al veya sil
                                // Eğer ödünç kayıtlarını da "kapalı" yapmak istiyorsan:
                                string queryLoans = "UPDATE BookLoans SET Status = 0 WHERE UserId = @id AND Status = 1";
                                SqlCommand cmdLoans = new SqlCommand(queryLoans, conn, transaction);
                                cmdLoans.Parameters.AddWithValue("@id", _selectedUserId);
                                cmdLoans.ExecuteNonQuery();

                                transaction.Commit(); // Her şey yolundaysa kaydet
                                MessageBox.Show("Üye ve tüm ödünç kayıtları pasife alındı.");
                            }
                            catch
                            {
                                transaction.Rollback(); // Hata olursa hiçbir şey yapma
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
        }
    }
}