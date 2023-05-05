using Girvi.Classes;
using Girvi.Forms.Master_Form;
using Girvi.Forms.Pop_Up_Form;
using Girvi.Forms.View;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Girvi.Forms.Desktop
{
    public partial class frmdesktop : Form
    {
        private int childFormNumber = 0;

        public frmdesktop()
        {
            InitializeComponent();
            SplashScreen splashObj = new SplashScreen();
            splashObj.ShowDialog();
            Instance.initializeMap();
            Text = "Girvi";

            if (Instance.isDemoVersion)
                lblDemo.Visible = true;
            else
                lblDemo.Visible = false;

        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountMaster frm = new frmAccountMaster();
            Common.ShowForm(frm);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClsMsgBox frm = new frmClsMsgBox(Parent:true);
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.Yes)
            {
                clsActivation.stopSqlService();
                Environment.Exit(0);
                this.Close();
            }
        }

        private void partyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPartyList frm = new frmPartyList();
            frm.Show();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem.PerformClick();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemMaster frm = new frmItemMaster();
            frm.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGirviReceive frm = new frmGirviReceive();
            Common.ShowForm(frm);
        }

        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmItemList frm = new frmItemList();
            //frm.ShowDialog();
        }
       
        private void Timer_Tick(object sender, EventArgs e)
        {
            txt_time.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            frmGirviReceive frm = new frmGirviReceive();
            Common.ShowForm(frm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //rptAccountBalance rpt = new rptAccountBalance();
            //Common.ShowForm(rpt);
        }

        private void Frmdesktop_Load(object sender, EventArgs e)
        {
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword pop = new frmChangePassword();
            Common.ShowForm(pop);
        }

        private void BackUp_Click(object sender, EventArgs e)
        {
            popBackUp pop = new popBackUp();
            Common.ShowForm(pop);
        }

        private void ContrallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popController pop = new popController();
            pop.Show();
        }
    }
}
