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
            lblRoleName.Text= Session.ActiveRoleName.ToString();
            lblUserName.Text= Session.ActiveUserName.ToString();

            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 70, 229); 
            btnBooks.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202); 

            btnMembers.FlatStyle = FlatStyle.Flat;
            btnMembers.FlatAppearance.BorderSize = 0;
            btnMembers.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 70, 229);
            btnMembers.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);

            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 70, 229);
            btnBack.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);


            btnLoans.FlatStyle = FlatStyle.Flat;
            btnLoans.FlatAppearance.BorderSize = 0;
            btnLoans.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 70, 229);
            btnLoans.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);

        }




        private void btnBooks_Click(object sender, EventArgs e)
        {
            frmBooks books = new frmBooks();
            books.Show();
            this.Hide();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            frmMembers members = new frmMembers();
            members.Show(); this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmGiriş frmGirişForm = new FrmGiriş();
            frmGirişForm.Show();
            this.Close();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            frmBookLoans loans = new frmBookLoans();
            loans.Show();
            this.Hide();
        }
    }
}
