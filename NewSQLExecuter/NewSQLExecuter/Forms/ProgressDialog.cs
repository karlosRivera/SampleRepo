using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;
using ICSharpCode.TextEditor.Document;
using System.IO;

namespace NewSQLExecuter
{
    public partial class ProgressDialog : Form
    {

        public ProgressDialog()
        {
            InitializeComponent();
            lblMsg.Text = "";
            lblClose.Enabled = false;

        }

        public LogWriter Log { get; set; }
        public string SQL { get; set; }

        private void ProgressDialog_Activated(object sender, EventArgs e)
        {
            int counter = 0;
            string strCountry="";

            Dictionary<string, string> dicList = new Dictionary<string, string>();
            DBConfigurationSection section = (DBConfigurationSection)ConfigurationManager.GetSection("DBConfiguration");

            if (section != null)
            {
                DateTime satrt = DateTime.Now;
                for (int i = 0; i <= section.Items.Count - 1; i++)
                {
                    var country = section.Items[i].CountryCode; ;
                    var constring = string.Format("{0}{1}{2}{3}", "UID=" + section.Items[i].UserID, ";PWD=" + section.Items[i].Password, 
                                    ";Server=" + section.Items[i].ServerName, ";Database=" + section.Items[i].DBName); 
                    dicList.Add(country, constring);
                }

                fpPanel.Controls.Clear();
                lblClose.Enabled = false;

                Func<KeyValuePair<string, string>, object> createProgress = entry =>
                {
                    var tmp = new ucProgress { Country = entry.Key, DBConnection = entry.Value, Sql = this.SQL, Log = this.Log };
                    fpPanel.Controls.Add(tmp);
                    return tmp;
                };

                Task oTask = Task.Factory.StartNew(() =>
                {
                    Parallel.ForEach(dicList,
                        entry =>
                        {
                            var ucProgress = (ucProgress)fpPanel.Invoke(createProgress, entry);
                            strCountry=entry.Key;
                            ucProgress.Run();
                            ++counter;
                        });
                })
                .ContinueWith((t) =>
                {
                    //if (counter == dicList.Count)
                    //{
                    //    lblClose.InvokeEx(a => a.Enabled = true);
                    //}
                    lblClose.InvokeEx(a => a.Enabled = true);
                });
            }
            else
            {
                MessageBox.Show("No database information found");
            }
        }

        private string GetBody(LogWriter olw,string strSql)
        {
            string strBody = "<html><body>";

            Queue<Log> oQ = olw.GetLogs();
            while (oQ.Count > 0)
            {
                Log ol = oQ.Dequeue();
                strBody = strBody + "<p>";

                strBody = strBody + "<p>Country " + ol.CountryCode + "<br/>";
                if (ol.Message.ToUpper().StartsWith("ERR"))
                {
                    strBody = strBody + "<span style='color:red'>" + ol.Message + "</span></p><br/>";
                }
                else
                {
                    strBody = strBody +  ol.Message + "</p><br/>";
                }
            }
            strBody = strBody + "<br/><p>Executed SQL " + strSql.Replace("\n", "<br/>").Replace("\r", "") + "<br/>";
            return strBody;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void ProgressDialog_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.WhiteSmoke,Color.LightGray,90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void ProgressDialog_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

    }

   
}
