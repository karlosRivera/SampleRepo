using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using System.Reflection;
using System.Xml;
using CSRBusiness;
using PopupControl;
using System.Threading;
using System.Configuration;
using System.IO;
namespace CSRAssistant
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        bool isActive = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = metroStyleManager1.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            Utils.SaveProperty(metroStyleManager1);
        }

        Popup InplacePopup;
        CSRAssistant.UserControls.Settings SettingsPopup;

        private void metroTile8_Click(object sender, EventArgs e)
        {
            InplacePopup.Show(sender as Button);
        }

        private void WatchFiles()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string strPath = config.AppSettings.Settings["localVoiceRecordsPath"].Value.Replace(",", "");
            string strRemotePath =  config.AppSettings.Settings["ServerVoiceRecordsPath"].Value.Replace(",", "");

            try
            {
                if (strPath.Trim() != "" && strRemotePath.Trim() != "")
                {
                    if (Directory.Exists(strRemotePath))
                    {
                        string[] filePaths = Directory.GetFiles(strPath.Replace(",", string.Empty), "*.mp3", SearchOption.AllDirectories);
                        foreach (string tmpFile in filePaths)
                        {
                            if (Directory.Exists(Path.GetDirectoryName(tmpFile)))
                            {
                                if (File.Exists(tmpFile))
                                {
                                    if (!Utils.FileInUse(tmpFile))
                                    {
                                        File.Move(tmpFile, strRemotePath.Replace(",", string.Empty) + "\\" + Path.GetFileName(tmpFile));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                WatchFiles();
            }
        }

        bool IsBusy = false;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            string strRemotePath = ConfigurationManager.AppSettings["ServerVoiceRecordsPath"];

            timer.Tick += new EventHandler(timer_Tick); // Every time timer ticks, timer_Tick will be called
            timer.Interval = 10000;                     // Timer will tick every 10 seconds
            timer.Enabled = true;                       // Enable the timer
            timer.Start();     

            InplacePopup = new Popup(SettingsPopup = new CSRAssistant.UserControls.Settings());
            InplacePopup.Resizable = false;

            // code for folder browser
            SettingsPopup.btnBrowse.Click += (_sender, _e) =>
            {
                FolderBrowserDialog folderBrowserdg = new FolderBrowserDialog();
                if (folderBrowserdg.ShowDialog() == DialogResult.OK)
                {
                    SettingsPopup.txtPath.Text = folderBrowserdg.SelectedPath;
                }
            };

            SettingsPopup.btnServerBrowse.Click += (_sender, _e) =>
            {
                FolderBrowserDialog folderBrowserdg = new FolderBrowserDialog();
                folderBrowserdg.SelectedPath = strRemotePath; // @"\\192.168.006.2\d$\CSRAssistant\Biswajit";
                if (folderBrowserdg.ShowDialog() == DialogResult.OK)
                {
                    SettingsPopup.txtServerPath.Text = folderBrowserdg.SelectedPath;
                }

            };

            // code for saving local Dir location in config file
            SettingsPopup.btnSave.Click += (_sender, _e) =>
            {
                try
                {
                    if (Utils.IsDirectory(SettingsPopup.txtPath.Text))
                    {
                        
                        if (!Directory.Exists(SettingsPopup.txtPath.Text))
                        {
                            Directory.CreateDirectory(SettingsPopup.txtPath.Text);
                        }

                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        if (config.AppSettings.Settings["localVoiceRecordsPath"].Value != null || config.AppSettings.Settings["localVoiceRecordsPath"].Value.Trim() != "")
                        {

                            config.AppSettings.Settings["localVoiceRecordsPath"].Value = SettingsPopup.txtPath.Text.Replace(",", string.Empty);
                            config.Save(ConfigurationSaveMode.Modified);
                            SettingsPopup.txtPath.Text = config.AppSettings.Settings["localVoiceRecordsPath"].Value.Replace(",", string.Empty);
                        }
                        else
                        {
                            config.AppSettings.Settings.Add("localVoiceRecordsPath", SettingsPopup.txtPath.Text.Replace(",", string.Empty));
                            config.Save(ConfigurationSaveMode.Modified);
                            SettingsPopup.txtPath.Text = config.AppSettings.Settings["localVoiceRecordsPath"].Value.Replace(",", string.Empty);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid local directory specified");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                InplacePopup.Hide();
            };

            // code for saving remote Dir location in config file
            SettingsPopup.btnServerSave.Click += (_sender, _e) =>
            {
                try
                {
                    if (Utils.IsDirectory(SettingsPopup.txtServerPath.Text))
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        if (!Directory.Exists(SettingsPopup.txtServerPath.Text))
                        {
                            Directory.CreateDirectory(SettingsPopup.txtServerPath.Text);
                        }


                        if (config.AppSettings.Settings["ServerVoiceRecordsPath"].Value != null || config.AppSettings.Settings["ServerVoiceRecordsPath"].Value.Trim() != "")
                        {
                            config.AppSettings.Settings["ServerVoiceRecordsPath"].Value = SettingsPopup.txtServerPath.Text.Replace(",", string.Empty);
                            config.Save(ConfigurationSaveMode.Modified);
                            SettingsPopup.txtServerPath.Text = config.AppSettings.Settings["ServerVoiceRecordsPath"].Value.Replace(",", string.Empty);
                        }
                        else
                        {
                            config.AppSettings.Settings.Add("ServerVoiceRecordsPath", SettingsPopup.txtServerPath.Text.Replace(",", string.Empty));
                            config.Save(ConfigurationSaveMode.Modified);
                            SettingsPopup.txtServerPath.Text = config.AppSettings.Settings["ServerVoiceRecordsPath"].Value.Replace(",", string.Empty);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid remote directory specified");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                InplacePopup.Hide();
            };

            Utils.ReadProperty(metroStyleManager1);
            SetLineSize();
            if (!User.IsLoggedIn)
            {
                metroTile6.Text = "Login";
                metroTile6.Refresh();
            }
            else
            {
                metroTile6.Text = "Logout";
                metroTile6.Refresh();
            }
        }

         private void metroTile2_Click(object sender, EventArgs e)
        {
            var m = new Random();
            int next = m.Next(0, 13);
            metroStyleManager1.Style = (MetroColorStyle)next;
            Utils.SaveProperty(metroStyleManager1);
        }

        private void SetLineSize()
        {
            mTilePanel.Top = (this.Height - mTilePanel.Height) / 2;
            mTilePanel.Left = (this.Width - mTilePanel.Width) / 2;

            this.lineShape1.X1 = -20;
            this.lineShape1.X2 = this.Width;
            this.lineShape1.Y1 = 12;
            this.lineShape1.Y2 = 12;
        }

       

        private void metroTile3_Click(object sender, EventArgs e)
        {
            bool IsOk = false;
            if (!User.IsLoggedIn)
            {
                frmLogin oLogin = new frmLogin(this);
                oLogin.LoginDone += new EventHandler<LoginChanged>(frMain_LoginDone);
                if (MaskedDialog.ShowDialog(this, oLogin) == DialogResult.OK)
                {
                    IsOk = true;
                }
                oLogin.Dispose();
                oLogin = null;

                if (IsOk)
                {
                    frmOURFeedBack ofrmOURFeedBack = new frmOURFeedBack(this);
                    MaskedDialog.ShowDialog(this, ofrmOURFeedBack);
                    ofrmOURFeedBack.Dispose();
                    ofrmOURFeedBack = null;
                    metroTile6.Text = "Logout";
                    metroTile6.Refresh();
                }
            }
            else
            {
                frmOURFeedBack ofrmOURFeedBack = new frmOURFeedBack(this);
                MaskedDialog.ShowDialog(this, ofrmOURFeedBack);
                ofrmOURFeedBack.Dispose();
                ofrmOURFeedBack = null;

            }
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            if (!User.IsLoggedIn)
            {
                frmLogin oLogin = new frmLogin(this);
                oLogin.LoginDone += new EventHandler<LoginChanged>(frMain_LoginDone);
                MaskedDialog.ShowDialog(this, oLogin);
                oLogin.Dispose();
                oLogin = null;
            }
            else
            {
                metroTile6.Text = "Login";
                metroTile6.Refresh();
                User.IsLoggedIn = false;
                tileUserName.Text = "N/A";
                tileUserName.Refresh();
                tileCountryFlag.TileImage = null;
                tileCountryFlag.Refresh();

            }
        }
  
        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (!isActive)
            {
                isActive = true;
                if (!User.IsLoggedIn)
                {
                    frmLogin oLogin = new frmLogin(this);
                    oLogin.LoginDone += new EventHandler<LoginChanged>(frMain_LoginDone);
                    MaskedDialog.ShowDialog(this, oLogin);
                    oLogin.Dispose();
                    oLogin = null;
                }
            }
        }

        private void frMain_LoginDone(object sender, LoginChanged e)
        {
            tileUserName.Text = e.UserName;
            tileCountryFlag.TileImage = (Image) Utils.GetImageByName(e.Country.ToString());
            tileCountryFlag.Refresh();
            metroTile6.Text = "Logout";
            metroTile6.Refresh();

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            SetLineSize();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            bool IsOk=false;
            if (!User.IsLoggedIn)
            {
                frmLogin oLogin = new frmLogin(this);
                oLogin.LoginDone += new EventHandler<LoginChanged>(frMain_LoginDone);
                if (MaskedDialog.ShowDialog(this, oLogin) == DialogResult.OK)
                {
                    IsOk = true;
                }
                oLogin.Dispose();
                oLogin = null;

                if (IsOk)
                {
                    frmCallAssistant oCallAssistant = new frmCallAssistant(this);
                    MaskedDialog.ShowDialog(this, oCallAssistant);
                    oCallAssistant.Dispose();
                    oCallAssistant = null;
                }
            }
            else
            {
                    frmCallAssistant oCallAssistant = new frmCallAssistant(this);
                    MaskedDialog.ShowDialog(this, oCallAssistant);
                    oCallAssistant.Dispose();
                    oCallAssistant = null;
            }
            
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            bool IsOk = false;
            if (!User.IsLoggedIn)
            {
                frmLogin oLogin = new frmLogin(this);
                oLogin.LoginDone += new EventHandler<LoginChanged>(frMain_LoginDone);
                if (MaskedDialog.ShowDialog(this, oLogin) == DialogResult.OK)
                {
                    IsOk = true;
                }
                oLogin.Dispose();
                oLogin = null;

                if (IsOk)
                {
                    frmCallStat ofrmCallStat = new frmCallStat(this);
                    //oCallAssistant.Show();
                    MaskedDialog.ShowDialog(this, ofrmCallStat);
                    ofrmCallStat.Dispose();
                    ofrmCallStat = null;
                }
            }
            else
            {
                frmCallStat ofrmCallStat = new frmCallStat(this);
                //oCallAssistant.Show();
                MaskedDialog.ShowDialog(this, ofrmCallStat);
                //ofrmCallStat.Dispose();
                //ofrmCallStat = null;
            }

        }


    }
}
