using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmBooks : Form
    {
        // Sınıf Seviyesinde Değişkenler (Global Fields):
        // DataGridView üzerinde seçilen satıra ait ilişkisel anahtarlar (ID bilgileri) 
        // güncelleme ve silme işlemlerinde kullanılmak üzere RAM bellekte saklanır.
        private int _selectedBookId;
        private int _selectedAuthorId;

        public frmBooks()
        {
            InitializeComponent();
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            // Veri Güvenliği ve Kullanıcı Deneyimi (UX) Yapılandırması:
            dgwBooks.ReadOnly = true; // Kullanıcının ızgara (Grid) üzerinden verileri manuel manipüle etmesi engellenir.
            dgwBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Satır bazlı tam seçim modu aktif edilir.
            dgwBooks.AllowUserToAddRows = false; // Grid'in altında otomatik boş satır oluşması engellenerek görsel bütünlük korunur.

            BringAndSearchDatas(); // Form yüklendiğinde envanter listesi veritabanından çekilir.
            ListAuthors();         // Yazarlar tablosu ComboBox bileşenine doldurulur.
        }

        /// <summary>
        /// Dinamik Filtreleme ve Arama Metodu:
        /// Kitap adı, yayınevi veya yazar adına göre veritabanından optimize edilmiş arama yapar.
        /// </summary>
        public void BringAndSearchDatas()
        {
            try
            {
                // Modülerlik ilkesine uygun olarak SqlCon sınıfından bağlantı nesnesi üretilir.
                using (SqlConnection conn = SqlCon.Connect())
                {
                    conn.Open();

                    // İlişkisel Veritabanı (RDBMS) ve Performans Yönetimi:
                    // 'SELECT *' yerine sadece arayüzde gösterilecek sütunlar açıkça belirtilmiştir.
                    // INNER JOIN kullanılarak Kitaplar, KitapYazarları ve Yazarlar tabloları ilişkisel olarak bağlanmıştır.
                    // 'Books.Status = 1' şartı ile sadece sistemde aktif olan (silinmemiş) kitaplar listelenir.
                    string query = @"SELECT Books.BookId AS Id, Books.BookName AS Kitap, BookAuthors.AuthorId, 
                                     Authors.FirstName + ' ' + Authors.LastName AS Yazar, Books.PublisherName AS Yayınevi, 
                                     Books.PageCount AS [Sayfa Sayısı] 
                                     FROM Books
                                     INNER JOIN BookAuthors ON Books.BookId = BookAuthors.BookId
                                     INNER JOIN Authors ON Authors.AuthorId = BookAuthors.AuthorId
                                     WHERE (Books.BookName LIKE @Words OR Books.PublisherName LIKE @Words OR Authors.FirstName + ' ' + Authors.LastName LIKE @Words) 
                                     AND Books.Status = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // SQL Injection Koruması: Kullanıcıdan alınan arama kelimesi parametre olarak güvenli bir şekilde bağlanır.
                        cmd.Parameters.AddWithValue("@Words", "%" + tbxSearchBook.Text + "%");

                        // Bağlantısız Katman (Disconnected Layer) Nesneleri:
                        // SqlDataAdapter ve DataTable kullanılarak veriler belleğe alınır ve DataGridView'e bağlanır (Data Binding).
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgwBooks.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Gelişmiş Hata Yönetimi (Exception Handling): Sistem çökmesi engellenir ve hata kullanıcıya bildirilir.
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        /// <summary>
        /// ComboBox Veri Bağlama Metodu:
        /// Yazarları ilişkisel kimlikleriyle (ID) birlikte listeler.
        /// </summary>
        void ListAuthors()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                string query = "SELECT AuthorId, FirstName + ' ' + LastName AS FullName FROM Authors";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);

                        // Data Binding Standartları:
                        cbxAuthorName.DataSource = dt;
                        cbxAuthorName.DisplayMember = "FullName"; // Kullanıcının göreceği metinsel alan
                        cbxAuthorName.ValueMember = "AuthorId";   // Arka planda veritabanına kaydedilecek ilişkisel anahtar (ID)
                    }
                }
            }
        }

        private void dgwBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satır Seçim Kontrolü: Başlık satırına tıklandığında oluşabilecek endeks hataları engellenir.
            if (e.RowIndex >= 0)
            {
                // Seçilen satıra ait benzersiz anahtarlar yerel değişkenlere aktarılarak hafızada güncel tutulur.
                _selectedBookId = Convert.ToInt32(dgwBooks.Rows[e.RowIndex].Cells["Id"].Value);
                _selectedAuthorId = Convert.ToInt32(dgwBooks.Rows[e.RowIndex].Cells["AuthorId"].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Defansif Kodlama (Giriş Kontrolü): Listeden bir kitap seçilip seçilmediği doğrulanır.
            if (_selectedBookId > 0)
            {
                // Formlar Arası Veri Transferi (Constructor Injection Mantığı):
                // Seçilen kitabın ve yazarın ID bilgileri, güncelleme formunun kurucu metoduna parametre olarak gönderilir.
                frmUpdateBooks updateForm = new frmUpdateBooks(_selectedBookId, _selectedAuthorId);
                updateForm.ShowDialog(); // Form modal olarak açılarak ana formun kilitlenmesi ve işlem güvenliği sağlanır.
                BringAndSearchDatas();   // Güncelleme işleminden sonra liste anlık olarak yenilenir.
            }
            else MessageBox.Show("Lütfen bir kitap seçin.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedBookId > 0)
            {
                if (MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = SqlCon.Connect())
                    {
                        conn.Open();

                        // Güvenli Silme Stratejisi (Soft Delete / Mantıksal Silme):
                        // Veri tabanından fiziksel olarak veri yok edilmez. 'Status = 0' yapılarak arşivlenir.
                        // Bu mimari tercih, geçmişe dönük ödünç (emanet) hareketlerindeki veri bütünlüğünün (Data Integrity) korunmasını sağlar.
                        SqlCommand cmd = new SqlCommand("UPDATE Books SET Status = 0 WHERE BookId = @id", conn);
                        cmd.Parameters.AddWithValue("@id", _selectedBookId);
                        cmd.ExecuteNonQuery();
                    }
                    BringAndSearchDatas(); // Arayüz listesi güncellenir.
                }
            }
            else MessageBox.Show("Lütfen bir kitap seçin.");
        }

        private void btnInsertBook_Click(object sender, EventArgs e)
        {
            // --- 1. KORUMA KALKANI: UI SEVİYESİNDE BOŞ ALAN KONTROLÜ (VALIDATION) ---
            // 'string.IsNullOrWhiteSpace' metodu ile boşluk veya space tuşuyla yapılan hatalı girişler veritabanına gitmeden engellenir.
            if (string.IsNullOrWhiteSpace(tbxBookName.Text) ||
                string.IsNullOrWhiteSpace(tbxPublisher.Text) ||
                cbxAuthorName.SelectedValue == null)
            {
                MessageBox.Show("Lütfen Kitap Adı, Yayınevi ve Yazar alanlarını eksiksiz doldurun!", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Algoritma kesilir, alt satırlardaki veritabanı komutları çalıştırılmaz.
            }

            // --- 2. KORUMA KALKANI: TİP VE DEĞER DOĞRULAMA ---
            // Sayfa sayısı ve stok miktarı mantıksal olarak 0 veya negatif olamaz. Sınır kontrolü yapılır.
            if (numPageCount.Value <= 0 || numStock.Value <= 0)
            {
                MessageBox.Show("Sayfa sayısı ve Stok miktarı 0 veya daha küçük olamaz!", "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- NİHAİ AŞAMA: VERİTABANI İŞLEMİ VE İLİŞKİSEL TRANSFER ---
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();

                // Veri Güvenliği ve ACID Prensipleri (Transaction Yönetimi):
                // Kitap ekleme işlemi iki aşamalıdır (Önce Books tablosu, sonra BookAuthors tablosu).
                // SqlTransaction kullanılarak, bu iki işlemden herhangi biri başarısız olursa veritabanının 
                // tamamen eski güvenli haline geri dönmesi (Rollback) garanti altına alınır. Kod bütünlüğü korunur.
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 'SELECT SCOPE_IDENTITY();' ifadesi ile Books tablosuna o an eklenen benzersiz otomatik artan (Identity) 
                    // yeni kitap kimlik numarası (BookId) anlık olarak yakalanır.
                    string qBook = @"INSERT INTO Books (BookName, PublisherName, PageCount, QuantityInStocks, Status) 
                                     VALUES (@name, @pub, @page, @stock, 1); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdB = new SqlCommand(qBook, conn, trans);
                    cmdB.Parameters.AddWithValue("@name", tbxBookName.Text);
                    cmdB.Parameters.AddWithValue("@pub", tbxPublisher.Text);
                    cmdB.Parameters.AddWithValue("@page", (int)numPageCount.Value);
                    cmdB.Parameters.AddWithValue("@stock", (int)numStock.Value);

                    // ExecuteScalar metodu sorgudan dönen ilk sütundaki tek bir değeri (SCOPE_IDENTITY değerini) okur.
                    int newBookId = Convert.ToInt32(cmdB.ExecuteScalar());

                    // İkinci Aşama: Yakalanan yeni Kitap ID'si ile ComboBox'tan seçilen Yazar ID'si 
                    // çoklu ilişki (Bridge/Köprü) tablosu olan 'BookAuthors' tablosuna güvenli bir şekilde kaydedilir.
                    string qRel = "INSERT INTO BookAuthors (BookId, AuthorId) VALUES (@bId, @aId)";
                    SqlCommand cmdRel = new SqlCommand(qRel, conn, trans);
                    cmdRel.Parameters.AddWithValue("@bId", newBookId);
                    cmdRel.Parameters.AddWithValue("@aId", cbxAuthorName.SelectedValue);
                    cmdRel.ExecuteNonQuery();

                    // Her iki insert işlemi de sorunsuz bittiyse veritabanı değişiklikleri kalıcı olarak onaylanır (Commit).
                    trans.Commit();
                    MessageBox.Show("Kitap başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BringAndSearchDatas(); // Arayüz verileri yenilenir.
                }
                catch (Exception ex)
                {
                    // Herhangi bir aşamada SQL veya sistem hatası alınırsa, veritabanında yarım kalmış (çöp) veri 
                    // oluşmaması için yapılan tüm işlemler geri alınır (Rollback). Veri bütünlüğü mutlak suretle korunur.
                    trans.Rollback();
                    MessageBox.Show("Hata oluştu: " + ex.Message, "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKitapGeri_Click(object sender, EventArgs e)
        {
            // Bellek (RAM) ve Performans Optimizasyonu:
            // 'new frmMain()' diyerek RAM bellekte gereksiz yere sıfırdan yeni bir ana form nesnesi üretilmez.
            // Zaten arkada açık duran mevcut ana form örneği (Instance) 'Application.OpenForms' ile çağrılarak ekrana getirilir.
            Form frmMainInstance = Application.OpenForms["frmMain"];
            if (frmMainInstance != null)
            {
                frmMainInstance.Show();
            }
            this.Close(); // Aktif kitaplar formu kapatılarak RAM üzerindeki kaynakları sisteme iade edilir.
        }

        // Kullanıcı arama kutusuna her harf girdiğinde (TextChanged olayı tetiklendiğinde) 
        // arama metodu anlık olarak çağrılır ve dinamik filtreleme (Real-time Filtering) gerçekleştirilir.
        private void tbxSearchBook_TextChanged(object sender, EventArgs e) => BringAndSearchDatas();
    }
}
