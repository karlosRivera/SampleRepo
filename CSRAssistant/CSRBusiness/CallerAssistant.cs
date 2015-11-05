using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BBA.DAL;
using System.Data.Odbc;
using System.Windows.Forms;

namespace CSRBusiness
{
    public class CallerAssistant
    {
        public Messages LoadData(string JID, string TrackNo, int PageNumber, int PageSize, int isExport)
        {
            Messages oErrMsg = Messages.Instance;

            DataSet ds = new DataSet();
            SqlParameter[] cparams = null;
            cparams = new SqlParameter[5];

            SqlParameter param;
            param = new SqlParameter("@JID", Utils.RemoveFirstLastChar(JID));
            param.DbType = DbType.String;
            cparams[0] = param;

            param = new SqlParameter("@TrackNo", Utils.RemoveFirstLastChar(TrackNo));
            param.DbType = DbType.String;
            cparams[1] = param;


            param = new SqlParameter("@PageSize", PageSize);
            param.DbType = DbType.Int32;
            cparams[2] = param;

            param = new SqlParameter("@PageNumber", PageNumber);
            param.DbType = DbType.Int32;
            cparams[3] = param;

            param = new SqlParameter("@isExport", isExport);
            param.DbType = DbType.Int32;
            cparams[4] = param;

            try
            {
                ds = SqlHelper.Fill(ds, "SearchByJID", cparams, User.ConnectionString);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        ds.Tables[0].TableName = "data";
                    }

                    if (ds.Tables[1] != null)
                    {
                        ds.Tables[1].TableName = "counter";
                    }

                }
                oErrMsg.IsError = false;
                oErrMsg.Results = ds;
            }
            catch (Exception ex)
            {
                oErrMsg.IsError = true;
                oErrMsg.Message = ex.Message.ToString();
            }

