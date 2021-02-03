using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Shotr.Core.Controls.Theme;
using Shotr.Ui.Installer.Utils;

namespace Shotr.Ui.Installer
{
    public partial class InstallerForm : ThemedForm
    {
        public InstallerForm()
        {
            InitializeComponent();

            //Hide all panels
            step2GroupPanel.Hide();
            step3GroupPanel.Hide();
            step4GroupPanel.Hide();
            step5GroupPanel.Hide();
            
            var freeBytes = (((Utils.Utils.FreeBytes("C:\\") / 1024) / 1024));
            metroLabel13.Text = $"Space Available: {(freeBytes / 1024)}{"." + (freeBytes % 1024)}GB";
            metroTextBox1.Text = Properties.Resources.TermsOfService;

            if (Program.Silent)
            {
                Utils.Utils.r = new Random(Environment.TickCount);
                FinishedInstaller += InstallerForm_FinishedInstaller;
                var Install_Reg_Loc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

                var hKey = (Registry.LocalMachine).OpenSubKey(Install_Reg_Loc, true);

                Visible = false;
                ShowInTaskbar = false;
                Shown += InstallerForm_Shown;

                if (hKey != null)
                {
                    var appKey = hKey.OpenSubKey("Shotr");
                    if (appKey != null)
                    {
                        var path = ((string)appKey.GetValue("InstallLocation", (object)Environment.GetFolderPath((Environment.Is64BitOperatingSystem ? Environment.SpecialFolder.ProgramFilesX86 : Environment.SpecialFolder.ProgramFiles)) + "\\Shotr\\", RegistryValueOptions.None));

                        Install(path);
                    }
                    else
                    {
                        Install(Environment.GetFolderPath((Environment.Is64BitOperatingSystem ? Environment.SpecialFolder.ProgramFilesX86 : Environment.SpecialFolder.ProgramFiles)) + "\\Shotr\\");
                    }
                }
                else
                {
                    Install(Environment.GetFolderPath((Environment.Is64BitOperatingSystem ? Environment.SpecialFolder.ProgramFilesX86 : Environment.SpecialFolder.ProgramFiles)) + "\\Shotr\\");
                }
            }
        }

        void InstallerForm_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        void InstallerForm_FinishedInstaller(string location)
        {
            //start up shotr first.
            Process.Start(location + "\\Shotr.exe");
            Environment.Exit(0);
        }

        delegate void DownloadFinished(bool error, Exception ermsg = null);
        private event DownloadFinished DownloadCompleted;

        delegate void InstallFinished(string path);
        private event InstallFinished FinishedInstaller = delegate { };

