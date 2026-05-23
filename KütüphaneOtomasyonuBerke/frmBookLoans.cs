using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmBookLoans : Form
    {
        int _selectedBookId = 0;
        int _selectedMemberId = 0;
        Timer timer = new Timer();

        public frmBookLoans()
        {
            InitializeComponent();
        }

        private void frmBookLoans_Load(object sender, EventArgs e)
        {
            // Kitaplar tablosu ayarları
            dgwBooks.ReadOnly = true;
            dgwBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwBooks.AllowUserToAddRows = false;

            // Üyeler tablosu ayarları
            dgwMember.ReadOnly = true;
            dgwMember.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwMember.AllowUserToAddRows = false;
            BringAndSearchBooks();
            BringAndSearchMember();
            ChangeStatusOfControllers();
            BilgiKutusu();
            TimerAyarlari();
        }

        void BilgiKutusu()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
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

        void TimerAyarlari()
        {
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                label14.Text = DateTime.Now.ToString("ddd") + " " + DateTime.Now.ToString("MMM") + " " + DateTime.Now.ToString("yyyy");
                label15.Text = DateTime.Now.ToString("HH:mm");
            };
            timer.Start();
        }

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

        private void ChangeStatusOfControllers()
        {
            foreach (Control item in gbxBooks.Controls) if (item is TextBox) item.Enabled = false;
            foreach (Control item in gbxMembers.Controls) if (item is TextBox) item.Enabled = false;
        }

        private void dgwBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgwBooks.CurrentRow;
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
                _selectedMemberId = 0;
                tbxFirstName.Clear();
            }
        }

        private void btnProcesDone_Click(object sender, EventArgs e)
        {
            if (_selectedMemberId == 0 || _selectedBookId == 0)
            {
                MessageBox.Show("Lütfen önce listeden bir üye ve bir kitap seçin!");
                return;
            }

            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Güncel Stok Kontrolü
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

                        if (currentStock <= 0)
                        {
                            MessageBox.Show("Seçilen kitabın stoku tükenmiştir! Ödünç verilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            trans.Rollback();
                            return;
                        }

                        // 2. Ödünç Kaydı Ekleme
                        string sql = "INSERT INTO BookLoans (UserId, BookId, LoanDate, DueDate, Status) VALUES (@u, @b, @l, @d, 1)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@u", _selectedMemberId);
                            cmd.Parameters.AddWithValue("@b", _selectedBookId);
                            cmd.Parameters.AddWithValue("@l", DateTime.Now);
                            cmd.Parameters.AddWithValue("@d", dtpDueDate.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Stoktan 1 Düşürme İşlemi
                        string updateStockSql = "UPDATE Books SET QuantityInStocks = QuantityInStocks - 1 WHERE BookId = @b";
                        using (SqlCommand cmdUpdateStock = new SqlCommand(updateStockSql, conn, trans))
                        {
                            cmdUpdateStock.Parameters.AddWithValue("@b", _selectedBookId);
                            cmdUpdateStock.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("İşlem başarılı. Kitap ödünç verildi ve stok düşüldü.");

                        BilgiKutusu();
                        BringAndSearchMember();
                        BringAndSearchBooks(); // Listeyi yenileyelim ki yeni stok miktarı ekranda görünsün
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void btnStateOfDue_Click(object sender, EventArgs e) => new frmStateOfDue().ShowDialog();
        private void tbxSearchBook_TextChanged(object sender, EventArgs e) => BringAndSearchBooks();
        private void tbxSearchMembers_TextChanged(object sender, EventArgs e) => BringAndSearchMember();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form frmMainInstance = Application.OpenForms["frmMain"];
            if (frmMainInstance != null)
            {
                frmMainInstance.Show();
            }
            this.Close();
        }
    }
}