            return oErrMsg;
        }

        public Messages LoadData(string KeyWord, string StartDate, string EndDate, int isExport)
        {
            Messages oErrMsg = Messages.Instance;

            DataSet ds = new DataSet();
            SqlParameter[] cparams = null;
            cparams = new SqlParameter[4];

            SqlParameter param;
            param = new SqlParameter("@KeyWord", KeyWord);
            param.DbType = DbType.String;
            cparams[0] = param;

            param = new SqlParameter("@StartDate", StartDate);
            param.DbType = DbType.String;
            cparams[1] = param;

            param = new SqlParameter("@EndDate", EndDate);
            param.DbType = DbType.String;
            cparams[2] = param;

            param = new SqlParameter("@isExport", isExport);
            param.DbType = DbType.Int32;
            cparams[3] = param;

            try
            {
                ds = SqlHelper.Fill(ds, "SearchByMisc", cparams, User.ConnectionString);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        ds.Tables[0].TableName = "data";
                    }
                }
                oErrMsg.IsError = false;
                oErrMsg.Results = ds;
            }
            catch (Exception ex)
            {
                oErrMsg.IsError = true;
                oErrMsg.Message = ex.Message.ToString();
            }

            return oErrMsg;
        }

        public Messages GetAddress(string AccRef, bool phone)
        {
            Messages oMsg = Messages.Instance;
            string address = string.Empty;
            OdbcConnection oConn = new OdbcConnection("DSN=SageLine50v15;UID=manager;");
            OdbcDataReader dr;
            OdbcCommand comm = new OdbcCommand("select ADDRESS_1,ADDRESS_2,ADDRESS_3,ADDRESS_4,ADDRESS_5,TELEPHONE,E_MAIL from Sales_Ledger where ACCOUNT_REF='" + AccRef + "'", oConn);

            DataTable customerTable = new DataTable();

            customerTable.Columns.Add("Address_1");
            customerTable.Columns.Add("Address_2");
            customerTable.Columns.Add("Address_3");
            customerTable.Columns.Add("Address_4");
            customerTable.Columns.Add("Address_5");
            customerTable.Columns.Add("Telephone");
            customerTable.Columns.Add("Email");

            try
            {
                comm.CommandType = CommandType.Text;
                oConn.Open();
                dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    DataRow dRow = customerTable.NewRow();

                    try
                    {
                        dRow[0] = dr["ADDRESS_1"].ToString();
                    }
                    catch
                    {
                        dRow[0] = "";
                    }
                    try
                    {
                        dRow[1] = dr["ADDRESS_2"].ToString();
                    }
                    catch
                    {
                        dRow[1] = "";
                    }
                    try
                    {

                        dRow[2] = dr["ADDRESS_3"].ToString();
                    }
                    catch
                    {
                        dRow[2] = "";
                    }
                    try
                    {

                        dRow[3] = dr["ADDRESS_4"].ToString();
                    }
                    catch
                    {
                        dRow[3] = "";
                    }
                    try
                    {

                        dRow[4] = dr["ADDRESS_5"].ToString();
                    }
                    catch
                    {
                        dRow[4] = "";
                    }
                    try
                    {
                        dRow[5] = dr["TELEPHONE"].ToString();
                    }
                    catch
                    {
                        dRow[5] = "";
                    }

                    try
                    {
                        dRow[6] = dr["E_MAIL"].ToString();
                    }
                    catch
                    {
                        dRow[6] = "";
                    }

                    customerTable.Rows.Add(dRow);
                }
                oMsg.IsError = false;
            }
            catch (Exception ex)
            {
                oMsg.IsError = true;
                oMsg.Message = "Problem with Sage or Sage not installed.\n" + ex.Message;
            }

            if (customerTable.Rows.Count > 0)
            {
                if (!phone)
                {
                    for (int x = 0; x < customerTable.Columns.Count - 1; x++)
                    {
                        if (customerTable.Rows[0][x].ToString() != System.DBNull.Value.ToString())
                        {
                            address = address + customerTable.Rows[0][x].ToString() + System.Environment.NewLine;
                        }
                    }
                }
                else
                {
                    address = customerTable.Rows[0][5].ToString();
                }

            }
            else
            {
                address = "No information found.";
            }
            oMsg.Results = address;
            return oMsg;
        }

        public Messages GetAddressUSA(string AccRef, bool phone)
        {
            string address = string.Empty;
            Messages oMsg = Messages.Instance;
            SqlConnection DataCon = new SqlConnection(User.ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter("SELECT [BillAddressAddr1],[BillAddressAddr2],[BillAddressAddr3],[BillAddressAddr4],[BillAddressCity],[BillAddressState],[BillAddressPostalCode],[BillAddressCountry],[Email],[Phone] from CustomerUSA where listid='" + AccRef + "'", DataCon);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                oMsg.IsError = false;
            }
            catch(Exception ex) {
                oMsg.IsError = true;
                oMsg.Message = "Error "+ex.Message;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!phone)
                {
                    for (int x = 0; x < ds.Tables[0].Columns.Count - 1; x++)
                    {
                        if (ds.Tables[0].Rows[0][x].ToString() != System.DBNull.Value.ToString())
                        {
                            address = address + ds.Tables[0].Rows[0][x].ToString() + System.Environment.NewLine;
                        }
                    }
                }
                else
                    address = ds.Tables[0].Rows[0]["Phone"].ToString();

                //address=ds.Tables[0].Rows[0]["BillAddressAddr1"].ToString()+System.Environment.NewLine+ds.Tables[0].Rows[0]["BillAddressAddr2"].ToString()+System.Environment.NewLine+ds.Tables[0].Rows[0]["BillAddressAddr3"].ToString()+System.Environment.NewLine+ds.Tables[0].Rows[0]["BillAddressAddr4"].ToString()+System.Environment.NewLine+ds.Tables[0].Rows[0]["BillAddressCity"].ToString()+System.Environment.NewLine+ds.Tables[0].Rows[0]["BillAddressState"].ToString()+System.Environment.NewLine+ds.Tables[0].Rows[0]["BillAddressPostalCode"].ToString()+System.Environment.NewLine+ds.Tables[0].Rows[0]["BillAddressCountry"].ToString();
            }
            else
                address = "No information found.";

            oMsg.Results = address;
            return oMsg;

        }

        public Messages GetShippingInfo(string jid)
        {
            Messages oMsg = Messages.Instance;
            SqlConnection DataCon = new SqlConnection(User.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("Select JID,trackno as NormalTrackNo from trackdetail where jid='" + jid + "' and tracktype='N';Select JID,trackno as ReturnTrackNo from trackdetail where jid='" + jid + "' and tracktype='R'", DataCon);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                oMsg.IsError = false;
                oMsg.Results = ds;
            }
            catch (Exception ex)
            {
                oMsg.IsError = true;
                oMsg.Message = "Error " + ex.Message;
            }
            finally
            {
                DataCon.Close();
            }
            return oMsg;

        }

        public Messages LoadRemarks(int jobId, bool shop)
        {
            Messages oMsg = Messages.Instance;
            SqlConnection DataCon = new SqlConnection(User.ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_CoreCollectionUpdates", DataCon);
            string remarks = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet rem = new DataSet();
            DataSet shopRem = new DataSet();
            SqlParameter param = new SqlParameter("@DMLType", SqlDbType.Int);

            if (!shop)
            {
                param.Value = 2;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@jid", SqlDbType.Int);
                param.Value = jobId;
                cmd.Parameters.Add(param);

                try
                {
                    DataCon.Open();
                    da.Fill(rem);
                    DataCon.Close();
                    oMsg.IsError = false;
                }
                catch (Exception ex)
                {
                    oMsg.IsError = true;
                    oMsg.Message = "Error " + ex.Message;
                    if (DataCon.State == ConnectionState.Open)
                        DataCon.Close();
                }

                if (rem.Tables.Count > 0)
                {
                    if (rem.Tables[0].Rows.Count > 0)
                    {
                        for (int x = 0; x < rem.Tables[0].Rows.Count; x++)
                        {
                            if (rem.Tables[0].Rows[x]["Remarks"].ToString() != "" && rem.Tables[0].Rows[x]["Remarks"].ToString() != System.DBNull.Value.ToString())
                            {
                                remarks += rem.Tables[0].Rows[x]["UpdateTime"].ToString() + System.Environment.NewLine + rem.Tables[0].Rows[x]["Remarks"].ToString() + System.Environment.NewLine;
                                remarks += "===============================";
                            }
                            else
                                remarks = "No remarks exists for this job.";
                        }
                    }
                    else
                        remarks = "No remarks exists for this job.";
                }
                else
                    remarks = "No remarks exists for this job.";
                oMsg.Results = remarks;
            }

            else
            {
                cmd = new SqlCommand("sp_CoreCollectionUpdates", DataCon);
                cmd.CommandType = CommandType.StoredProcedure;
                param = new SqlParameter("@DMLType", SqlDbType.Int);
                param.Value = 3;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@jid", SqlDbType.Int);
                param.Value = jobId;
                cmd.Parameters.Add(param);

                da = new SqlDataAdapter(cmd);
                try
                {
                    DataCon.Open();
                    da.Fill(shopRem);
                    DataCon.Close();
                    oMsg.IsError = false;
                }
                catch (Exception ex)
                {
                    oMsg.IsError = true;
                    oMsg.Message = "Error " + ex.Message;
                    if (DataCon.State == ConnectionState.Open)
                        DataCon.Close();
                }
                if (shopRem.Tables.Count > 0)
                {
                    if (shopRem.Tables[0].Rows.Count > 0)
                    {
                        for (int x = 0; x < shopRem.Tables[0].Rows.Count; x++)
                        {
                            if (shopRem.Tables[0].Rows[x]["ShopRemarks"].ToString() != "" && shopRem.Tables[0].Rows[x]["ShopRemarks"].ToString() != System.DBNull.Value.ToString())
                            {
                                remarks += shopRem.Tables[0].Rows[x]["UpdateTime"].ToString() + System.Environment.NewLine + shopRem.Tables[0].Rows[x]["ShopRemarks"].ToString() + System.Environment.NewLine;
                                remarks += "===============================";
                            }
                            else
                                remarks = "No remarks exists for this job.";
                        }
                    }
                    else
                        remarks = "No remarks exists for this job.";
                }
                else
                    remarks = "No remarks exists for this job.";

                oMsg.Results = remarks;
            }
            return oMsg;
        }

        public bool SaveCallRem(string JID, string callno, string rem, string status, string OEReference, string shopRemarks)
        {
            bool jobDone = false;
            SqlConnection DataCon = new SqlConnection(User.ConnectionString);

            if (status == "Done" || status == "Done & Shipped")
                jobDone = true;
            SqlCommand cmd1 = new SqlCommand("insert into CallRem (jid,callno,rem,callStatus,CallDate,OEReference,ShopRemarks,CallClosedBy,CallClosedDate) values ('" + JID + "','" + callno + "','" + rem + "','" + status + "','" + DateTime.Now.ToShortDateString() + "','" + OEReference + "','" + shopRemarks + "','" + (jobDone ? "Core Collector" : System.DBNull.Value.ToString()) + "','" + (jobDone ? System.DateTime.Now.ToShortDateString() : System.DBNull.Value.ToString()) + "')", DataCon);

            SqlCommand cmd2 = new SqlCommand("update BBAJobs set JobState = 'DONE' where JID =" + JID, DataCon);
            SqlCommand cmd3 = new SqlCommand("delete from CallRem where JID =" + JID, DataCon);
            SqlCommand cmd4 = new SqlCommand("sp_CoreCollectionUpdates", DataCon);
            SqlCommand cmd5 = new SqlCommand("sp_CoreCollectionUpdates", DataCon);
            cmd5.CommandType = CommandType.StoredProcedure;
            cmd4.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();


            param.ParameterName = "@jid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = JID;

            cmd4.Parameters.Add(param);

            param = new SqlParameter("@Username", SqlDbType.VarChar);
            param.Value = User.UserName;
            cmd4.Parameters.Add(param);

            param = new SqlParameter("@DMLType", SqlDbType.Int);
            param.Value = 0;
            cmd4.Parameters.Add(param);

            SqlParameter param1 = new SqlParameter("@DMLType", SqlDbType.Int);
            int i = 1;
            param1.Value = i;
            cmd5.Parameters.Add(param1);
            param1 = new SqlParameter("@Jid", SqlDbType.Int);
            param1.Value = JID;
            cmd5.Parameters.Add(param1);

            param1 = new SqlParameter("@remarks", SqlDbType.VarChar);
            param1.Value = rem;
            cmd5.Parameters.Add(param1);

            try
            {
                DataCon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            SqlTransaction tran = DataCon.BeginTransaction();
            //cmd.Transaction = tran;
            cmd1.Transaction = tran;
            cmd2.Transaction = tran;
            cmd3.Transaction = tran;
            cmd4.Transaction = tran;
            cmd5.Transaction = tran;

            try
            {
                if (status == "Done" || status == "Done & Shipped")
                {
                    cmd2.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                }
                if (status == "Not Done")
                {
                    cmd3.ExecuteNonQuery();
                }
                if (status == "Call Back")
                {
                    cmd3.ExecuteNonQuery();
                }
                if (status == "Escalated")
                {
                    cmd3.ExecuteNonQuery();
                }
                cmd1.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();

                tran.Commit();
                int x = 0;

                DataCon.Close();
                DialogResult result = MessageBox.Show("Was the call answered?", "CSR Assistance", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                    UpdateCallStats(true, true, int.Parse(JID));
                else if (result == DialogResult.No)
                    UpdateCallStats(true, false, int.Parse(JID));
                else
                    x = 1 + 1;
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void UpdateCallStats(bool dialled, bool answered, int jid)
        {
            int y = 0;
            SqlConnection DataCon = new SqlConnection(User.ConnectionString);

            string sql = "update callrem set [CallDone]=" + (dialled ? 1 : 0) + ",CallDate='" + DateTime.Now.ToShortDateString() + "',[CallAnswered]=" + (answered ? 1 : 0) + " where jid='" + jid + "'";
            SqlCommand comm = new SqlCommand(sql);
            comm.Connection = DataCon;
            try
            {
                DataCon.Open();
                y = comm.ExecuteNonQuery();
                DataCon.Close();
                //MessageBox.Show(y.ToString());
            }
            catch (Exception ex)
            {
                if (DataCon.State == ConnectionState.Open)
                    DataCon.Close();
                MessageBox.Show(ex.Message);

            }
        }
    }
}

