using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PopupControl;
using CSRBusiness;
using System.Configuration;
using System.IO;

namespace CSRAssistant.UserControls
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = new Size(Size.Width * 2, Size.Height * 2);
            DoubleBuffered = true;
            ResizeRedraw = false;
            Utils.ReadProperty(metroStyleManager1);
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (!Directory.Exists(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\VoiceRecords"))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\VoiceRecords");
                }

                if (config.AppSettings.Settings["localVoiceRecordsPath"].Value != null)
                {
                    if (config.AppSettings.Settings["localVoiceRecordsPath"].Value.Trim() == "")
                    {
                        config.AppSettings.Settings.Add("localVoiceRecordsPath", (Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\VoiceRecords").Replace(",", string.Empty));
                        config.Save(ConfigurationSaveMode.Minimal);
                    }
                    else
                        txtPath.Text = config.AppSettings.Settings["localVoiceRecordsPath"].Value.Replace(",", string.Empty);
                }

                if (config.AppSettings.Settings["ServerVoiceRecordsPath"].Value != null)
                {
                    txtServerPath.Text = config.AppSettings.Settings["ServerVoiceRecordsPath"].Value.Replace(",", string.Empty);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
    }
}
