using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmMembers : Form
    {
        // Sınıf Seviyesinde Değişken (Global Field):
        // DataGridView üzerinde seçilen üyenin ID'si, silme ve güncelleme operasyonlarında
        // hedef veriyi belirlemek amacıyla hafızada (RAM) tutulur.
        int _selectedUserId;

        public frmMembers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gelişmiş Dinamik Listeleme ve Arama Metodu:
        /// Üyeleri ad-soyad veya TC Kimlik numarasına göre arar, rollerini ilişkisel olarak birleştirir.
        /// </summary>
        private void BringAndSearchMemberDatas()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();

                // İleri Düzey İlişkisel SQL Sorgusu:
                // Bir üyenin birden fazla rolü (Üye, Admin, SuperAdmin) olabileceği için, 
                // SQL Server'ın 'STRING_AGG' fonksiyonu kullanılarak kullanıcının rolleri aralarında virgül olacak şekilde tek satırda birleştirilmiştir.
                // 'LEFT JOIN' yapıları sayesinde rolü henüz atanmamış kullanıcıların da listeden düşmesi engellenmiştir.
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
                    // SQL Injection Koruması: Kullanıcı girdileri sorguya parametrik olarak güvenli biçimde aktarılır.
                    cmd.Parameters.AddWithValue("@memberName", '%' + tbxMember.Text + '%');
                    cmd.Parameters.AddWithValue("@identityNumber", '%' + tbxMember.Text + '%');

                    // Bağlantısız Katman (Disconnected Layer) mimarisi ile DataGridView veri bağımlılığı (Data Binding) sağlanır.
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dgwMembers.DataSource = dt;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // --- 1. KORUMA KALKANI: UI SEVİYESİNDE BOŞ ALAN KONTROLÜ (VALIDATION) ---
            if (string.IsNullOrWhiteSpace(tbxFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbxLastName.Text) ||
                string.IsNullOrWhiteSpace(tbxIdentityNumber.Text))
            {
                MessageBox.Show("Ad, Soyad ve TC Kimlik numarası boş bırakılamaz!", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Algoritma kesilir, verimsiz sorguların veritabanına gitmesi engellenir.
            }

            // --- 2. KORUMA KALKANI: TİP VE UZUNLUK DOĞRULAMASI ---
            // T.C. Kimlik numarasının karakter uzunluğu (11 hane) ve 'long.TryParse' ile sadece sayısal karakterlerden oluştuğu doğrulanır.
            if (tbxIdentityNumber.Text.Length != 11 || !long.TryParse(tbxIdentityNumber.Text, out _))
            {
                MessageBox.Show("TC Kimlik Numarası tam 11 haneli olmalı ve sadece rakamlardan oluşmalıdır!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 3. KORUMA KALKANI: İŞ MANTIĞI (BUSINESS LOGIC) KONTROLÜ ---
            // Eğer yeni kayda idari yetkiler (Admin/SuperAdmin) veriliyorsa, sistem güvenliği adına kullanıcı adı ve şifre zorunlu kılınır.
            if ((chkAdmin.Checked || chkSuperAdmin.Checked) &&
                (string.IsNullOrWhiteSpace(tbxUserName.Text) || string.IsNullOrWhiteSpace(tbxPassword.Text)))
            {
                MessageBox.Show("Yönetici yetkisi veriyorsanız Kullanıcı Adı ve Şifre boş bırakılamaz!", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 4. KORUMA KALKANI: ROL TABANLI YETKİ KONTROLÜ (AUTHORIZATION) ---
            // Oturumu açan aktif kullanıcının rolü SuperAdmin (RoleId = 1) değilse, sisteme yeni bir SuperAdmin eklemesi engellenir.
            if (chkSuperAdmin.Checked && Session.ActiveRoleId != 1)
            {
                MessageBox.Show("Yetkiniz yönetici eklemek için yetersiz!", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // --- NİHAİ AŞAMA: ÇOKLU TABLO INSERT VE TRANSACTION YÖNETİMİ ---
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                // ACID Prensipleri: Kullanıcı hem AppUsers tablosuna hem de çoklu rol tablosuna (UserRoles) yazılacağı için
                // veri tutarlılığını korumak adına Transaction başlatılır.
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 'SELECT SCOPE_IDENTITY();' ile insert edilen yeni kullanıcının otomatik artan UserId'si anlık yakalanır.
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

                        // ExecuteScalar ile yeni üretilen UserId yerel değişkene alınır.
                        int insertedUserId = Convert.ToInt32(cmdForUser.ExecuteScalar());

                        // Çoklu Rol Atama Mantığı: Seçilen CheckBox durumlarına göre kullanıcıya birden fazla rol ataması modüler metotla yapılır.
                        if (chkMember.Checked) AssignRoleToUser(conn, transaction, insertedUserId, 3);
                        if (chkAdmin.Checked) AssignRoleToUser(conn, transaction, insertedUserId, 2);
                        if (chkSuperAdmin.Checked) AssignRoleToUser(conn, transaction, insertedUserId, 1);

                        transaction.Commit(); // Tüm operasyonlar başarılı ise veritabanı güncellenir.
                        MessageBox.Show("Üye başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BringAndSearchMemberDatas(); // Liste yenilenir.
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Herhangi bir hata anında veritabanı güvenli eski haline geri döndürülür.
                    MessageBox.Show("Kayıt sırasında bir SQL hatası oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Modüler Rol Atama Metodu:
        /// Kullanıcı ID'si ile hedef Rol ID'sini ara tabloya (UserRoles) kaydeder.
        /// </summary>
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
            // Grid Tasarım ve Güvenlik Ayarları
            dgwMembers.ReadOnly = true;
            dgwMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwMembers.AllowUserToAddRows = false;
            tbxIdentityNumber.MaxLength = 11; // Arayüz seviyesinde 11 karakter sınırı konur.

            ChangePassive(); // Başlangıçta kullanıcı adı ve şifre alanları kilitlenir.
            BringAndSearchMemberDatas(); // Veriler çekilir.
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId > 0)
            {
                // Formlar arası veri transferi kurucu metot (Constructor) üzerinden gerçekleştirilir.
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
                    // Seçilen satırdaki üye bilgileri RAM'e ve bilgi kartlarındaki salt okunur (ReadOnly) alanlara aktarılır.
                    _selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);

                    tbxUpdateName.Text = row.Cells["FirstName"].Value?.ToString();
                    tbxUpdateLastName.Text = row.Cells["LastName"].Value?.ToString();
                    tbxUpdateIdentity.Text = row.Cells["IdentityNumber"].Value?.ToString();
                    tbxUpdateRoles.Text = row.Cells["Roles"].Value?.ToString();

                    // Bilgi Güvenliği Standartları: Detay gösterim kutuları manuel müdahaleye kapatılır.
                    tbxUpdateName.Enabled = false;
                    tbxUpdateLastName.Enabled = false;
                    tbxUpdateIdentity.Enabled = false;
                    tbxUpdateRoles.Enabled = false;
                }
            }
        }

        // Dinamik UI Kontrolleri: Kullanıcıya sadece yetki CheckBox'larını seçtiğinde kullanıcı adı/şifre giriş alanı açılır.
        void ChangePassive() { tbxUserName.Enabled = false; tbxPassword.Enabled = false; }
        private void chkAdmin_CheckedChanged(object sender, EventArgs e) { if (chkAdmin.Checked) { tbxUserName.Enabled = true; tbxPassword.Enabled = true; } else ChangePassive(); }
        private void chkSuperAdmin_CheckedChanged(object sender, EventArgs e) { if (chkSuperAdmin.Checked) { tbxUserName.Enabled = true; tbxPassword.Enabled = true; } else ChangePassive(); }

        // Real-time Filtering: Arama kutusuna girilen her harfte liste anlık süzülür.
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

                            // İLERİ DÜZEY İLİŞKİSEL ENNVANTER KORUMA ALGORİTMASI (TRANSACTION):
                            // Kütüphane iş mantığı gereği, bir üye silindiğinde veri tutarsızlığı (data inconsistency) oluşmaması adına;
                            // 1. Üyenin aktif durumu kapatılır (Status = 0).
                            // 2. Üyenin üzerinde teslim edilmemiş aktif kitaplar varsa, alt sorgu ile tespit edilir ve Books tablosundaki stokları '+1' artırılır.
                            // 3. Üyeye ait tüm açık ödünç alma hareketleri otomatik olarak pasife çekilerek (Status = 0) kütüphaneye iade sayılır.
                            SqlTransaction transaction = conn.BeginTransaction();

                            try
                            {
                                // 1. Üyenin durumunu mantıksal olarak pasife al (Soft Delete)
                                string queryUser = "UPDATE AppUsers SET Status = 0 WHERE UserId = @id";
                                SqlCommand cmdUser = new SqlCommand(queryUser, conn, transaction);
                                cmdUser.Parameters.AddWithValue("@id", _selectedUserId);
                                cmdUser.ExecuteNonQuery();

                                // PROJEYE ÖZGÜ GELİŞMİŞ STOK TETİKLEME ALGORİTMASI: 
                                // Üyenin elindeki tüm aktif kitapların envanter stok miktarı kütüphaneye geri yüklenir.
                                string queryReturnStocks = @"UPDATE Books SET QuantityInStocks = QuantityInStocks + 1 
                                                             WHERE BookId IN (SELECT BookId FROM BookLoans WHERE UserId = @id AND Status = 1)";
                                SqlCommand cmdReturnStocks = new SqlCommand(queryReturnStocks, conn, transaction);
                                cmdReturnStocks.Parameters.AddWithValue("@id", _selectedUserId);
                                cmdReturnStocks.ExecuteNonQuery();

                                // 2. Üyeye ait aktif ödünç hareketlerini kapat (İade Edildi İşlemi)
                                string queryLoans = "UPDATE BookLoans SET Status = 0 WHERE UserId = @id AND Status = 1";
                                SqlCommand cmdLoans = new SqlCommand(queryLoans, conn, transaction);
                                cmdLoans.Parameters.AddWithValue("@id", _selectedUserId);
                                cmdLoans.ExecuteNonQuery();

                                // Üç aşamalı ilişkisel operasyon da başarılı ise veritabanı tek seferde kalıcı olarak onaylanır.
                                transaction.Commit();
                                MessageBox.Show("Üye silindi, elindeki aktif kitaplar kütüphane stoğuna başarıyla geri iade edildi.");
                            }
                            catch
                            {
                                // Herhangi bir aşamada zincir kırılırsa tüm işlemler iptal edilir, fiziksel stoklar güvenceye alınır.
                                transaction.Rollback();
                                throw;
                            }
                        }
                        BringAndSearchMemberDatas(); // Arayüz listesi güncellenir.
                        _selectedUserId = 0; // Seçim sıfırlanır.
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
            // Bellek (RAM) Optimizasyonu:
            // Sürdürülebilir kod standartlarına uygun olarak yeni bir 'frmMain' türetilmez.
            // Arka planda gizlenmiş olan mevcut ana kontrol paneli örneği çağrılır ve bu form RAM'den tamamen imha edilir (Close).
            Form frmMainInstance = Application.OpenForms["frmMain"];
            if (frmMainInstance != null)
            {
                frmMainInstance.Show();
            }
            this.Close();
        }
    }
}
