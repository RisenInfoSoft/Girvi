using Girvi.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Forms.Pop_Up_Form
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
            bindLoginId();
            cmbLoginId.Focus();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindLoginId()
        {
            string getId = "Select userid From " + TableNames.Users;
            DataTable dt = Helper.getTable(getId);
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbLoginId.DataSource = dt;
                cmbLoginId.DisplayMember = "userid";
                cmbLoginId.ValueMember = "userid";
                cmbLoginId.SelectedIndex = 0;
            }
                
        }

        private void CmbLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOldPassword.Focus();
        }

        private void TxtOldPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNewPassword.Focus();
        }

        private void TxtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnChange.Focus();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            string logId = Helper.MyCStr(cmbLoginId.SelectedValue);
            string oldPass = Helper.MyCStr(txtOldPassword.Text);
            string newPass = Helper.MyCStr(txtNewPassword.Text);
            string getOldPass = "Select password From " + TableNames.Users + " Where userid = '" + logId + "'";

            try
            {
                DataTable dtOldPass = Helper.getTable(getOldPass);
                if (dtOldPass != null)
                {
                    string pass = Helper.MyCStr(dtOldPass.Rows[0][0]);
                    if (oldPass.Trim() == pass.Trim())
                    {
                        if (newPass != "")
                        {
                            NpgsqlConnection con = Helper.getConnection();
                            NpgsqlTransaction trans = con.BeginTransaction();
                            ColumnDataCollection col = new ColumnDataCollection();

                            col.Add("userid", logId);
                            col.Add("password", newPass);

                            Helper.UpdateTable(TableNames.Users, col, RSAUpdateTableType.Update, "userid = '" + logId + "'", con, trans);
                            MessageBox.Show("Password Changed Successfully...");
                            trans.Commit();
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Please fill the New Password...");
                            txtNewPassword.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old Password is incorrect...");
                        txtOldPassword.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
                txtNewPassword.PasswordChar = '\0';
            else
                txtNewPassword.PasswordChar = '*';
        }
    }
}
