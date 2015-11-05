using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Server;
using System.Configuration;
using ICSharpCode.TextEditor.Document;


namespace NewSQLExecuter
{
    public partial class ucProgress : UserControl
    {

        public ucProgress()
        {
            InitializeComponent();
            lblMsg.Text = "";
        }

        public string Country { get; set; }
        public string DBConnection { get; set; }
        public string Sql { get; set; }
        public LogWriter Log { get; set; }

        public void Run()
        {
            SqlConnection oConnection = null;
            bool connect = false;
            this.lblMsg.InvokeEx(l => l.Text = "Connecting country " + Country);
            System.Threading.Thread.SpinWait(500000);
            //######################

            oConnection = new SqlConnection(DBConnection+";Connect Timeout=120;");
            Message m = Connect(oConnection);

            if (m.Success)
            {
                this.lblMsg.InvokeEx(l => l.Text = "Successfully connected country " + Country);
                pbStatus.InvokeEx(v=> v.Value=30);
                connect = true;
                Log.WriteToLog("Successfully Connect to " + Country, Country);
            }
            else
            {
                this.lblMsg.InvokeEx(l => l.Text = "Connection error for country " + Country);
                connect = false;
                Log.WriteToLog("Can not Connect to " + Country + " Exception details " + m.Info, Country);

            }
            System.Threading.Thread.SpinWait(500000);
            //######################

            if (connect)
            {
                this.lblMsg.InvokeEx(l => l.Text = "Executing sql for country " + Country);
                //Log.WriteToLog("Executing sql for country " + Country, Country);

                System.Threading.Thread.SpinWait(500000);
                pbStatus.InvokeEx(v => v.Value = 60);

                m = Execute(oConnection, Sql);
                if (m.Success)
                {
                    this.lblMsg.InvokeEx(l => l.Text = "Sql successfully executed for country " + Country);
                    Log.WriteToLog("Sql successfully executed for country " + Country, Country);

                    System.Threading.Thread.SpinWait(500000);
                    pbStatus.InvokeEx(v => v.Value = 100);
                    connect = true;
                }
                else
                {
                    this.lblMsg.InvokeEx(l => l.Text = "Sql execution error for country " + Country);
                    Log.WriteToLog("Sql execution error for country " + Country + " Exception details " + m.Info, Country);
                    connect = false;
                }
                //######################
            }

            if (connect)
                picStatus.InvokeEx(a => a.Image = Properties.Resources.tick);
            else
                picStatus.InvokeEx(a => a.Image = Properties.Resources.cross);

        }

        private Message Connect(SqlConnection oConnection)
        {
            var msg = new Message();
            
            try
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Open();
                msg.Success=true;
                msg.Info="Successfully connected";
            }
            catch (Exception ex)
            {
                msg.Success = false;
                msg.Info = ex.Message.ToString() ;

            }

            return msg;
        }
        private Message Execute(SqlConnection oConnection,string sql)
        {
            var msg = new Message();

            try
            {
                if (oConnection.State == ConnectionState.Closed)
                {
                    oConnection.Open();
                }

                using (SqlCommand command = new SqlCommand(sql, oConnection))
                {
                    command.CommandTimeout = 120;
                    Server server = new Server(new ServerConnection(oConnection));
                    server.ConnectionContext.ExecuteNonQuery(sql);
                }


                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                    oConnection.Dispose();
                }

                msg.Success = true;
                msg.Info = "Successfully connected";
            }
            catch (Exception ex)
            {
                msg.Success = false;
                msg.Info = ex.Message.ToString();

            }

            return msg;
        }
    }

    public class Message
    {
        public bool Success { get; set; }
        public string Info { get; set; }
    }
}