        private void Form1_Load(object sender, EventArgs e)
        {
            Utils.Utils.r = new Random(Environment.TickCount);
            metroTextBox2.Text = Environment.GetFolderPath((Environment.Is64BitOperatingSystem ? Environment.SpecialFolder.ProgramFilesX86 : Environment.SpecialFolder.ProgramFiles)) + "\\Shotr\\";
            //estimate required space.
            new Thread(delegate()
                {
                    var output = 2.0f;
                    try
                    {
                        var url = "https://shotr.dev/downloads/latest_beta.zip";
                        var r = (HttpWebRequest)WebRequest.Create(url);
						r.Proxy = null;
                        r.Method = "HEAD";
                        r.Timeout = 10000;
                        var f = (HttpWebResponse)r.GetResponse();
                        var d = f.GetResponseHeader("Content-Length");
                        //length in bytes.
                        //multiply by 2, worst case scenario 50% or more ratio for compression
                        if (float.TryParse(d, out output))
                        {
                            output = (int)(output * 2.4);
                            //convert to MB.
                            output = ((output / 1024) / 1024);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    //set label.
                    Invoke((MethodInvoker)delegate() { metroLabel12.Text =
                        $"Space Required: {output.ToString("0.##")}MB"; });
                }).Start();
        }

        #region Step 1
        private void step1NextButton_Click(object sender, EventArgs e)
        {
            step1GroupPanel.Hide();
            step2GroupPanel.Show();
        }

        private void step1CancelButton_Click(object sender, EventArgs e)
        {
            new CancelForm().ShowDialog();
        }
        #endregion

        #region Step 2
        private void step2BackButton_Click(object sender, EventArgs e)
        {
            step2GroupPanel.Hide();
            step1GroupPanel.Show();
        }

        private void step2IAgreeButton_Click(object sender, EventArgs e)
        {
            step2GroupPanel.Hide();
            step3GroupPanel.Show();
        }

        private void step2CancelButton_Click(object sender, EventArgs e)
        {
            new CancelForm().ShowDialog();
        }
        #endregion

        #region Step 3
        private void step3BackButton_Click(object sender, EventArgs e)
        {
            step3GroupPanel.Hide();
            step2GroupPanel.Show();
        }

        private void step3FileBrowserButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            if (folderBrowserDialog1.SelectedPath != "")
                metroTextBox2.Text = folderBrowserDialog1.SelectedPath;
        }

        private void step3InstallButton_Click(object sender, EventArgs e)
        {
            step3GroupPanel.Hide();
            step4GroupPanel.Show();
            //start installing...
            Install(metroTextBox2.Text);
        }

        private void Log(string p)
        {
            if (!Program.Silent)
            {
                Invoke((MethodInvoker) delegate() { step4TextBox.Text += $"[{DateTime.Now}] - {p}\r\n"; });
            }
        }
        
        private string tempFile = "";
        private string installedLocation = "";
        private bool installed;
        private void Install(string installPath)
        {
            //start downloading files & shit.
            installedLocation = installPath;
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\")) { Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\"); }
            tempFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\" + Utils.Utils.RandStr(Utils.Utils.r.Next(5, 10)) + ".tmp";
            var p = new WebClient() { Proxy = null };
            try
            {
                SetInstallStatusText("Downloading required files...");
                Log("Downloading the latest Shotr...");
                DownloadCompleted += Form1_DownloadCompleted;
                try
                {
                    var url = "https://shotr.dev/downloads/latest_beta.zip";
                    p.DownloadProgressChanged += (_, args) =>
                    {
                        step4ProgressBar.Value = args.ProgressPercentage;
                    };
                    p.DownloadFileCompleted += (sender, args) => DownloadCompleted.Invoke(false);
                    p.DownloadFileAsync(new Uri(url), tempFile);
                }
                catch (Exception ex)
                {
                    DownloadCompleted.Invoke(true, ex);
                }
            }
            catch(Exception ex)
            {
                //failed.
                Log("There was an error during setup.");
                Log(ex.Message);
                Log("Setup failed.");
                ShowFinalNextButton();
            }
        }

        void Form1_DownloadCompleted(bool error, Exception ermsg = null)
        {
            var cl = new WebClient();
            cl.Proxy = null;
            if (!error)
            {
                //successful.
                //unpack shit & then install shit.
                new Thread(delegate()
                {
                    try
                    {
                        //make sure if it exists, kill them.
                        foreach (var process in Process.GetProcessesByName("Shotr"))
                        {
                            process.Kill();
                            Thread.Sleep(500);
                        }
                        //clear out old files.
                        Directory.CreateDirectory(installedLocation);
                        foreach (var file in Directory.GetFiles(installedLocation))
                        {
                            try
                            {
                                while (File.Exists(file))
                                {
                                    File.Delete(file);
                                    Thread.Sleep(100);
                                }
                            }
                            catch
                            {
                                //in use.
                            }
                        }
                        
                        SetInstallStatusText("Setting directory permissions...");
                        Log("Setting directory permissions...");

                        //set directory permissions.
                        var dInfo = new DirectoryInfo(Path.GetFullPath(installedLocation));

                        var dSecurity = dInfo.GetAccessControl();

                        dSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                        dInfo.SetAccessControl(dSecurity);

                        SetInstallStatusText("Unpacking...");
                        Log("Unpacking...");

                        using (var fs = File.OpenRead(tempFile))
                        {
                            using (var zip = new ZipArchive(fs))
                            {
                                foreach (var zipEntry in zip.Entries)
                                {
                                    var fileName = Path.GetFullPath(installedLocation) + zipEntry.Name;
                                    Log($"Copying file {zipEntry.Name}...");
                                    zipEntry.ExtractToFile(fileName, true);
                                }
                            }
                        }

                        File.Delete(tempFile);

                        SetInstallStatusText("Creating link on desktop...");
                        Log("Creating link on desktop...");

                        //create icon on the desktop.
                        using (var shortcut = new ShellLink())
                        {
                            shortcut.Target = installedLocation + "\\Shotr.exe";
                            shortcut.WorkingDirectory = Path.GetDirectoryName(installedLocation + "\\Shotr.exe");
                            shortcut.Description = "Shotr";
                            shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
                            shortcut.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Shotr.lnk");
                        }
                      
                        //Utils.Utils.PinUnpinTaskBar(this.installPath + "Shotr.exe", true);

                        //add to registry.
                        //get shotr version.
                        var version = "1.0";
                        try
                        {
                           var versionInfo = FileVersionInfo.GetVersionInfo(installedLocation + "\\Shotr.exe");
                           version = versionInfo.ProductVersion;
                        }
                        catch{}

                        try
                        {
                            RegisterControlPanelProgram("Shotr", installedLocation, installedLocation + "shotr.ico", installedLocation + "uninstall.exe", "Shotr", version);
                            File.Copy(Application.ExecutablePath, installedLocation + "\\uninstall.exe");
                        }
                        catch { }

                        if (Program.Silent)
                        {
                            //doo et.
                            FinishedInstaller.Invoke(installedLocation);
                        }

                        Log("Finished.");
                        SetInstallStatusText("Finished.");
                        installed = true;
                        ShowFinalNextButton();
                    }
                    catch(Exception ex)
                    {
                        //failed.
                        Log("Failed to install Shotr.");
                        Log("Setup failed.");
                        Log("Error Message: " + ex);
                        SetInstallStatusText("Failed.");
                        ShowFinalNextButton();
                    }
                }).Start();
            }
            else
            {
                Log("Failed to download the required files.");
                Log("Setup failed.");
                Log("Error Message: " + ermsg);
                SetInstallStatusText("Failed.");
                ShowFinalNextButton();
            }
        }

        private void SetInstallStatusText(string txt)
        {
            if (!Program.Silent)
            {
                Invoke((MethodInvoker) delegate()
                {
                    step4ExtractLabel.Text = txt;
                    if (txt == "Failed." || txt == "Finished.")
                    {
                        step4ProgressBar.Hide();
                        //this.step4ProgressBar.Value = 100;
                        //this.step4ProgressBar.ProgressBarStyle = ProgressBarStyle.Continuous;
                        //this.Refresh();
                    }
                });
            }
        }

        private void ShowFinalNextButton()
        {
            if (!Program.Silent)
            {
                Invoke((MethodInvoker) delegate()
                {
                    finalNextButton.Show();
                    //this.Refresh();
                });
            }
        }

        private void step3CancelButton_Click(object sender, EventArgs e)
        {
            new CancelForm().ShowDialog();
        }
        #endregion

        #region Step 4

        private void step4CancelButton_Click(object sender, EventArgs e)
        {
            new CancelForm().ShowDialog();
        }
        #endregion

        #region Step 5
        private void step5FinishButton_Click(object sender, EventArgs e)
        {
            step5FinishButton.Enabled = false;
            if (metroCheckBox1.Checked)
            {
                using (var shortcut = new ShellLink())
                {
                    shortcut.Target = installedLocation + "\\Shotr.exe";
                    shortcut.WorkingDirectory = Path.GetDirectoryName(installedLocation + "\\Shotr.exe");
                    shortcut.Description = "Shotr - Region Capture";
                    shortcut.Arguments = "--region";
                    shortcut.IconPath = Path.GetDirectoryName(installedLocation) + "\\shotr-region.ico";
                    shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
                    shortcut.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Shotr - Capture.lnk");
                }
                using (var shortcut = new ShellLink())
                {
                    shortcut.Target = installedLocation + "\\Shotr.exe";
                    shortcut.WorkingDirectory = Path.GetDirectoryName(installedLocation + "\\Shotr.exe");
                    shortcut.Description = "Shotr - Record";
                    shortcut.Arguments = "--record";
                    shortcut.IconPath = Path.GetDirectoryName(installedLocation) + "\\shotr-record.ico";
                    shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
                    shortcut.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Shotr - Record.lnk");
                }
            }
            if (step5CheckBox.Checked)
            //start shit.
            {
                Process.Start(installedLocation + "\\Shotr.exe");
            }
            Environment.Exit(0);
        }
        #endregion

        private void finalNextButton_Click(object sender, EventArgs e)
        {
            //if install completed, do this.
            if (!installed)
            {
                step4GroupPanel.Visible = false;
                step6FailedPanel.Visible = true;
                return;
            }
            step4GroupPanel.Hide();
            step5GroupPanel.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            new CancelForm().ShowDialog();
        }

        public void RegisterControlPanelProgram(string appName, string installLocation, string displayicon, string uninstallString, string publisher, string version)
        {
            var Install_Reg_Loc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

            var hKey = (Registry.LocalMachine).OpenSubKey(Install_Reg_Loc, true);
            var appKey = hKey?.CreateSubKey(appName);

            if (appKey != null)
            {

                appKey.SetValue("DisplayName", appName, RegistryValueKind.String);

                appKey.SetValue("Publisher", publisher, RegistryValueKind.String);

                appKey.SetValue("InstallLocation",
                    installLocation, RegistryValueKind.ExpandString);

                appKey.SetValue("DisplayIcon", displayicon, RegistryValueKind.String);

                appKey.SetValue("UninstallString",
                    uninstallString, RegistryValueKind.ExpandString);

                appKey.SetValue("DisplayVersion", version, RegistryValueKind.String);

                appKey.Close();

                hKey.Close();
            }
        }
    }
}
