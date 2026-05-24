using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmStateOfDue : Form
    {
        // Sınıf Seviyesinde Değişken (Global Field):
        // İade edilmemiş ödünç listesinden (Grid) seçilen hareketin benzersiz kimlik numarası (LoanId),
        // iade operasyonunda doğru kaydı güncelleyebilmek adına RAM bellekte saklanır.
        int _selectedLoanId = 0;

        public frmStateOfDue()
        {
            InitializeComponent();
        }

        private void frmStateOfDue_Load(object sender, EventArgs e)
        {
            // --- 1. GÜVENLİK VE KULLANICI DENEYİMİ (UI/UX) YAPILANDIRMASI ---

            // Teslim edilmeyenler (Aktif Emanetler) tablosu ayarları:
            dgwNotCompletedReturns.ReadOnly = true;
            dgwNotCompletedReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwNotCompletedReturns.AllowUserToAddRows = false;

            // Teslim edilenler (Kapatılmış Kayıtlar) tablosu ayarları:
            dgwCompletedReturns.ReadOnly = true;
            dgwCompletedReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwCompletedReturns.AllowUserToAddRows = false;

            ListeleriYenile(); // Form belleğe yüklendiği an her iki veri kümesi de güncel olarak çekilir.
        }

        /// <summary>
        /// Geçmiş Kapatılan Emanet Kayıtlarını Listeleme Metodu:
        /// Sistemde başarıyla iade edilmiş (Status = 0) kayıtları filtreleyerek getirir.
        /// </summary>
        void BringAndSearchCompleted()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                // İlişkisel Veritabanı Mimarisi (RDBMS Optimization):
                // Ödünç hareketleri tablosu (BookLoans), Kullanıcılar (AppUsers) ve Kitaplar (Books) tablolarıyla 
                // INNER JOIN mantığıyla birleştirilerek ilişkisel bir veri kümesi elde edilmiştir.
                string query = @"SELECT bl.LoanId, au.FirstName, au.LastName, au.IdentityNumber, b.BookName, b.PublisherName, bl.LoanDate, bl.DueDate, bl.ReturnDate 
                                 FROM BookLoans bl
                                 INNER JOIN AppUsers au ON au.UserId = bl.UserId
                                 INNER JOIN Books b ON b.BookId = bl.BookId 
                                 WHERE bl.Status = 0 
                                 AND (au.FirstName + ' ' + au.LastName LIKE @key OR au.IdentityNumber LIKE @key OR b.BookName LIKE @key)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // SQL Injection Önlemi: Dinamik arama anahtarı parametre olarak güvenli bir şekilde bağlanır.
                    cmd.Parameters.AddWithValue("@key", "%" + tbxSearchInCompleted.Text + "%");

                    // Bağlantısız Katman (Disconnected Layer) mimarisi ile veri bağlama (Data Binding) gerçekleştirilir.
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgwCompletedReturns.DataSource = dt;
                }
            }
        }

        /// <summary>
        /// Aktif (Teslim Edilmeyen) Emanet Kayıtlarını Listeleme Metodu:
        /// Üyelerin elinde bulunan ve teslim süreci devam eden (Status = 1) kayıtları listeler.
        /// </summary>
        void BringAndSearchNotCompleted()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                // İlişkisel bütünlük korunarak, sadece aktif emanetler (Status = 1) süzülür.
                string query = @"SELECT bl.LoanId, au.FirstName, au.LastName, au.IdentityNumber, b.BookName, b.PublisherName, bl.LoanDate, bl.DueDate 
                                 FROM BookLoans bl
                                 INNER JOIN AppUsers au ON au.UserId = bl.UserId
                                 INNER JOIN Books b ON b.BookId = bl.BookId 
                                 WHERE bl.Status = 1 
                                 AND (au.FirstName + ' ' + au.LastName LIKE @key OR au.IdentityNumber LIKE @key OR b.BookName LIKE @key)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@key", "%" + tbxSearchInNotCompleted.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgwNotCompletedReturns.DataSource = dt;
                }
            }
        }

        /// <summary>
        /// Merkezi Veri Yenileme Metodu (Data Refresh):
        /// Kod tekrarını (Code Duplication) önlemek adına her iki listeleme fonksiyonunu tek çatı altında çağırır.
        /// </summary>
        void ListeleriYenile()
        {
            BringAndSearchCompleted();
            BringAndSearchNotCompleted();
        }

        private void dgwNotCompletedReturns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sınır Kontrolü (Boundary Control): Başlık veya geçersiz satırlara tıklandığında oluşabilecek endeks hataları önlenir.
            if (e.RowIndex < 0 || e.RowIndex >= dgwNotCompletedReturns.Rows.Count) return;

            DataGridViewRow row = dgwNotCompletedReturns.Rows[e.RowIndex];

            // Seçilen satırın boş (Null) veya veritabanı boşluğu (DBNull) olmadığı doğrulanır.
            if (row.Cells["LoanId"].Value != null && row.Cells["LoanId"].Value != DBNull.Value)
            {
                // Seçilen emanet kaydına ait detaylar bilgi kartı alanlarına (UI) aktarılır.
                _selectedLoanId = Convert.ToInt32(row.Cells["LoanId"].Value);

                tbxFirstName.Text = row.Cells["FirstName"].Value?.ToString() ?? "";
                tbxLastName.Text = row.Cells["LastName"].Value?.ToString() ?? "";
                tbxBookName.Text = row.Cells["BookName"].Value?.ToString() ?? "";
                tbxDueDate.Text = row.Cells["DueDate"].Value?.ToString() ?? "";
                tbxLoanDate.Text = row.Cells["LoanDate"].Value?.ToString() ?? "";
            }
            else
            {
                // Defansif Programlama: Hatalı veya boş bir hücre algılanırsa bellek ve arayüz alanları temizlenir.
                _selectedLoanId = 0;
                tbxFirstName.Clear();
                tbxLastName.Clear();
                tbxBookName.Clear();
                tbxDueDate.Clear();
                tbxLoanDate.Clear();
            }
        }

        private void btnReturnProccessDone_Click(object sender, EventArgs e)
        {
            // Giriş Doğrulaması (Input Validation): Listeden geçerli bir emanet kaydı seçilmediyse işlem durdurulur.
            if (_selectedLoanId == 0)
            {
                MessageBox.Show("Lütfen önce listeden bir kitap seçin!");
                return;
            }

            if (MessageBox.Show("İade işlemini onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = SqlCon.Connect())
                {
                    conn.Open();

                    // ACID Prensipleri ve Veri Tutarlılığı (Data Consistency):
                    // İade süreci iki aşamalı doğrusal bir operasyondur. Ödünç kaydı kapatılırken fiziki stok da güncellenmelidir.
                    // 'SqlTransaction' kullanılarak iki işlemin atomik (bölünemez) olarak tek seferde yapılması güvence altına alınır.
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. AŞAMA: Ödünç Kaydını Güncelle (Mantıksal Kapatma)
                            // İlgili hareketin durumu pasife çekilir (Status = 0) ve anlık iade tarihi (DateTime.Now) SQL'e gönderilir.
                            string query = "UPDATE BookLoans SET Status = 0, ReturnDate = @ret WHERE LoanId = @id";
                            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@ret", DateTime.Now);
                                cmd.Parameters.AddWithValue("@id", _selectedLoanId);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. AŞAMA: Gelişmiş Envanter ve Stok Yönetimi (Subquery Kullanımı)
                            // Kitap kütüphaneye fiziki olarak geri döndüğü için stok adedi '+1' artırılmalıdır.
                            // İlişkisel bütünlüğü korumak adına, direkt 'LoanId' üzerinden 'BookLoans' tablosuna alt sorgu (Subquery)
                            // atılarak ilgili kitabın 'BookId'si dinamik olarak tespit edilir ve 'Books' tablosundaki stoğu güncellenir.
                            string stockQuery = "UPDATE Books SET QuantityInStocks = QuantityInStocks + 1 WHERE BookId = (SELECT BookId FROM BookLoans WHERE LoanId = @id)";
                            using (SqlCommand cmdStock = new SqlCommand(stockQuery, conn, trans))
                            {
                                cmdStock.Parameters.AddWithValue("@id", _selectedLoanId);
                                cmdStock.ExecuteNonQuery();
                            }

                            // Her iki SQL komutu da sorunsuz çalıştıysa, transaction kalıcı olarak veritabanına işlenir (Commit).
                            trans.Commit();
                            MessageBox.Show("İade işlemi başarıyla tamamlandı ve kitap stoğu artırıldı.");

                            // Arayüz ve Bellek Optimizasyonu:
                            ListeleriYenile(); // Tablolar anlık güncellenir.
                            _selectedLoanId = 0; // Seçim sıfırlanır.

                            // Giriş kutuları bir sonraki işlem için temizlenir.
                            tbxFirstName.Clear();
                            tbxLastName.Clear();
                            tbxBookName.Clear();
                            tbxDueDate.Clear();
                            tbxLoanDate.Clear();
                        }
                        catch (Exception ex)
                        {
                            // Hata Yönetimi: İşlemlerden biri başarısız olursa veritabanı eski kararlı haline çekilir (Rollback).
                            // Bu sayede sistemde eldeki kitap sayısı değişip stoğu güncellenmeyen çöp veriler (dirty data) oluşmaz.
                            trans.Rollback();
                            MessageBox.Show("İade işlemi sırasında hata oluştu: " + ex.Message);
                        }
                    }
                }
            }
        }

        // Real-Time Filtering (Anlık Filtreleme): 
        // Kullanıcı arama kutularına karakter girdiğinde veritabanına anlık optimize sorgular gönderilir.
        private void tbxSearchInCompleted_TextChanged(object sender, EventArgs e) => BringAndSearchCompleted();
        private void tbxSearchInNotCompleted_TextChanged(object sender, EventArgs e) => BringAndSearchNotCompleted();
    }
}
