using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmBookLoans : Form
    {
        // Sınıf Seviyesinde Değişkenler (Global Fields):
        // Eş zamanlı veri seçimi için DataGridView'lerden seçilen Kitap ID ve Üye ID değerleri,
        // ödünç verme sürecinde eşleştirilmek üzere RAM bellekte saklanır.
        int _selectedBookId = 0;
        int _selectedMemberId = 0;

        // Dinamik Zaman Kontrolü: Ekranda gerçek zamanlı saat ve tarih akışını sağlamak için başlatılan bileşen.
        Timer timer = new Timer();

        public frmBookLoans()
        {
            InitializeComponent();
        }

        private void frmBookLoans_Load(object sender, EventArgs e)
        {
            // --- 1. VERİ İZOLASYONU VE UI SEVİYESİNDE GÜVENLİK AYARLARI ---

            // Kitaplar tablosu ayarları:
            dgwBooks.ReadOnly = true;
            dgwBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwBooks.AllowUserToAddRows = false;

            // Üyeler tablosu ayarları:
            dgwMember.ReadOnly = true;
            dgwMember.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwMember.AllowUserToAddRows = false;

            // --- 2. BAŞLANGIÇ TETİKLEYİCİLERİ VE ASENKRON BENZERİ METOT ÇAĞRILARI ---
            BringAndSearchBooks();       // Kitap listesini yükler.
            BringAndSearchMember();      // Üye listesini yükler.
            ChangeStatusOfControllers(); // Manuel müdahaleyi önlemek için veri kutularını kilitler.
            BilgiKutusu();               // Özet istatistik paneline (Dashboard) verileri basar.
            TimerAyarlari();             // Gerçek zamanlı arayüz saatini devreye sokar.
        }

        /// <summary>
        /// İstatistiksel Panel Özet Metodu (Dashboard Engine):
        /// SQL Server 'COUNT' agregasyon fonksiyonlarını ve 'ExecuteScalar' mimarisini kullanarak
        /// sistemdeki anlık kiralama, toplam kiralama ve aktif üye sayılarını arayüze yansıtır.
        /// </summary>
        void BilgiKutusu()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();

                // Agregasyon sorgularında sadece tek değer (tek hücre) döneceği için 'ExecuteScalar' en performanslı yöntemdir.
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM BookLoans WHERE Status = 1", conn);
                object res1 = cmd1.ExecuteScalar();
                label17.Text = "Güncel Kiralanan: " + (res1 != null ? res1.ToString() : "0");

                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM BookLoans", conn);
                object res2 = cmd2.ExecuteScalar();
                label18.Text = "Toplam Kiralanan: " + (res2 != null ? res2.ToString() : "0");

                SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM AppUsers WHERE Status = 1", conn);
                object res3 = cmd3.ExecuteScalar();
                label19.Text = "Toplam Üye: " + (res3 != null ? res3.ToString() : "0");
            }
        }

        /// <summary>
        /// Gerçek Zamanlı Saat Yapılandırması:
        /// Her 1000 milisaniyede (1 saniye) bir 'Tick' event'ini tetikleyerek sistem saatini günceller.
        /// </summary>
        void TimerAyarlari()
        {
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                // Kültüre duyarlı tarih ve 24 saat formatında hassas zaman gösterimi sağlanır.
                label14.Text = DateTime.Now.ToString("ddd") + " " + DateTime.Now.ToString("MMM") + " " + DateTime.Now.ToString("yyyy");
                label15.Text = DateTime.Now.ToString("HH:mm");
            };
            timer.Start();
        }

        /// <summary>
        /// Üye Filtreleme ve Listeleme:
        /// Soft-delete (Mantıksal Silme) mantığına uygun olarak sadece aktif (Status = 1) olan üyeleri süzerek getirir.
        /// </summary>
        private void BringAndSearchMember()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                string query = @"SELECT UserId, FirstName, LastName, IdentityNumber, BirthDate FROM AppUsers 
                                 WHERE (FirstName + ' ' + LastName LIKE @val OR IdentityNumber LIKE @val)
                                 AND (Status = 1 OR Status IS NULL)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@val", '%' + tbxSearchMembers.Text + '%');
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgwMember.DataSource = dt;
                }
            }
        }

        /// <summary>
        /// İlişkisel Kitap Arama ve Stok Listeleme:
        /// Kitaplar (Books) ve Yazarlar (Authors) arasındaki Çoktan-Çoğa (Many-to-Many) ilişkiyi 
        /// 'BookAuthors' ara tablosu üzerinden iki kademeli INNER JOIN ile birleştirerek çeker.
        /// </summary>
        private void BringAndSearchBooks()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                string query = @"SELECT b.BookId, b.BookName, a.FirstName + ' ' + a.LastName AS AuthorName, 
                                 b.PublisherName, b.PageCount, b.QuantityInStocks 
                                 FROM Books b
                                 INNER JOIN BookAuthors ba ON b.BookId = ba.BookId
                                 INNER JOIN Authors a ON ba.AuthorId = a.AuthorId
                                 WHERE (b.BookName LIKE @val OR b.PublisherName LIKE @val)
                                 AND b.Status = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@val", '%' + tbxSearchBook.Text + '%');
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgwBooks.DataSource = dt;
                }
            }
        }

        /// <summary>
        /// Dinamik UI Kontrol Döngüsü:
        /// Nesne Yönelimli Programlama (OOP) prensiplerine uygun olarak, GroupBox içerisindeki 
        /// tüm TextBox elemanlarını 'foreach' döngüsü ve 'Type Checking' (is TextBox) ile tespit edip salt okunur yapar.
        /// </summary>
        private void ChangeStatusOfControllers()
        {
            foreach (Control item in gbxBooks.Controls) if (item is TextBox) item.Enabled = false;
            foreach (Control item in gbxMembers.Controls) if (item is TextBox) item.Enabled = false;
        }

        private void dgwBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgwBooks.CurrentRow;

            // Seçilen satırdaki kitap envanter verileri RAM'e ve ilgili TextBox alanlarına doldurulur.
            _selectedBookId = Convert.ToInt32(row.Cells[0].Value);
            tbxBookName.Text = row.Cells[1].Value.ToString();
            tbxAuthorName.Text = row.Cells[2].Value.ToString();
            tbxPublisherName.Text = row.Cells[3].Value.ToString();
            tbxPageCount.Text = row.Cells[4].Value.ToString();
            tbxStocks.Text = row.Cells[5].Value.ToString();
        }

        private void dgwMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgwMember.Rows.Count) return;

            DataGridViewRow row = dgwMember.Rows[e.RowIndex];

            if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
            {
                _selectedMemberId = Convert.ToInt32(row.Cells[0].Value);
                tbxFirstName.Text = row.Cells[1].Value?.ToString() ?? "";
            }
            else
            {
                // Defansif Programlama: Geçersiz bir hücreye tıklanırsa veriler sıfırlanır.
                _selectedMemberId = 0;
                tbxFirstName.Clear();
            }
        }

        private void btnProcesDone_Click(object sender, EventArgs e)
        {
            // Veri Doğrulama (Validation): İlişkisel işlem yapılmadan önce her iki tablodan da seçim yapıldığı garanti edilir.
            if (_selectedMemberId == 0 || _selectedBookId == 0)
            {
                MessageBox.Show("Lütfen önce listeden bir üye ve bir kitap seçin!", "Eksik Seçim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();

                // KRİTİK SEVİYE ENVANTER TRANSACTION YÖNETİMİ:
                // Ödünç verme işlemi eş zamanlı çoklu veritabanı müdahalesi gerektirir (Stok kontrol, Kayıt Ekleme, Stok Güncelleme).
                // Veri tutarsızlığını (Örn: Stoğu biten kitabın kiralanması veya kayıt açılıp stoktan düşülmemesi) engellemek için Transaction başlatılır.
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. ADIM: ANLIK STOK SEVİYESİ KONTROLÜ (Concurrency Control)
                        // Veri tabanındaki en güncel stok bilgisi anlık olarak çekilir. Arayüzdeki eskiyen veriye güvenilmez.
                        string stockQuery = "SELECT QuantityInStocks FROM Books WHERE BookId = @bId";
                        int currentStock = 0;
                        using (SqlCommand cmdStock = new SqlCommand(stockQuery, conn, trans))
                        {
                            cmdStock.Parameters.AddWithValue("@bId", _selectedBookId);
                            object result = cmdStock.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                currentStock = Convert.ToInt32(result);
                            }
                        }

                        // Stok Güvence Bariyeri: Eğer kitap kütüphanede kalmadıysa işlem derhal iptal edilir ve veritabanı korunur.
                        if (currentStock <= 0)
                        {
                            MessageBox.Show("Seçilen kitabın stoku tükenmiştir! Ödünç verilemez.", "Stok Yetersiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            trans.Rollback(); // Transaction iptal edilir.
                            return;
                        }

                        // 2. ADIM: EMANET HAREKETİ KAYDI AÇMA (INSERT INTO BOOKLOANS)
                        // Kitap ödünç kaydı, başlangıç tarihi (DateTime.Now) ve DateTimePicker'dan gelen teslim tarihi ile aktif (Status = 1) olarak açılır.
                        string sql = "INSERT INTO BookLoans (UserId, BookId, LoanDate, DueDate, Status) VALUES (@u, @b, @l, @d, 1)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@u", _selectedMemberId);
                            cmd.Parameters.AddWithValue("@b", _selectedBookId);
                            cmd.Parameters.AddWithValue("@l", DateTime.Now);
                            cmd.Parameters.AddWithValue("@d", dtpDueDate.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. ADIM: ENVANTER DÜŞÜŞÜ (STOCK DECREMENT)
                        // Kitap başarıyla teslim edildiği için Books tablosundaki fiziksel stok adedi '-1' eksiltilir.
                        string updateStockSql = "UPDATE Books SET QuantityInStocks = QuantityInStocks - 1 WHERE BookId = @b";
                        using (SqlCommand cmdUpdateStock = new SqlCommand(updateStockSql, conn, trans))
                        {
                            cmdUpdateStock.Parameters.AddWithValue("@b", _selectedBookId);
                            cmdUpdateStock.ExecuteNonQuery();
                        }

                        // Zincirdeki 3 işlem de başarıyla biterse veritabanı kalıcı olarak mühürlenir.
                        trans.Commit();
                        MessageBox.Show("İşlem başarılı. Kitap ödünç verildi ve stok düşüldü.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Arayüz ve Dashboard Yenileme Döngüsü:
                        BilgiKutusu();
                        BringAndSearchMember();
                        BringAndSearchBooks(); // Güncel stokların anlık yansıması için tablolar tazeledir.
                    }
                    catch (Exception ex)
                    {
                        // Hata Yakalama: İşlemlerin herhangi bir yerinde çökme olursa veritabanı ilk başladığı kararlı haline geri sarılır.
                        trans.Rollback();
                        MessageBox.Show("Hata oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Formlar Arası Geçiş Tetikleyicileri
        private void btnStateOfDue_Click(object sender, EventArgs e) => new frmStateOfDue().ShowDialog();

        // Real-Time Search (Anlık Veri Süzme): Harf girildiği anda tetiklenen arama metotları.
        private void tbxSearchBook_TextChanged(object sender, EventArgs e) => BringAndSearchBooks();
        private void tbxSearchMembers_TextChanged(object sender, EventArgs e) => BringAndSearchMember();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Bellek Dostu Geri Dönüş Mimari: Mevcut gizlenmiş olan ana formu bulup gösterir ve bu formu RAM'den siler.
            Form frmMainInstance = Application.OpenForms["frmMain"];
            if (frmMainInstance != null)
            {
                frmMainInstance.Show();
            }
            this.Close();
        }
    }
}
