using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        private void btnGiriş_Click(object sender, EventArgs e)
        {
            // Kullanıcı arayüzünden (TextBox nesnelerinden) giriş verileri yerel değişkenlere alınır.
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            // UI/Arayüz Seviyesinde Doğrulama (Validasyon Kontrolü):
            // Boş karakter girişi, boşluk içeren veri girişi veya karakter sınırı (min 3, max 49) ihlalleri 
            // veritabanına sorgu gönderilerek sistemi yormadan önce arayüz katmanında engellenir.
            if (username.Trim().Length == 0 || password.Trim().Length == 0 || username.Contains(" ") || password.Contains(" ") || username.Length < 3 || username.Length > 49 || password.Length > 49)
            {
                MessageBox.Show("Hatalı giriş şekli. Lütfen en az 3 karakter giriniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Modülerlik ve Soyutlama İlkesi: 
                // Veritabanı bağlantı cümlesi arayüzde açıkça yazılmaz. 'SqlCon' sınıfından güvenli bir şekilde çağrılır.
                // 'using' bloğu, işlem bittiğinde veritabanı bağlantısının (Connection) bellekten (RAM) otomatik olarak temizlenmesini (Dispose edilmesini) sağlar.
                using (SqlConnection connection = SqlCon.Connect())
                {
                    connection.Open();

                    // İlişkisel Veritabanı ve Performanslı Sorgu Yönetimi:
                    // 'SELECT *' kullanmak yerine sadece ihtiyaç duyulan sütunlar (UserId, RoleId, RoleName, FullName) çağrılmıştır.
                    // INNER JOIN yapıları kullanılarak AppUsers, UserRoles ve AppRoles tabloları ilişkisel olarak birleştirilmiştir.
                    string queryForLogin = "SELECT TOP (1) au.UserId as UserId, ur.RoleId as RoleId, ar.RoleName as RoleName, au.FirstName + ' '+ au.LastName as FullName FROM AppUsers au\r\nINNER JOIN UserRoles ur\r\nON au.UserId=ur.UserId\r\nINNER JOIN AppRoles ar\r\nON ar.RoleId=ur.RoleId\r\nWHERE Username = @username AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(queryForLogin, connection))
                    {
                        // Siber Güvenlik / Güvenli Kodlama (SQL Injection Koruması):
                        // Kullanıcı girdileri sorguya doğrudan metin olarak eklenmez, '@' parametreleri olarak bağlanır.
                        // Böylece dışarıdan yapılabilecek zararlı SQL komutu sızdırma girişimleri tamamen engellenmiş olur.
                        cmd.Parameters.AddWithValue("@username", tbxUsername.Text);
                        cmd.Parameters.AddWithValue("@password", tbxPassword.Text);

                        // SqlDataReader ile sorgu sonucu veritabanından satır satır okunur.
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            // Eğer girilen kullanıcı adı ve şifreye ait eşleşen bir kayıt (satır) bulunursa:
                            if (dr.Read())
                            {
                                // Veritabanından gelen kullanıcı bilgileri uygun veri tiplerine dönüştürülerek değişkenlere atanır.
                                int UserId = Convert.ToInt32(dr["UserId"]);
                                int roleıd = Convert.ToInt32(dr["RoleId"]);
                                string roleName = dr["RoleName"].ToString();
                                string fullname = dr["FullName"].ToString();

                                // Oturum ve Durum Yönetimi (Session Management):
                                // Giriş yapan kullanıcının Id, Rol ve İsim bilgileri 'Session' adlı statik sınıfta saklanır.
                                // Bu sayede sistemdeki diğer formlar (Kitap Ekleme, Üye Silme vb.) kullanıcının yetkisini bu merkezden kontrol edebilir.
                                Session.ActiveRoleId = roleıd;
                                Session.ActiveRoleName = roleName;
                                Session.ActiveUserId = UserId;
                                Session.ActiveUserName = fullname;

                                MessageBox.Show($"Hoşgeldiniz, {fullname}.\n{roleıd} - {roleName}", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Çoklu Form Mimarisi (Multi-Form Architecture) ve Form Yönetimi:
                                // Giriş başarılı olduğunda ana menü (frmMain) nesnesi türetilir ve ekranda gösterilir.
                                // Mevcut giriş formu (this.Hide) ile arka plana gizlenerek ekran karmaşası önlenir.
                                frmMain main = new frmMain();
                                main.Show();
                                this.Hide();
                            }
                            else
                            {
                                // Girilen bilgiler veritabanındaki hiçbir kayıtla eşleşmezse kullanıcıya hata bildirilir.
                                MessageBox.Show("Başarısız Giriş");
                            }
                        }
                    }
                }
            }
        }

        private void FrmGiriş_Load(object sender, EventArgs e)
        {

        }
    }
}
