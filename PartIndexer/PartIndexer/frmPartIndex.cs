#region All using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
#endregion

namespace PartIndexer
{
    /*
    Basic flow of this apps. whenever products or website_content table data will be changed then a log data will be inserted to ContentChangeLog table 
    from trigger and those triggers name a) TRG_website_content_Monitor b)TRG_Products_Monitor.
    this trigger TRG_website_content_Monitor is implemented on website_content table 
    and this trigger TRG_Products_Monitor is implemented on Products table.
    
    this windows app will monitoring ContentChangeLog table data change like insert/update & delete. if any activity found for the table ContentChangeLog 
    then this apps will call a web service desging in our web site which will invoke routine to re-indexing data.
    */

    public partial class frmPartIndex : Form
    {
        static string connectionString = "server=sql08-2.orcsweb.com;uid=bba-reman;password=_bba_1227_kol;database=BBAreman;Pooling=true;Connect Timeout=20;";
        SqlDependency dep;

        /// <summary>
        /// frmPartIndex is ctor
        /// Sql Dependency will be started from this ctor
        /// </summary>
        public frmPartIndex()
        {
            InitializeComponent();
            Notifier.ContextMenu = ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Exit", Exit) });
            Notifier.Visible = true;
            ShowInTaskbar = false;
            this.Hide();

            System.Data.SqlClient.SqlDependency.Stop(connectionString);
            System.Data.SqlClient.SqlDependency.Start(connectionString);
            RegisterNotification();

            MailNotify("STARTED");
        }

