using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{
    public class dalStatus
    {
        
        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Status_GetAll", altParams);
            return dt;
        }
        public DataTable GetByID(int StatusID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@StatusID", StatusID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Status_GetByID", altParams);
        }

        public int Insert(string StatusName, bool isDefault)
        {
            
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@StatusName", StatusName));
            altParams.Add(new SqlParameter("@isDefault", isDefault));
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Status_Insert", altParams);
            return Convert.ToInt16(dt.Rows[0][0].ToString());
        }

        public int Update(int StatusID, string StatusName, bool isDefault)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@StatusID", StatusID));
            altParams.Add(new SqlParameter("@StatusName", StatusName));
            altParams.Add(new SqlParameter("@isDefault", isDefault));
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Status_Update", altParams);
            return Convert.ToInt16(dt.Rows[0][0].ToString());
        }

        public int Delete(int StatusID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@StatusID", StatusID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_Status_Delete", altParams);

        }
    }
}
