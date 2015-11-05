#region all using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
#endregion

namespace PartIndexerService
{
    public partial class PartIndexer : ServiceBase
    {
        private PollingService _pollingService = new PollingService();
        //SqlDependency dep;

        public PartIndexer()
        {
            InitializeComponent();
        }

        //public void Start()
        //{
        //    BBALogger.Write("PartIndexer Service OnStart called start", BBALogger.MsgType.Info);
        //    _pollingService.StartPolling();
        //    //RegisterNotification();
        //    Utility.MailNotify("STARTED");
        //    BBALogger.Write("PartIndexer Service OnStart called end", BBALogger.MsgType.Info);

        //}

        #region OnStart
        protected override void OnStart(string[] args)
        {
            // write to xml log file
            BBALogger.Write("PartIndexer Service OnStart called start", BBALogger.MsgType.Info);
            //start polling service
            _pollingService.StartPolling();
            //RegisterNotification();
            // trigger mail
            Utility.MailNotify("STARTED");
            // write to xml log file
            BBALogger.Write("PartIndexer Service OnStart called end", BBALogger.MsgType.Info);
        }
        #endregion

        //public void Start()
        //{
        //    BBALogger.Write("PartIndexer Service OnStart called start", BBALogger.MsgType.Info);
        //    RegisterNotification();
        //    MailNotify("STARTED");
        //    BBALogger.Write("PartIndexer Service OnStart called end, logged in user " + GetLoggedInUser(), BBALogger.MsgType.Info);
        //}

        #region RegisterNotification
        /// <summary>
        /// RegisterNotification
        /// this is main routine which will monitor data change in ContentChangeLog table
        /// </summary>
        //private void RegisterNotification()
        //{
        //    string tmpdata = "";
        //    BBALogger.Write("PartIndexer Service RegisterNotification called start", BBALogger.MsgType.Info);

        //    System.Data.SqlClient.SqlDependency.Stop(connectionString);
        //    System.Data.SqlClient.SqlDependency.Start(connectionString);

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = conn.CreateCommand();
        //            cmd.CommandText = "SELECT ActivityDate FROM [bba-reman].ContentChangeLog";
        //            dep = new SqlDependency(cmd);
        //            dep.OnChange += new OnChangeEventHandler(OnDataChange);

        //            //dep.OnChange += delegate(Object o, SqlNotificationEventArgs args)
        //            //{
        //            //    Console.WriteLine("Event Recd");
        //            //    Console.WriteLine("Info:" + args.Info);
        //            //    Console.WriteLine("Source:" + args.Source);
        //            //    Console.WriteLine("Type:" + args.Type);
        //            //};


        //            SqlDataReader dr = cmd.ExecuteReader();
        //            {
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    tmpdata = dr[0].ToString();
        //                }
        //            }

                    

        //            dr.Dispose();
        //            cmd.Dispose();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        BBALogger.Write("PartIndexer Service RegisterNotification Error "+ex.Message.ToString(), BBALogger.MsgType.Error);
        //    }
        //    finally
        //    {
        //        BBALogger.Write("PartIndexer Service RegisterNotification called end", BBALogger.MsgType.Info);

        //    }

        //}
        #endregion

        //public void ReStartService()
        //{
        //    ServiceController service = new ServiceController("PartIndexer");

        //    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
        //    {
        //        service.Start();
        //    }
        //    else
        //    {
        //        service.Stop();
        //        service.WaitForStatus(ServiceControllerStatus.Stopped);
        //        service.Start();
        //        service.WaitForStatus(ServiceControllerStatus.Running);
        //    }
        //}

        #region OnDataChange
        /// <summary>
        /// OnDataChange
        /// OnDataChange will fire when after data change found in ContentChangeLog table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void OnDataChange(object sender, SqlNotificationEventArgs e)
        //{
        //    BBALogger.Write("PartIndexer Service OnDataChange called start", BBALogger.MsgType.Info);

        //    if (e.Source == SqlNotificationSource.Timeout)
        //    {
        //        var template = new MailTemplate()
        //            .WithBody("HI,<br><br>Part Indexer Service Exception Timeout occur " + DateTime.Now.ToLongDateString())
        //            .WithSubject("New Part Indexer Service Exception Timeout occur")
        //            .WithSender("bbasupport@bba-reman.com")
        //            .WithRecepient("tridip@bba-reman.com")
        //            .Send();
        //        BBALogger.Write("PartIndexer Service SqlNotificationSource.Timeout error", BBALogger.MsgType.Error);

