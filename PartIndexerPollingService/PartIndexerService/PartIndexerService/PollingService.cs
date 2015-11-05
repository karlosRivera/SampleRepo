using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Data.SqlClient;

namespace PartIndexerService
{
    #region PollingService
    /// <summary>
    /// this class will create a thread which will poll a functionality  
    /// polling function will hit db table after every 1 hour to detect the data change
    /// if data change found in table then web service is called to reindex part data
    /// </summary>
    public class PollingService
    {
        private Thread _workerThread;
        private AutoResetEvent _finished;
        private const int _timeout = (60 * 60) * 1000; 
        private string ConnectionString = "server=sql08-2.orcsweb.com;uid=bba-reman;password=_bba_1227_kol;database=BBAreman;Pooling=true;Connect Timeout=20;";

        #region StartPolling
        /// <summary>
        /// Constructor from where thread will start and Poll function will be called
        /// </summary>
        public void StartPolling()
        {
            //start the thread which will call poll function
            _workerThread = new Thread(Poll);
            _finished = new AutoResetEvent(false);
            _workerThread.Start();
        }
        #endregion 

        #region Poll
        /// <summary>
        /// poll function will call HasDataChanged function after ever 1 hours
        /// </summary>
         private void Poll()
        {
            // while loop will iterate untill AutoResetEvent will show the signal by _finished.Set();
            while (!_finished.WaitOne(_timeout))
            {
                HasDataChanged();
            }
        }
        #endregion 

         #region HasDataChanged
         /// <summary>
         /// HasDataChanged function will fetch data from ContentChangeLog 
         /// table to determine any change is there in data
         /// if ata change found then it will call two function called StartIndex and ResetDBFlag;
         /// </summary>
        void HasDataChanged()
        {
            bool Hasfound = false;
            List<string> oList = new List<string>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT ID FROM ContentChangeLog where action in ('D','I','U') ",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Hasfound = true;
                    while (reader.Read())
                    {
                        if (reader["ID"] != DBNull.Value)
                        {
                            oList.Add(reader["ID"].ToString());
                        }
                    }
                }
                else
                {
                    Hasfound = false;
                }
                reader.Close();

                if (Hasfound)
                {
                    BBALogger.Write("HasDataChanged data change found", BBALogger.MsgType.Info);
                    StartIndex();
                    ResetDBFlag(oList);
                }
            }
        }
         #endregion

        #region ResetDBFlag
        /// <summary>
        /// ResetDBFlag set empty value in action field of ContentChangeLog table
        /// </summary>
        /// <param name="oList"></param>
        private void ResetDBFlag(List<string> oList)
        {
            SqlConnection Connection;
            SqlCommand cmd;
            string sql = null;

            sql = "update [ContentChangeLog] set action='' where ID  IN ('" + (string.Join("','", oList.Select(x => x.ToString()).ToArray())) + "')";

            Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
                cmd = new SqlCommand(sql, Connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Connection.Close();
                Connection.Dispose();
                BBALogger.Write("ResetDBFlag DB flag updated", BBALogger.MsgType.Info);

            }
            catch (Exception ex)
            {
                BBALogger.Write("ResetDBFlag Exception"+ex.Message, BBALogger.MsgType.Info);
            }
        }
        #endregion

        #region StartIndex
        /// <summary>
        /// StartIndex
        /// this routine will call web service in bba reman website which will invoke routine to re-index data 
        /// </summary>
        void StartIndex()
        {
            BBALogger.Write("PartIndexer Service StartIndex called start", BBALogger.MsgType.Info);

            PartIndexerWS.AuthHeader oAuth = new PartIndexerWS.AuthHeader();
            oAuth.Username = "UID_BBAAdmin2015";
            oAuth.Password = "PWD_BBAAdmin2015";

            PartIndexerWS.SearchDataIndexSoapClient DataIndex = new PartIndexerWS.SearchDataIndexSoapClient();

            try
            {
                string strRetVal = DataIndex.StartIndex(oAuth);
                Utility.MailNotify("TRIGGER");

            }
            catch (Exception ex)
            {
                BBALogger.Write("PartIndexer Service StartIndex called error " + ex.Message, BBALogger.MsgType.Error);
                Utility.MailNotify("TRIGGER_ERROR", ex.Message.ToString());
            }
            finally
            {
                BBALogger.Write("PartIndexer Service StartIndex called end", BBALogger.MsgType.Info);
            }

        }
        #endregion

        #region StopPolling
        /// <summary>
        /// StopPolling pass signal to Poll function as a result
        /// controls comes out from while loop and also stop the thread
        /// </summary>
        public void StopPolling()
        {
            BBALogger.Write("StopPolling called start", BBALogger.MsgType.Info);
            _finished.Set();
            _workerThread.Join();
            BBALogger.Write("StopPolling called end", BBALogger.MsgType.Info);
        }
        #endregion
    }
    #endregion
}
