using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmUpdateBooks : Form
    {
        private int _selectedBookId, _selectedAuthorId;

        public frmUpdateBooks(int selectedBookId, int selectedAuthorId)
        {
            InitializeComponent();
            _selectedBookId = selectedBookId;
            _selectedAuthorId = selectedAuthorId;
        }

        private void frmUpdateBooks_Load(object sender, EventArgs e)
        {
            ListAuthors();
            BringAllDatasToForm();
        }

        void ListAuthors()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                string query = "SELECT AuthorId, FirstName + ' ' + LastName AS FullName FROM Authors";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbxAuthorName.DataSource = dt;
                    cbxAuthorName.DisplayMember = "FullName";
                    cbxAuthorName.ValueMember = "AuthorId";
                }
            }
        }

        void BringAllDatasToForm()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                string query = "SELECT * FROM Books WHERE BookId = @bookId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookId", _selectedBookId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            tbxBookName.Text = dr["BookName"].ToString();
                            tbxPublisher.Text = dr["PublisherName"].ToString();

                            if (dr["ReleasedDate"] != DBNull.Value)
                                dtpReleasedDate.Value = Convert.ToDateTime(dr["ReleasedDate"]);
                            else
                                dtpReleasedDate.Value = DateTime.Now;

                            numPageCount.Value = Convert.ToInt16(dr["PageCount"]);
                            numStock.Value = Convert.ToInt16(dr["QuantityInStocks"]);

                            bool status = dr["Status"] != DBNull.Value && Convert.ToBoolean(dr["Status"]);
                            rbNotDeleted.Checked = status;
                            rbDeleted.Checked = !status;

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
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
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
                            cmd.Parameters.AddWithValue("@mod", DateTime.Now);
                            cmd.Parameters.AddWithValue("@id", _selectedBookId);
                            cmd.ExecuteNonQuery();
                        }

                        string queryAuth = "UPDATE BookAuthors SET AuthorId = @aid WHERE BookId = @bid";
                        using (SqlCommand cmdA = new SqlCommand(queryAuth, conn, trans))
                        {
                            cmdA.Parameters.AddWithValue("@aid", cbxAuthorName.SelectedValue);
                            cmdA.Parameters.AddWithValue("@bid", _selectedBookId);
                            cmdA.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Başarıyla güncellendi.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}