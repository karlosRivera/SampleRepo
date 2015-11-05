using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BBA.DAL;

namespace CSRBusiness
{
    public class CallStat
    {
        public Messages LoadData(string strDate)
        {
            Messages oErrMsg = Messages.Instance;

            DataSet ds = new DataSet();
            SqlParameter[] cparams = null;
            cparams = new SqlParameter[1];

            SqlParameter param;
            param = new SqlParameter("@CallDate", strDate);
            param.DbType = DbType.String;
            cparams[0] = param;

            try
            {
                ds = SqlHelper.Fill(ds, "CallStat", cparams, User.ConnectionString);
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
    }
}