        /// <summary>
        /// RegisterInStartup
        /// this function put a key value in registry which causes this apps to be invoke windows startup
        /// </summary>
        /// <param name="isChecked"></param>
        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                if (registryKey.GetValue("PartIndex") == null)
                    registryKey.SetValue("PartIndex", Application.ExecutablePath.ToString());
            }
            else
            {
                registryKey.DeleteValue("PartIndex");
            }
        }

        /// <summary>
        /// RegisterNotification
        /// this is main routine which will monitor data change in ContentChangeLog table
        /// </summary>
        private void RegisterNotification()
        {
            string tmpdata = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT ActivityDate FROM [bba-reman].ContentChangeLog";
                    dep = new SqlDependency(cmd);
                    dep.OnChange += new OnChangeEventHandler(OnDataChange);
                    SqlDataReader dr = cmd.ExecuteReader();
                    {
                        while (dr.Read())
                        {
                            if (dr[0] != DBNull.Value)
                            {
                                tmpdata = dr[0].ToString();
                            }
                        }
                    }
                    dr.Dispose();
                    cmd.Dispose();
                }
            }
            finally
            {
                //SqlDependency.Stop(connStr);
            }

        }

        /// <summary>
        /// OnDataChange
        /// OnDataChange will fire when after data change found in ContentChangeLog table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDataChange(object sender, SqlNotificationEventArgs e)
        {
            Notifier.BalloonTipTitle = "Scheduler";
            Notifier.BalloonTipText = "Part related change notification detected";
            Notifier.ShowBalloonTip(1000);

            SqlDependency dep = sender as SqlDependency;
            dep.OnChange -= new OnChangeEventHandler(OnDataChange);
            //StartIndex();
            //ClearOldSubscriptions();
            ClearNotificationQueue();

            RegisterNotification();
        }

        private void ClearOldSubscriptions()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    string sql =
                        ////@"DECLARE @UniqueTimeout AS int = 3586; " +
                        @"DECLARE @SubscriptionId AS int; " +
                        @"DECLARE @Sql AS varchar(max); " +
                        @"DECLARE SubscriptionCursor CURSOR LOCAL FAST_FORWARD " +
                        @"    FOR " +
                        @"        SELECT id " +
                        @"        FROM sys.dm_qn_subscriptions " +
                        @"      WHERE database_id = DB_ID() " +
                        @"            AND timeout = @UniqueTimeout " +
                        @"OPEN SubscriptionCursor; " +
                        @"FETCH NEXT FROM SubscriptionCursor INTO @SubscriptionId; " +
                        @"WHILE @@FETCH_STATUS = 0 " +
                        @"BEGIN " +
                        @"    SET @Sql = 'KILL QUERY NOTIFICATION SUBSCRIPTION ' + CONVERT(varchar, @SubscriptionId); " +
                        @"    EXEC(@Sql); " +
                        @" " +
                        @"    FETCH NEXT FROM SubscriptionCursor INTO @SubscriptionId; " +
                        @"END";

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;
                    command.Parameters.Add("@UniqueTimeout", SqlDbType.Int).Value = 432000;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        private void ClearNotificationQueue()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    string sql =
                        @"DECLARE @Conversation AS uniqueidentifier; " +
                        @"DECLARE ConversationCursor CURSOR LOCAL FAST_FORWARD  " +
                        @"    FOR " +
                        @"        SELECT CEP.conversation_handle FROM sys.conversation_endpoints CEP  " +
                        @"        WHERE CEP.state = 'DI' or CEP.state = 'CD' " +
                        @"     " +
                        @"OPEN ConversationCursor; " +
                        @"FETCH NEXT FROM ConversationCursor INTO @Conversation; " +
                        @"WHILE @@FETCH_STATUS = 0  " +
                        @"BEGIN " +
                        @"    END CONVERSATION @Conversation WITH CLEANUP; " +
                        @" " +
                        @"    FETCH NEXT FROM ConversationCursor INTO @Conversation; " +
                        @"END " +
                        @"";

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// StartIndex
        /// this routine will call web service in bba reman website which will invoke routine to re-index data
        /// </summary>
        void StartIndex()
        {
            bool flag=true;

            PartIndexerWS.AuthHeader oAuth = new PartIndexerWS.AuthHeader();
            oAuth.Username = "Admin";
            oAuth.Password = "Admin";

            PartIndexerWS.SearchDataIndex DataIndex = new PartIndexerWS.SearchDataIndex();
            DataIndex.AuthHeaderValue = oAuth;
            try
            {
                Notifier.BalloonTipTitle = "Scheduler";
                Notifier.BalloonTipText = "Part Re-indexing started...";
                Notifier.ShowBalloonTip(1000);

                DataIndex.StartIndex();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                flag = false;
            }
            finally
            {
                if (flag)
                {
                    Notifier.BalloonTipTitle = "Scheduler";
                    Notifier.BalloonTipText = "Part Re-indexing finished...";
                    Notifier.ShowBalloonTip(1000);
                }
            }
        }

        /// <summary>
        /// MailNotify
        /// fire mail when apps start & exit
        /// </summary>
        /// <param name="strStatus"></param>
        void MailNotify(string strStatus)
        {
            if (strStatus == "STARTED")
            {
                var template = new MailTemplate()
                    .WithBody("HI,<br><br>Part Indexer Started Date " + DateTime.Now.ToLongDateString())
                    .WithSubject("Part Indexer Started")
                    .WithSender("bba-india@bba-reman.com")
                    .WithRecepient("tridip@bba-reman.com")
                    .Send();
            }
            else if (strStatus == "NOTSTARTED")
            {
                var template = new MailTemplate()
                    .WithBody("HI,<br><br>Part Indexer Not Started Date " + DateTime.Now.ToLongDateString())
                    .WithSubject("Part Indexer Not Started")
                    .WithSender("bba-india@bba-reman.com")
                    .WithRecepient("tridip@bba-reman.com")
                    .Send();
            }

        }

        /// <summary>
        /// Exit
        /// Exit will shut down the apps 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Exit(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDependency.Stop(connectionString);
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            Notifier.Visible = false;
            Notifier.Dispose();
            Notifier = null;
            MailNotify("NOTSTARTED");
            Application.Exit();
            Environment.Exit(1);
        }

        /// <summary>
        /// frmPartIndex_Resize
        /// this routine will be called when form will be re-sized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPartIndex_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                Notifier.Visible = true;
                Notifier.BalloonTipTitle = "Scheduler";
                Notifier.BalloonTipText = "Part Indexing Scheduler Started";
                Notifier.ShowBalloonTip(1000);
            }
        }
    }
}
