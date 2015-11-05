using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;
using ICSharpCode.TextEditor.Document;
using System.IO;

namespace NewSQLExecuter
{
    public partial class SqlRunner : Form
    {
        SendMail osm = null;
        LogWriter olw = null;

        public SqlRunner()
        {
            InitializeComponent();
            olw = LogWriter.Instance;
            osm = new SendMail();
        }

        bool _highlightingProviderLoaded = false;
        private void SqlRunner_Load(object sender, EventArgs e)
        {
            if (!_highlightingProviderLoaded)
            {
                HighlightingManager.Manager.AddSyntaxModeFileProvider(new AppSyntaxModeProvider());
                _highlightingProviderLoaded = true;
            }
            txtScript.SetHighlighting("SQL");
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtScript.Text.Trim() != "")
            {
                ProgressDialog ps = new ProgressDialog();
                ps.Log = olw;
                ps.SQL = txtScript.Text;

                if (MaskedDialog.ShowDialog(this, ps) == DialogResult.OK)
                {
                    if (olw.Count() > 0)
                    {
                        osm.Body = GetBody(olw, txtScript.Text);
                        if (osm.Send())
                        {
                            lblMsg.Text = "Mail send successfully";
                        }
                    }
                    olw.FlushLog();
                    //ps.Dispose();
                    //ps = null;
                }
            }
        }

        private string GetBody(LogWriter olw, string strSql)
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
                    strBody = strBody + ol.Message + "</p><br/>";
                }
            }
            strBody = strBody + "<br/><p>Executed SQL " + strSql.Replace("\n", "<br/>").Replace("\r", "") + "<br/>";
            return strBody;
        }

        private void SqlRunner_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.WhiteSmoke, Color.LightGray, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void SqlRunner_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
