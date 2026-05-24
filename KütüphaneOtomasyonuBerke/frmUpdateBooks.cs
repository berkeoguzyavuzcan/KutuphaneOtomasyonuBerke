using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmUpdateBooks : Form
    {
        // Sınıf Seviyesinde Kapsüllenmiş Değişkenler (Private Fields):
        // Diğer formlardan (örneğin ana listeden) parametre olarak gelen ve güncellenecek olan 
        // Kitap ID ve Yazar ID bilgileri form genelinde kullanılmak üzere RAM belleğe alınır.
        private int _selectedBookId, _selectedAuthorId;

        // Nesne Yönelimli Programlama (OOP) - Aşırı Yüklenmiş Yapıcı Metot (Parameterized Constructor):
        // Form ayağa kaldırılırken güncellenecek kayda ait benzersiz anahtarların (Primary Key) zorunlu olarak geçilmesi sağlanır.
        public frmUpdateBooks(int selectedBookId, int selectedAuthorId)
        {
            InitializeComponent();
            _selectedBookId = selectedBookId;
            _selectedAuthorId = selectedAuthorId;
        }

        private void frmUpdateBooks_Load(object sender, EventArgs e)
        {
            // Veri hazırlığı ve form senkronizasyonu başlatılır.
            ListAuthors();          // İlişkisel ComboBox içeriğini doldurur.
            BringAllDatasToForm();  // Güncellenecek mevcut verileri veritabanından çekip form nesnelerine basar.
        }

        /// <summary>
        /// Yazarları ComboBox Nesnesine Bağlama Metodu (Data Binding Engine):
        /// İlişkisel veritabanındaki tüm yazarları çekerek kullanıcı dostu bir arayüz seçimi hazırlar.
        /// </summary>
        void ListAuthors()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                // SQL String Concatenation: Ad ve Soyad alanları SQL tarafında birleştirilerek tek bir alan haline getirilir.
                string query = "SELECT AuthorId, FirstName + ' ' + LastName AS FullName FROM Authors";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Bağlantısız katman nesneleriyle ComboBox veri yüklemesi (Data Binding) gerçekleştirilir.
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbxAuthorName.DataSource = dt;
                    cbxAuthorName.DisplayMember = "FullName"; // Kullanıcının ekranda göreceği metin alanı.
                    cbxAuthorName.ValueMember = "AuthorId";   // Arka planda kodun işleyeceği benzersiz kimlik (ID) değeri.
                }
            }
        }

        /// <summary>
        /// Mevcut Verileri Form Alanlarına Doldurma Metodu:
        /// Seçilen kitabın güncel bilgilerini 'SqlDataReader' (Connected Layer) ile satır satır okur.
        /// </summary>
        void BringAllDatasToForm()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                string query = "SELECT * FROM Books WHERE BookId = @bookId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // SQL Injection Önlemi: Parametrik sorgu tasarımı.
                    cmd.Parameters.AddWithValue("@bookId", _selectedBookId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // İlgili ID'ye ait bir kayıt bulunduysa okuma işlemi başlar (Forward-Only, Read-Only).
                        if (dr.Read())
                        {
                            tbxBookName.Text = dr["BookName"].ToString();
                            tbxPublisher.Text = dr["PublisherName"].ToString();

                            // Defansif Programlama (Null Check): Veritabanında yayın tarihi boş (Null) bırakılmışsa 
                            // uygulamanın çökmesini önlemek için DBNull kontrolü yapılır.
                            if (dr["ReleasedDate"] != DBNull.Value)
                                dtpReleasedDate.Value = Convert.ToDateTime(dr["ReleasedDate"]);
                            else
                                dtpReleasedDate.Value = DateTime.Now; // Boşsa bugünün tarihini varsayılan atar.

                            // Veri Tipi Dönüşümleri (Type Casting): Tinyint veya Smallint değerler uygun veri tiplerine cast edilir.
                            numPageCount.Value = Convert.ToInt16(dr["PageCount"]);
                            numStock.Value = Convert.ToInt16(dr["QuantityInStocks"]);

                            // Mantıksal Durum Yönetimi (Boolean State Management):
                            // Kitabın aktiflik durumu okunur ve RadioButton nesneleri otomatik olarak işaretlenir.
                            bool status = dr["Status"] != DBNull.Value && Convert.ToBoolean(dr["Status"]);
                            rbNotDeleted.Checked = status;
                            rbDeleted.Checked = !status;

                            // ComboBox Seçim Senkronizasyonu: Parametre gelen Yazar ID ComboBox'ın seçili değeri yapılır.
                            cbxAuthorName.SelectedValue = _selectedAuthorId;
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();

                // ACID Prensipleri ve Veri Tutarlılığı (Data Consistency):
                // Kitap güncelleme işlemi hem 'Books' tablosunu hem de yazar ilişkisini tutan 'BookAuthors' tablosunu etkiler.
                // İki aşamalı bu operasyonun bütünlüğü için 'SqlTransaction' mimarisi devreye alınır.
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. AŞAMA: Ana Kitap Tablosunun Güncellenmesi (UPDATE Books)
                        // Kitaba ait temel öznitelikler ve sistem takip alanı olan 'ModifiedDate' (Güncellenme Tarihi) SQL'e gönderilir.
                        string query = @"UPDATE Books SET BookName = @name, PublisherName = @pub, ReleasedDate = @date, 
                                         PageCount = @page, QuantityInStocks = @stock, Status = @status, ModifiedDate = @mod 
                                         WHERE BookId = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@name", tbxBookName.Text);
                            cmd.Parameters.AddWithValue("@pub", tbxPublisher.Text);
                            cmd.Parameters.AddWithValue("@date", dtpReleasedDate.Value);
                            cmd.Parameters.AddWithValue("@page", (int)numPageCount.Value);
                            cmd.Parameters.AddWithValue("@stock", (int)numStock.Value);
                            cmd.Parameters.AddWithValue("@status", rbNotDeleted.Checked);
                            cmd.Parameters.AddWithValue("@mod", DateTime.Now); // Loglama ve veri takibi için anlık zaman damgası.
                            cmd.Parameters.AddWithValue("@id", _selectedBookId);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. AŞAMA: Çoktan-Çoğa (Many-to-Many) İlişkisel Ara Tablonun Güncellenmesi (UPDATE BookAuthors)
                        // Kitabın değişen yazarı, ilişkisel bütünlüğü korumak adına ara tabloda (Bridge Table) güncellenir.
                        string queryAuth = "UPDATE BookAuthors SET AuthorId = @aid WHERE BookId = @bid";
                        using (SqlCommand cmdA = new SqlCommand(queryAuth, conn, trans))
                        {
                            cmdA.Parameters.AddWithValue("@aid", cbxAuthorName.SelectedValue);
                            cmdA.Parameters.AddWithValue("@bid", _selectedBookId);
                            cmdA.ExecuteNonQuery();
                        }

                        // Her iki komut da hatasız icra edildiyse transaction kalıcı olarak onaylanır (Commit).
                        trans.Commit();
                        MessageBox.Show("Başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // Rollback Mekanizması: Adımlardan biri başarısız olursa veriler eski kararlı durumuna geri sarılır.
                        // Böylece kitabın güncellenip yazar ilişkisinin eski kalması gibi senkronizasyon hataları engellenir.
                        trans.Rollback();
                        MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kullanıcı Onay Bariyeri (UI Confirmation Check): Yanlışlıkla tıklamalara karşı güvenlik kontrolü.
            if (MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = SqlCon.Connect())
                {
                    conn.Open();

                    // SOFT-DELETE (Mantıksal Silme) MİMARİSİ:
                    // Kurumsal projelerde veri kaybını önlemek ve geçmiş ödünç hareketlerinin ilişkisel veri bütünlüğünü korumak için 
                    // 'DELETE' komutu yerine 'UPDATE' komutu ile durum kolonu pasife (Status = 0) çekilir.
                    SqlCommand cmd = new SqlCommand("UPDATE Books SET Status = 0 WHERE BookId = @id", conn);
                    cmd.Parameters.AddWithValue("@id", _selectedBookId);
                    cmd.ExecuteNonQuery();
                }
                this.Close();
            }
        }

        // Formu Kapatma ve Belleği Serbest Bırakma Operasyonu
        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
