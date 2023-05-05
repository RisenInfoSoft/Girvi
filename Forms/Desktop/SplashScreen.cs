using Girvi.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Forms.Desktop
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            SplashTimer.Enabled = true;
            SplashTimer.Interval = 1000;
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            Instance.user = clsInitializationModule.initializeApplication(this);
            if (Instance.user == null)
            {
                clsActivation.stopSqlService();
                Environment.Exit(0);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
