using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        private void btnGiriş_Click(object sender, EventArgs e)
        {

            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            if (username.Trim().Length == 0 || password.Trim().Length == 0 || username.Contains(" ") || password.Contains(" ") || username.Length < 3 || username.Length > 49 || password.Length > 49)  
            {
                MessageBox.Show("Hatalı giriş şekli. Lütfen en az 3 karakter giriniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                using (SqlConnection connection = SqlCon.Connect())
                {
                    connection.Open();

                    string queryForLogin = "SELECT TOP (1) au.UserId as UserId, ur.RoleId as RoleId, ar.RoleName as RoleName, au.FirstName + ' '+ au.LastName as FullName FROM AppUsers au\r\nINNER JOIN UserRoles ur\r\nON au.UserId=ur.UserId\r\nINNER JOIN AppRoles ar\r\nON ar.RoleId=ur.RoleId\r\nWHERE Username = @username AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(queryForLogin, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", tbxUsername.Text);
                        cmd.Parameters.AddWithValue("@password", tbxPassword.Text);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                int UserId = Convert.ToInt32(dr["UserId"]);
                                int roleıd = Convert.ToInt32(dr["RoleId"]);
                                string roleName= dr["RoleName"].ToString();
                                string fullname = dr["FullName"].ToString();

                                Session.ActiveRoleId = roleıd;
                                Session.ActiveRoleName = roleName;
                                Session.ActiveUserId = UserId;
                                Session.ActiveUserName = fullname;

                                MessageBox.Show($"Hoşgeldiniz, {fullname}.\n{roleıd} - {roleName}","Başarılı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Information);

                                frmMain main = new frmMain();
                                main.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Başarısız Giriş");
                            }
                        }

                    }
                }
            }
        }

        private void FrmGiriş_Load(object sender, EventArgs e)
        {
            
        }
    }
}
