using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmBooks : Form
    {
        private int _selectedBookId;
        private int _selectedAuthorId;

        public frmBooks()
        {
            InitializeComponent();
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            BringAndSearchDatas();
            ListAuthors();
        }

        public void BringAndSearchDatas()
        {
            try
            {
                using (SqlConnection conn = SqlCon.Connect())
                {
                    conn.Open();
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
                        cmd.Parameters.AddWithValue("@Words", "%" + tbxSearchBook.Text + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgwBooks.DataSource = dt;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

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
                        cbxAuthorName.DataSource = dt;
                        cbxAuthorName.DisplayMember = "FullName";
                        cbxAuthorName.ValueMember = "AuthorId";
                    }
                }
            }
        }

        private void dgwBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedBookId = Convert.ToInt32(dgwBooks.Rows[e.RowIndex].Cells["Id"].Value);
                _selectedAuthorId = Convert.ToInt32(dgwBooks.Rows[e.RowIndex].Cells["AuthorId"].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedBookId > 0)
            {
                frmUpdateBooks updateForm = new frmUpdateBooks(_selectedBookId, _selectedAuthorId);
                updateForm.ShowDialog();
                BringAndSearchDatas();
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
                        SqlCommand cmd = new SqlCommand("UPDATE Books SET Status = 0 WHERE BookId = @id", conn);
                        cmd.Parameters.AddWithValue("@id", _selectedBookId);
                        cmd.ExecuteNonQuery();
                    }
                    BringAndSearchDatas();
                }
            }
            else MessageBox.Show("Lütfen bir kitap seçin.");
        }

        private void btnInsertBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxBookName.Text) || cbxAuthorName.SelectedValue == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string qBook = @"INSERT INTO Books (BookName, PublisherName, PageCount, QuantityInStocks, Status) 
                                     VALUES (@name, @pub, @page, @stock, 1); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdB = new SqlCommand(qBook, conn, trans);
                    cmdB.Parameters.AddWithValue("@name", tbxBookName.Text);
                    cmdB.Parameters.AddWithValue("@pub", tbxPublisher.Text);
                    cmdB.Parameters.AddWithValue("@page", numPageCount.Text);
                    cmdB.Parameters.AddWithValue("@stock", numStock.Text);

                    int newBookId = Convert.ToInt32(cmdB.ExecuteScalar());

                    string qRel = "INSERT INTO BookAuthors (BookId, AuthorId) VALUES (@bId, @aId)";
                    SqlCommand cmdRel = new SqlCommand(qRel, conn, trans);
                    cmdRel.Parameters.AddWithValue("@bId", newBookId);
                    cmdRel.Parameters.AddWithValue("@aId", cbxAuthorName.SelectedValue);
                    cmdRel.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Kitap başarıyla eklendi.");
                    BringAndSearchDatas();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnKitapGeri_Click(object sender, EventArgs e)
        {
            new frmMain().Show();
            this.Close();
        }

        private void tbxSearchBook_TextChanged(object sender, EventArgs e) => BringAndSearchDatas();
    }
}