        //        Environment.Exit(1);
        //    }
        //    else if (e.Source != SqlNotificationSource.Data)
        //    {
        //        var template = new MailTemplate()
        //            .WithBody("HI,<br><br>Part Indexer Service Exception SqlNotificationSource.Data " + DateTime.Now.ToLongDateString())
        //            .WithSubject("New Part Indexer Service Exception SqlNotificationSource.Data")
        //            .WithSender("bbasupport@bba-reman.com")
        //            .WithRecepient("tridip@bba-reman.com")
        //            .Send();
        //        BBALogger.Write("PartIndexer Service SqlNotificationSource.Data", BBALogger.MsgType.Error);

        //        //Environment.Exit(1);
        //    }
        //    else if (e.Type == SqlNotificationType.Change)
        //    {
        //        BBALogger.Write("PartIndexer Service Data changed detected", BBALogger.MsgType.Info);
        //    }
        //    else
        //    {
        //        BBALogger.Write(string.Format("Ignored change notification {0}/{1} ({2})", e.Type, e.Info, e.Source), BBALogger.MsgType.Warnings);
        //    }

        //    StartIndex();
        //    ((SqlDependency)sender).OnChange -= OnDataChange;
        //    ClearNotificationQueue();
        //    RegisterNotification();
        //}
         #endregion

        #region ClearOldSubscriptions
        //private void ClearOldSubscriptions()
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        using (var command = new SqlCommand())
        //        {
        //            string sql =
        //                ////@"DECLARE @UniqueTimeout AS int = 3586; " +
        //                @"DECLARE @SubscriptionId AS int; " +
        //                @"DECLARE @Sql AS varchar(max); " +
        //                @"DECLARE SubscriptionCursor CURSOR LOCAL FAST_FORWARD " +
        //                @"    FOR " +
        //                @"        SELECT id " +
        //                @"        FROM sys.dm_qn_subscriptions " +
        //                @"      WHERE database_id = DB_ID() " +
        //                @"            AND timeout = @UniqueTimeout " +
        //                @"OPEN SubscriptionCursor; " +
        //                @"FETCH NEXT FROM SubscriptionCursor INTO @SubscriptionId; " +
        //                @"WHILE @@FETCH_STATUS = 0 " +
        //                @"BEGIN " +
        //                @"    SET @Sql = 'KILL QUERY NOTIFICATION SUBSCRIPTION ' + CONVERT(varchar, @SubscriptionId); " +
        //                @"    EXEC(@Sql); " +
        //                @" " +
        //                @"    FETCH NEXT FROM SubscriptionCursor INTO @SubscriptionId; " +
        //                @"END";

        //            command.Connection = connection;
        //            command.CommandType = CommandType.Text;
        //            command.CommandText = sql;
        //            command.Parameters.Add("@UniqueTimeout", SqlDbType.Int).Value = 432000;

        //            connection.Open();

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}
         #endregion

        #region ClearNotificationQueue
        //private void ClearNotificationQueue()
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        using (var command = new SqlCommand())
        //        {
        //            string sql =
        //                @"DECLARE @Conversation AS uniqueidentifier; " +
        //                @"DECLARE ConversationCursor CURSOR LOCAL FAST_FORWARD  " +
        //                @"    FOR " +
        //                @"        SELECT CEP.conversation_handle FROM sys.conversation_endpoints CEP  " +
        //                @"        WHERE CEP.state = 'DI' or CEP.state = 'CD' " +
        //                @"     " +
        //                @"OPEN ConversationCursor; " +
        //                @"FETCH NEXT FROM ConversationCursor INTO @Conversation; " +
        //                @"WHILE @@FETCH_STATUS = 0  " +
        //                @"BEGIN " +
        //                @"    END CONVERSATION @Conversation WITH CLEANUP; " +
        //                @" " +
        //                @"    FETCH NEXT FROM ConversationCursor INTO @Conversation; " +
        //                @"END " +
        //                @"";

        //            command.Connection = connection;
        //            command.CommandType = CommandType.Text;
        //            command.CommandText = sql;

        //            connection.Open();

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}
         #endregion

        #region OnStop
        protected override void OnStop()
        {
            try
            {
                //stop polling service
                _pollingService.StopPolling();
                //System.Data.SqlClient.SqlDependency.Stop(connectionString);
            }
            catch (Exception ex)
            {
                // write error details to xml log file
                BBALogger.Write("PartIndexer Service OnStop called with error "+ex.Message, BBALogger.MsgType.Error);
            }
            // write to xml log file
            BBALogger.Write("PartIndexer Service OnStop called ", BBALogger.MsgType.Info);
            // trigger mail
            Utility.MailNotify("STOPPED");
            //base.OnStop();
        }
        #endregion
    }
}
