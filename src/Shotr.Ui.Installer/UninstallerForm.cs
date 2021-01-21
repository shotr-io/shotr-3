using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MetroFramework5.Forms;
using Microsoft.Win32;

namespace Shotr.Ui.Installer
{
    public partial class UninstallerForm : MetroForm
    {
        public UninstallerForm()
        {
            InitializeComponent();

            //Hide all panels
            step2GroupPanel.Hide();
            step3GroupPanel.Hide();         
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Utils.Utils.r = new Random(Environment.TickCount);
        }

        #region Step 1
        private void step1NextButton_Click(object sender, EventArgs e)
        {
            step1GroupPanel.Hide();
            step2GroupPanel.Show();
            Uninstall();
        }

        private void step1CancelButton_Click(object sender, EventArgs e)
        {
            new CancelForm().ShowDialog();
        }
        #endregion

        #region Step 2
        private void step3BackButton_Click(object sender, EventArgs e)
        {
            step3GroupPanel.Hide();
            step2GroupPanel.Show();
        }
        private string location;
        private void Uninstall()
        {
            //make sure if it exists, kill them.
            foreach (var m in Process.GetProcessesByName("Shotr"))
            {
                m.Kill();
                Thread.Sleep(500);
            }
            //Delete Shotr folder.
            SetInstallStatusText("Removing folders...");
            var Install_Reg_Loc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

            var hKey = (Registry.LocalMachine).OpenSubKey(Install_Reg_Loc, true);
            var appKey = hKey.OpenSubKey("Shotr");
            location = (string)appKey.GetValue("InstallLocation");
            appKey.Close();
            hKey.Close();

            try
            {
                Directory.Delete(location, true);
            }
            catch { }
            SetInstallStatusText("Removing install entry...");

            //removing any desktop icons.
            try 
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Shotr.lnk");  
            }
            catch{}

            try
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Shotr - Capture.lnk");
            }
            catch
            { }

            try
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Shotr - Record.lnk");
            }
            catch { }
            
            //Uninstall.
            RemoveControlPanelProgram("Shotr");

            SetInstallStatusText("Finished.");

            ShowFinalNextButton();
        }

        private void SetInstallStatusText(string txt)
        {
            Invoke((MethodInvoker)delegate() { 
                step4ExtractLabel.Text = txt;
                if (txt == "Failed." || txt == "Finished.")
                {
                    step4ProgressBar.Hide();
                }
            });
            
        }

        private void ShowFinalNextButton()
        {
            Invoke((MethodInvoker)delegate() {
                finalNextButton.Show();
            });
        }

        private void step3CancelButton_Click(object sender, EventArgs e)
        {
            new CancelForm().ShowDialog();
        }
        #endregion
        bool finished = false;
        #region Step 3
        private void step5FinishButton_Click(object sender, EventArgs e)
        {
            finished = true;
            var Info = new ProcessStartInfo();
            Info.Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" +
                           Application.ExecutablePath + "\" & rmdir \"" + Path.GetDirectoryName(location) + "\"";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info); 
            Application.Exit();	  
        }
        #endregion

        private void finalNextButton_Click(object sender, EventArgs e)
        {
            step2GroupPanel.Hide();
            step3GroupPanel.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!finished)
            {
                e.Cancel = true;
                new CancelForm().ShowDialog();
            }
        }

        public static void RemoveControlPanelProgram(string application)
        {
            var InstallerRegLoc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            var homeKey = (Registry.LocalMachine).OpenSubKey(InstallerRegLoc, true);
            var appSubKey = homeKey.OpenSubKey(application);
            if (null != appSubKey)
            {
                homeKey.DeleteSubKey(application);
            }
            homeKey.Close();
        }

        private void step4CancelButton_Click(object sender, EventArgs e)
        {
            new CancelForm().ShowDialog();
        }
    }
}
