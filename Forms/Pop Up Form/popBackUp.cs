using Girvi.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Forms.Pop_Up_Form
{
    public partial class popBackUp : Form
    {
        Boolean isclose = false;
        public popBackUp(Boolean close = false)
        {
            InitializeComponent();
            this.isclose = close;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = 100;
            progressBar2.Minimum = 1;
            progressBar2.Maximum = 100;
            btnBrowse.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = folderDialog.SelectedPath;
                    txtDirectory.Text = path;
                }
            }
        }

        private void BtnBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCreate.Focus();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if(txtDirectory.Text != "")
            {
                if (Helper.MyCStr(Instance.Backup_Directory) == "")
                    Instance.Backup_Directory = txtDirectory.Text;
                if (getBack())
                    this.Dispose();
            }
            else
            {
                MessageBox.Show("Please browse you Directory...");
                btnBrowse.Focus();
            }
        }

        private Boolean getBack()
        {
            if (isclose)
            {
                try
                {
                    backgroundWorker1.RunWorkerAsync();

                    string SourcePath = "data";
                    string Mypath = Path.GetFullPath(".\\");
                    string[] DestinationPathArray = Mypath.Split(';');

                    foreach (String DestinationPathItem in DestinationPathArray)
                    {
                        String path = "";
                        try
                        {
                            foreach (DriveInfo drive in DriveInfo.GetDrives().Where(d => d.IsReady))
                            {
                                Application.DoEvents();
                                if (drive.RootDirectory.Name.Split(':')[0] == DestinationPathItem.Split(':')[0])
                                {
                                    Application.DoEvents();
                                    String DestinationPath = DestinationPathItem + "BackUp" + "\\" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "\\mysqldata";
                                    System.IO.Directory.CreateDirectory(DestinationPath);
                                    foreach (string dirPath in System.IO.Directory.GetDirectories(SourcePath, "*", System.IO.SearchOption.AllDirectories))
                                    {
                                        path = dirPath.Replace(SourcePath, DestinationPath);
                                        System.IO.Directory.CreateDirectory(path);
                                        Application.DoEvents();
                                    }
                                    foreach (string newPath in System.IO.Directory.GetFiles(SourcePath, "*.*", System.IO.SearchOption.AllDirectories))
                                    {
                                        path = newPath.Replace(SourcePath, DestinationPath);
                                        if (Directory.Exists(DestinationPath))
                                        {
                                            System.IO.File.Delete(path);
                                            System.IO.File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
                                            Application.DoEvents();
                                        }
                                        else
                                        {
                                            System.IO.File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
                                            Application.DoEvents();
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e) { MessageBox.Show(e.Message + " " + path); }
                    }
                    int val1 = progressBar2.Value;
                    if (val1 < 100)
                    {
                        progressBar2.Value = 100;

                        lblPB2.Text = " 100%";
                        Application.DoEvents();
                    }
                    return true;
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
            else
            {
                try
                {
                    backgroundWorker1.RunWorkerAsync();
                    string SourcePath = "data";
                    string[] DestinationPathArray = Instance.Backup_Directory.Split(';');
                    foreach (String DestinationPathItem in DestinationPathArray)
                    {
                        Application.DoEvents();
                        //bgw_RunWorkerCompleted(null, null);
                        if (!Directory.Exists(DestinationPathItem))
                        {
                            DialogResult result = MessageBox.Show("'" + DestinationPathItem + "' path doesn't exist \nDo you want to create this folder ?", "", MessageBoxButtons.YesNo);
                            if (result == System.Windows.Forms.DialogResult.Yes)
                                Directory.CreateDirectory(Instance.Backup_Directory);
                            else
                                return false;
                        }
                        String path = "";
                        try
                        {
                            foreach (DriveInfo drive in DriveInfo.GetDrives().Where(d => d.IsReady))
                            {
                                Application.DoEvents();
                                if (drive.RootDirectory.Name.Split(':')[0] == DestinationPathItem.Split(':')[0])
                                {
                                    Application.DoEvents();
                                    String DestinationPath = DestinationPathItem + "\\" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "\\data";
                                    System.IO.Directory.CreateDirectory(DestinationPath);
                                    foreach (string dirPath in System.IO.Directory.GetDirectories(SourcePath, "*", System.IO.SearchOption.AllDirectories))
                                    {
                                        path = dirPath.Replace(SourcePath, DestinationPath);
                                        System.IO.Directory.CreateDirectory(path);
                                        Application.DoEvents();
                                    }
                                    foreach (string newPath in System.IO.Directory.GetFiles(SourcePath, "*.*", System.IO.SearchOption.AllDirectories))
                                    {
                                        path = newPath.Replace(SourcePath, DestinationPath);
                                        System.IO.File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
                                        Application.DoEvents();
                                    }
                                }
                            }
                        }
                        catch (Exception e) { MessageBox.Show(e.Message + " " + path); }
                    }

                    int val1 = progressBar2.Value;
                    if (val1 < 100)
                    {
                        progressBar2.Value = 100;
                        Application.DoEvents();
                        lblPB2.Text = " 100%";
                    }
                    if (isclose == false)
                        MessageBox.Show("Data Successfully BackedUp");
                    return true;
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
            return true;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 80; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(5);
                // Report progress.
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
            lblPB2.Text = e.ProgressPercentage.ToString() + "%";
            lblPB2.Refresh();
        }
    }
}
