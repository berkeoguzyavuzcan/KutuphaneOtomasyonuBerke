using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmUpdateMembers : Form
    {
        // Sınıf Seviyesinde Kapsüllenmiş Değişken (Private Field):
        // Listeden seçilen ve güncellenecek olan üyenin benzersiz kimlik (ID) numarası,
        // formun yaşam döngüsü boyunca kullanılmak üzere RAM'de saklanır.
        int _selectedUserId;

        // Nesne Yönelimli Programlama (OOP) - Parametreli Yapıcı Metot (Constructor Injection):
        // Form nesnesi oluşturulurken güncellenecek kullanıcının benzersiz ID bilgisinin dışarıdan güvenli bir şekilde aktarılmasını zorunlu kılar.
        public frmUpdateMembers(int selectedUserId)
        {
            InitializeComponent();
            _selectedUserId = selectedUserId;
        }

        private void frmUpdateMembers_Load(object sender, EventArgs e)
        {
            // Form belleğe yüklendiği anda ilgili üyeye ait verileri ve rolleri veritabanından çekerek arayüze doldurur.
            LoadDatas();
        }

        /// <summary>
        /// Kullanıcı ve Rol Verilerini Form Nesnelerine Doldurma Metodu:
        /// 'SqlDataReader' mimarisini (Connected Layer) kullanarak ilişkisel iki farklı sorgudan verileri sırayla okur.
        /// </summary>
        private void LoadDatas()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();

                // --- 1. ETAP: KULLANICI TEMEL BİLGİLERİNİN OKUNMASI ---
                string query = "SELECT FirstName, LastName, IdentityNumber, BirthDate, Gender, Username, Password FROM AppUsers WHERE UserId = @userId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // SQL Injection Güvenlik Önlemi: Parametrik değer ataması.
                    cmd.Parameters.AddWithValue("@userId", _selectedUserId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // İlgili ID'ye ait kayıt bulunduysa ileri yönlü (Forward-Only) okuma işlemi başlar.
                        if (dr.Read())
                        {
                            tbxFirstName.Text = dr["FirstName"].ToString();
                            tbxLastName.Text = dr["LastName"].ToString();
                            tbxIdentityNumber.Text = dr["IdentityNumber"].ToString();
                            dtpBirthDate.Value = Convert.ToDateTime(dr["BirthDate"]);

                            // Mantıksal Durum Yönetimi (Boolean State): 
                            // Gender kolonu true ise Erkek, false ise Kadın RadioButton nesnesi otomatik işaretlenir.
                            rbMan.Checked = Convert.ToBoolean(dr["Gender"]);
                            rbWoman.Checked = !rbMan.Checked;

                            tbxUserName.Text = dr["Username"].ToString();
                            tbxPassword.Text = dr["Password"].ToString();
                        }
                    } // SqlDataReader otomatik olarak Dispose edilerek bağlantı kanalı boşa çıkarılır.
                }

                // --- 2. ETAP: KULLANICI ROLLERİNİN SEÇİLMESİ (Many-to-Many Reading) ---
                // Kullanıcı birden fazla yetkiye (Örn: Hem Admin hem Member) sahip olabileceği için döngü (while) ile tüm roller taranır.
                string roleQuery = "SELECT RoleId FROM UserRoles WHERE UserId = @userId";
                using (SqlCommand cmdRole = new SqlCommand(roleQuery, conn))
                {
                    cmdRole.Parameters.AddWithValue("@userId", _selectedUserId);
                    using (SqlDataReader drRole = cmdRole.ExecuteReader())
                    {
                        // Arayüz Temizliği: Eski işaretlemeler sıfırlanır.
                        chkSuperAdmin.Checked = chkAdmin.Checked = chkMember.Checked = false;

                        // Veritabanındaki ilişkisel ara tablodan (Bridge Table) gelen roller satır satır okunur.
                        while (drRole.Read())
                        {
                            int rId = Convert.ToInt32(drRole["RoleId"]);
                            // Sabit (Hardcoded) Rol Eşleştirmeleri UI elemanlarına yansıtılır:
                            if (rId == 1) chkSuperAdmin.Checked = true;
                            if (rId == 2) chkAdmin.Checked = true;
                            if (rId == 3) chkMember.Checked = true;
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Güncelleme sürecini başlatan iş parçacığı tetiklenir.
            UpdateProcess();
        }

        /// <summary>
        /// Gelişmiş Üye ve Rol Güncelleme Metodu:
        /// Çoklu tablo operasyonlarında veri bütünlüğünü güvence altına almak için 'SqlTransaction' mimarisini işletir.
        /// </summary>
        private void UpdateProcess()
        {
            try
            {
                using (SqlConnection conn = SqlCon.Connect())
                {
                    conn.Open();

                    // TRANSACTION YÖNETİMİ (ACID Prensipleri):
                    // Üye güncellenirken önce temel bilgileri değiştirilir, ardından eski rolleri silinip yeni seçilen roller eklenir.
                    // Bu üç aşamalı işlem esnasında elektrik kesintisi veya hata oluşursa veritabanının tutarsız kalmaması için Transaction başlatılır.
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. ADIM: AppUsers Tablosundaki Temel Demografik ve Hesap Bilgilerinin Güncellenmesi
                            string updateSql = @"UPDATE AppUsers SET FirstName=@fn, LastName=@ln, IdentityNumber=@id, 
                                                 BirthDate=@bd, Gender=@g, Username=@un, Password=@pw WHERE UserId=@uid";

                            using (SqlCommand cmd = new SqlCommand(updateSql, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@uid", _selectedUserId);
                                cmd.Parameters.AddWithValue("@fn", tbxFirstName.Text);
                                cmd.Parameters.AddWithValue("@ln", tbxLastName.Text);
                                cmd.Parameters.AddWithValue("@id", tbxIdentityNumber.Text);
                                cmd.Parameters.AddWithValue("@bd", dtpBirthDate.Value);
                                cmd.Parameters.AddWithValue("@g", rbMan.Checked);
                                cmd.Parameters.AddWithValue("@un", tbxUserName.Text);
                                cmd.Parameters.AddWithValue("@pw", tbxPassword.Text);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. ADIM: Arayüzdeki Seçili Rollerin Dinamik Koleksiyona (`Generic List`) Alınması
                            List<int> newRoles = new List<int>();
                            if (chkSuperAdmin.Checked) newRoles.Add(1);
                            if (chkAdmin.Checked) newRoles.Add(2);
                            if (chkMember.Checked) newRoles.Add(3);

                            // 3. ADIM: Eski Rol İlişkilerinin Temizlenmesi (DELETE Eski Kayıtlar)
                            // İlişkisel bütünlüğü korumanın en kararlı yolu, kullanıcının o anki tüm rollerini sıfırlayıp yenilerini yazmaktır.
                            using (SqlCommand cmdDel = new SqlCommand("DELETE FROM UserRoles WHERE UserId=@uid", conn, trans))
                            {
                                cmdDel.Parameters.AddWithValue("@uid", _selectedUserId);
                                cmdDel.ExecuteNonQuery();
                            }

                            // 4. ADIM: Yeni Rollerin Döngü ile Ara Tabloya Kaydedilmesi (INSERT Yeni Roller)
                            // Koleksiyona eklenen her bir rol kimliği (RoleId) 'foreach' döngüsüyle tek tek SQL Server'a basılır.
                            foreach (int roleId in newRoles)
                            {
                                using (SqlCommand cmdIns = new SqlCommand("INSERT INTO UserRoles (UserId, RoleId) VALUES (@uid, @rid)", conn, trans))
                                {
                                    cmdIns.Parameters.AddWithValue("@uid", _selectedUserId);
                                    cmdIns.Parameters.AddWithValue("@rid", roleId);
                                    cmdIns.ExecuteNonQuery();
                                }
                            }

                            // Tüm adımlar hatasız tamamlandığında değişiklikler veritabanına kalıcı olarak işlenir.
                            trans.Commit();
                            MessageBox.Show("Başarıyla güncellendi!", "Başarılı Operasyon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            // Hata Yönetimi: Adımlardan herhangi biri başarısız olursa (Örn: Rol eklenemezse), 
                            // yapılan kullanıcı güncellemesi de dahil olmak üzere tüm işlemler geri sarılır (Rollback).
                            trans.Rollback();
                            MessageBox.Show("Güncelleme iptal edildi. HATA: " + ex.Message, "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı sunucusuna bağlanılamadı: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form kapatma ve kaynakları işletim sistemine iade etme operasyonu.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
