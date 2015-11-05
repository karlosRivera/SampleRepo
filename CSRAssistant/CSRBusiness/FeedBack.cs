using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BBA.DAL;

namespace CSRBusiness
{
    public class FeedBack
    {
        public Messages LoadData(string StartDate, string EndDate, int ExcludeCallData, string CustName, int PageNumber, int PageSize, bool isExport, string JID, string RStartDate, string REndDate, int IsRepaired, int RangeExclude = 0)
        {
            Messages oErrMsg = Messages.Instance;

            DataSet ds = new DataSet();
            SqlParameter[] cparams = null;
            if (!isExport)
                cparams = new SqlParameter[11];
            else
                cparams = new SqlParameter[9];

            SqlParameter param;
            if (!isExport)
            {
                param = new SqlParameter("@StartDate", StartDate);
                param.DbType = DbType.String;
                cparams[0] = param;

                param = new SqlParameter("@EndDate", EndDate);
                param.DbType = DbType.String;
                cparams[1] = param;

                param = new SqlParameter("@ExcludeCallData", ExcludeCallData);
                param.DbType = DbType.Int32;
                cparams[2] = param;

                param = new SqlParameter("@CustName", CustName.Trim());
                param.DbType = DbType.String;
                cparams[3] = param;

                param = new SqlParameter("@JID", Utils.RemoveFirstLastChar(JID));
                param.DbType = DbType.String;
                cparams[4] = param;

                param = new SqlParameter("@PageSize", 20);
                param.DbType = DbType.Int32;
                cparams[5] = param;

                param = new SqlParameter("@PageNumber", PageNumber);
                param.DbType = DbType.Int32;
                cparams[6] = param;

                param = new SqlParameter("@RangeExclude", RangeExclude);
                param.DbType = DbType.Int32;
                cparams[7] = param;

                param = new SqlParameter("@RStartDate", RStartDate);
                param.DbType = DbType.String;
                cparams[8] = param;

                param = new SqlParameter("@REndDate", RStartDate);
                param.DbType = DbType.String;
                cparams[9] = param;

                param = new SqlParameter("@IsRepaired", IsRepaired);
                param.DbType = DbType.Int32;
                cparams[10] = param;

                try
                {
                    ds = SqlHelper.Fill(ds, "DynamicOurdata", cparams, User.ConnectionString);
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

            }
            else
            {
                param = new SqlParameter("@StartDate", StartDate);
                param.DbType = DbType.String;
                cparams[0] = param;

                param = new SqlParameter("@EndDate", EndDate);
                param.DbType = DbType.String;
                cparams[1] = param;

                param = new SqlParameter("@ExcludeCallData", ExcludeCallData);
                param.DbType = DbType.Int32;
                cparams[2] = param;

                param = new SqlParameter("@CustName", CustName.Trim());
                param.DbType = DbType.String;
                cparams[3] = param;

                param = new SqlParameter("@JID", Utils.RemoveFirstLastChar(JID));
                param.DbType = DbType.String;
                cparams[4] = param;

                param = new SqlParameter("@RangeExclude", RangeExclude);
                param.DbType = DbType.Int32;
                cparams[5] = param;

                param = new SqlParameter("@RStartDate", RStartDate);
                param.DbType = DbType.String;
                cparams[6] = param;

                param = new SqlParameter("@REndDate", RStartDate);
                param.DbType = DbType.String;
                cparams[7] = param;

                param = new SqlParameter("@IsRepaired", IsRepaired);
                param.DbType = DbType.Int32;
                cparams[8] = param;

                try
                {
                    ds = SqlHelper.Fill(ds, "DynamicOurdataExport", cparams, User.ConnectionString);
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

            }

            return oErrMsg;
        }

        public Messages LoadRating(string StartDate, string EndDate, string Rating, int EmptyComments, int PageSize, int PageNumber)
        {
            Messages oErrMsg = Messages.Instance;
            DataSet ds = new DataSet();

            SqlParameter[] cparams = null;
            cparams = new SqlParameter[6];

            SqlParameter param;
            param = new SqlParameter("@StartDate", StartDate);
            param.DbType = DbType.String;
            cparams[0] = param;

            param = new SqlParameter("@EndDate", EndDate);
            param.DbType = DbType.String;
            cparams[1] = param;

            param = new SqlParameter("@Rating", Rating);
            param.DbType = DbType.String;
            cparams[2] = param;

            param = new SqlParameter("@EmptyComments", EmptyComments);
            param.DbType = DbType.Int32;
            cparams[3] = param;

            param = new SqlParameter("@PageSize", PageSize);
            param.DbType = DbType.Int32;
            cparams[4] = param;

            param = new SqlParameter("@PageNumber", PageNumber);
            param.DbType = DbType.Int32;
            cparams[5] = param;

            try
            {
                ds = SqlHelper.Fill(ds, "RatingWiseSearch", cparams, User.ConnectionString);
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

        public Messages UpdateFeedBack(int JID, string Rating, string Comments, string AccountRef, string OERef)
        {
            Messages oErrMsg = Messages.Instance;
            DataSet ds = new DataSet();

            SqlParameter[] cparams = new SqlParameter[5];
            SqlParameter param;
            param = new SqlParameter("@JID", JID);
            param.DbType = DbType.Int32;
            cparams[0] = param;

            param = new SqlParameter("@Rating", Rating);
            param.DbType = DbType.String;
            cparams[1] = param;

            param = new SqlParameter("@Comments", Comments);
            param.DbType = DbType.String;
            cparams[2] = param;

            param = new SqlParameter("@AccountRef", AccountRef);
            param.DbType = DbType.String;
            cparams[3] = param;

            param = new SqlParameter("@OERef", OERef);
            param.DbType = DbType.String;
            cparams[4] = param;

            try
            {
                ds = SqlHelper.Fill(ds, "USP_UpdateOURFeedback", cparams, User.ConnectionString);
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
    }
}
