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
    public partial class frmClsMsgBox : Form
    {
        Boolean Parent_form = false;
        public frmClsMsgBox(Boolean Parent = false)
        {
            InitializeComponent();
            this.Parent_form = Parent;

            if (Parent_form == true)
                lbl_msg.Text = "Do you want to close the application?";
            else
                lbl_msg.Text = "Do you want to close the form?";

           btn_yes.Focus();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
