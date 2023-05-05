using Girvi.Forms.Pop_Up_Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Classes
{
    class clsInitializationModule
    {
        public static clsUser initializeApplication(Form parent)
        {
            clsConnection connection = new clsConnection();
            connection.getFromFile();
            if (Instance.pgsql_host == "localhost")
                clsActivation.startSqlService();

            frmLoginPopup frm = new frmLoginPopup();
            frm.ShowDialog(parent);
            if (frm.DialogResult == DialogResult.OK)
            {
                return frm.user;
            }
            return null;

        }

    }
}
