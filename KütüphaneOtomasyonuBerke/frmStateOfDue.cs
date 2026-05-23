using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmStateOfDue : Form
    {
        int _selectedLoanId = 0;

        public frmStateOfDue()
        {
            InitializeComponent();
        }

        private void frmStateOfDue_Load(object sender, EventArgs e)
        {
            // Teslim edilmeyenler tablosu ayarları
            dgwNotCompletedReturns.ReadOnly = true;
            dgwNotCompletedReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwNotCompletedReturns.AllowUserToAddRows = false;

            // Teslim edilenler tablosu ayarları
            dgwCompletedReturns.ReadOnly = true;
            dgwCompletedReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwCompletedReturns.AllowUserToAddRows = false;
            ListeleriYenile();
        }

        void BringAndSearchCompleted()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                string query = @"SELECT bl.LoanId, au.FirstName, au.LastName, au.IdentityNumber, b.BookName, b.PublisherName, bl.LoanDate, bl.DueDate, bl.ReturnDate 
                                 FROM BookLoans bl
                                 INNER JOIN AppUsers au ON au.UserId = bl.UserId
                                 INNER JOIN Books b ON b.BookId = bl.BookId 
                                 WHERE bl.Status = 0 
                                 AND (au.FirstName + ' ' + au.LastName LIKE @key OR au.IdentityNumber LIKE @key OR b.BookName LIKE @key)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@key", "%" + tbxSearchInCompleted.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgwCompletedReturns.DataSource = dt;
                }
            }
        }

        void BringAndSearchNotCompleted()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
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

        void ListeleriYenile()
        {
            BringAndSearchCompleted();
            BringAndSearchNotCompleted();
        }

        private void dgwNotCompletedReturns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgwNotCompletedReturns.Rows.Count) return;

            DataGridViewRow row = dgwNotCompletedReturns.Rows[e.RowIndex];

            if (row.Cells["LoanId"].Value != null && row.Cells["LoanId"].Value != DBNull.Value)
            {
                _selectedLoanId = Convert.ToInt32(row.Cells["LoanId"].Value);

                tbxFirstName.Text = row.Cells["FirstName"].Value?.ToString() ?? "";
                tbxLastName.Text = row.Cells["LastName"].Value?.ToString() ?? "";
                tbxBookName.Text = row.Cells["BookName"].Value?.ToString() ?? "";
                tbxDueDate.Text = row.Cells["DueDate"].Value?.ToString() ?? "";
                tbxLoanDate.Text = row.Cells["LoanDate"].Value?.ToString() ?? "";
            }
            else
            {
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
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Ödünç Kaydını Güncelle (Kapat)
                            string query = "UPDATE BookLoans SET Status = 0, ReturnDate = @ret WHERE LoanId = @id";
                            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@ret", DateTime.Now);
                                cmd.Parameters.AddWithValue("@id", _selectedLoanId);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. İade Edilen Kitabın Stoğunu Veritabanında 1 Artır
                            string stockQuery = "UPDATE Books SET QuantityInStocks = QuantityInStocks + 1 WHERE BookId = (SELECT BookId FROM BookLoans WHERE LoanId = @id)";
                            using (SqlCommand cmdStock = new SqlCommand(stockQuery, conn, trans))
                            {
                                cmdStock.Parameters.AddWithValue("@id", _selectedLoanId);
                                cmdStock.ExecuteNonQuery();
                            }

                            trans.Commit();
                            MessageBox.Show("İade işlemi başarıyla tamamlandı ve kitap stoğu artırıldı.");

                            ListeleriYenile();
                            _selectedLoanId = 0;

                            tbxFirstName.Clear();
                            tbxLastName.Clear();
                            tbxBookName.Clear();
                            tbxDueDate.Clear();
                            tbxLoanDate.Clear();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("İade işlemi sırasında hata oluştu: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void tbxSearchInCompleted_TextChanged(object sender, EventArgs e) => BringAndSearchCompleted();
        private void tbxSearchInNotCompleted_TextChanged(object sender, EventArgs e) => BringAndSearchNotCompleted();
    }
}