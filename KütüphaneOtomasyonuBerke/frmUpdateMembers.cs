using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KütüphaneOtomasyonuBerke
{
    public partial class frmUpdateMembers : Form
    {
        int _selectedUserId;

        public frmUpdateMembers(int selectedUserId)
        {
            InitializeComponent();
            _selectedUserId = selectedUserId;
        }

        private void frmUpdateMembers_Load(object sender, EventArgs e)
        {
            LoadDatas();
        }

        private void LoadDatas()
        {
            using (SqlConnection conn = SqlCon.Connect())
            {
                conn.Open();
                string query = "SELECT FirstName, LastName, IdentityNumber, BirthDate, Gender, Username, Password FROM AppUsers WHERE UserId = @userId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", _selectedUserId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            tbxFirstName.Text = dr["FirstName"].ToString();
                            tbxLastName.Text = dr["LastName"].ToString();
                            tbxIdentityNumber.Text = dr["IdentityNumber"].ToString();
                            dtpBirthDate.Value = Convert.ToDateTime(dr["BirthDate"]);
                            rbMan.Checked = Convert.ToBoolean(dr["Gender"]);
                            rbWoman.Checked = !rbMan.Checked;
                            tbxUserName.Text = dr["Username"].ToString();
                            tbxPassword.Text = dr["Password"].ToString();
                        }
                    }
                }

                string roleQuery = "SELECT RoleId FROM UserRoles WHERE UserId = @userId";
                using (SqlCommand cmdRole = new SqlCommand(roleQuery, conn))
                {
                    cmdRole.Parameters.AddWithValue("@userId", _selectedUserId);
                    using (SqlDataReader drRole = cmdRole.ExecuteReader())
                    {
                        chkSuperAdmin.Checked = chkAdmin.Checked = chkMember.Checked = false;
                        while (drRole.Read())
                        {
                            int rId = Convert.ToInt32(drRole["RoleId"]);
                            if (rId == 1) chkSuperAdmin.Checked = true;
                            if (rId == 2) chkAdmin.Checked = true;
                            if (rId == 3) chkMember.Checked = true;
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProcess();
        }

        private void UpdateProcess()
        {
            try
            {
                using (SqlConnection conn = SqlCon.Connect())
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            string updateSql = @"UPDATE AppUsers SET FirstName=@fn, LastName=@ln, IdentityNumber=@id, 
                                                 BirthDate=@bd, Gender=@g, Username=@un, Password=@pw WHERE UserId=@uid";

                            using (SqlCommand cmd = new SqlCommand(updateSql, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@uid", _selectedUserId);
                                cmd.Parameters.AddWithValue("@fn", tbxFirstName.Text);
                                cmd.Parameters.AddWithValue("@ln", tbxLastName.Text);
                                cmd.Parameters.AddWithValue("@id", tbxIdentityNumber.Text);
                                cmd.Parameters.AddWithValue("@bd", dtpBirthDate.Value);
                                cmd.Parameters.AddWithValue("@g", rbMan.Checked);
                                cmd.Parameters.AddWithValue("@un", tbxUserName.Text);
                                cmd.Parameters.AddWithValue("@pw", tbxPassword.Text);
                                cmd.ExecuteNonQuery();
                            }

                            List<int> newRoles = new List<int>();
                            if (chkSuperAdmin.Checked) newRoles.Add(1);
                            if (chkAdmin.Checked) newRoles.Add(2);
                            if (chkMember.Checked) newRoles.Add(3);

                            using (SqlCommand cmdDel = new SqlCommand("DELETE FROM UserRoles WHERE UserId=@uid", conn, trans))
                            {
                                cmdDel.Parameters.AddWithValue("@uid", _selectedUserId);
                                cmdDel.ExecuteNonQuery();
                            }

                            foreach (int roleId in newRoles)
                            {
                                using (SqlCommand cmdIns = new SqlCommand("INSERT INTO UserRoles (UserId, RoleId) VALUES (@uid, @rid)", conn, trans))
                                {
                                    cmdIns.Parameters.AddWithValue("@uid", _selectedUserId);
                                    cmdIns.Parameters.AddWithValue("@rid", roleId);
                                    cmdIns.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();
                            MessageBox.Show("Başarıyla güncellendi!");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("HATA: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Bağlantı Hatası: " + ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}