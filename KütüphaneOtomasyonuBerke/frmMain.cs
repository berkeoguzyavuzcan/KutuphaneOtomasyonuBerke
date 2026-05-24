using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // --- 1. OTURUM VE YETKİ YÖNETİMİ (SESSION MANAGEMENT) ---
            // 'FrmGiriş' formunda başarılı giriş yapıldığında statik 'Session' sınıfına kaydedilen 
            // aktif kullanıcı adı ve rol bilgileri, arayüzdeki etiketlere (Label) dinamik olarak aktarılır.
            // Bu sayede sistem genelinde durum koruması (State Management) sağlanmış olur.
            lblRoleName.Text = Session.ActiveRoleName.ToString();
            lblUserName.Text = Session.ActiveUserName.ToString();

            // --- 2. KULLANICI DENEYİMİ (UI/UX) VE MODERN ARAYÜZ TASARIMI ---
            // Standart Windows Forms buton görünümünün dışına çıkılarak minimalist ve modern bir tasarım dili benimsenmiştir.
            // Butonların kenarlıkları kaldırılmış (BorderSize = 0) ve FlatStyle özellikleri atanmıştır.
            // 'Color.FromArgb' kullanılarak modern web standartlarında (indigo/purple tonları) hover ve click efektleri tanımlanmıştır.

            // Kitaplar Butonu Tasarım Yapılandırması:
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 70, 229); // Fare üzerine geldiğinde (Hover) alacağı renk
            btnBooks.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202); // Butona tıklandığında (Click) alacağı renk

            // Üyeler Butonu Tasarım Yapılandırması:
            btnMembers.FlatStyle = FlatStyle.Flat;
            btnMembers.FlatAppearance.BorderSize = 0;
            btnMembers.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 70, 229);
            btnMembers.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);

            // Geri Dön / Çıkış Butonu Tasarım Yapılandırması:
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 70, 229);
            btnBack.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);

            // Ödünç / Emanet İşlemleri Butonu Tasarım Yapılandırması:
            btnLoans.FlatStyle = FlatStyle.Flat;
            btnLoans.FlatAppearance.BorderSize = 0;
            btnLoans.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 70, 229);
            btnLoans.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);
        }

        // --- 3. ÇOKLU FORM MİMARİSİ VE NAVİGASYON YÖNETİMİ ---
        // Uygulama içi yönlendirmelerde yeni form pencereleri 'Show' metodu ile ekrana getirilirken, 
        // ekran karmaşasını önlemek adına mevcut ana menü formu 'this.Hide' ile arka plana gizlenir.

        private void btnBooks_Click(object sender, EventArgs e)
        {
            frmBooks books = new frmBooks();
            books.Show();
            this.Hide(); // Ana menüyü gizle
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            frmMembers members = new frmMembers();
            members.Show();
            this.Hide(); // Ana menüyü gizle
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Görsel katman ayarı: Etiketin arka planı şeffaf yapılarak form tasarımıyla bütünleşmesi sağlanır.
            label1.BackColor = Color.Transparent;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Oturumu Kapatma / Güvenli Çıkış Senaryosu:
            // Kullanıcı ana menüden çıkış yapmak istediğinde tekrar giriş formu (FrmGiriş) çağrılır.
            // 'this.Close' metodu ile ana menü formu tamamen kapatılarak RAM üzerindeki kaynakları temizlenir.
            FrmGiriş frmGirişForm = new FrmGiriş();
            frmGirişForm.Show();
            this.Close();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            frmBookLoans loans = new frmBookLoans();
            loans.Show();
            this.Hide(); // Ana menüyü gizle
        }
    }
}
