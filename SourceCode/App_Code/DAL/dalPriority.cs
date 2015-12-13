using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;


namespace DAL
{
    public class dalPriority
    {
        
        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Priority_GetAll", altParams);
            return dt;
        }
        public DataTable GetByID(int PriorityID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@PriorityID", PriorityID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Priority_GetByID", altParams);
        }

        public int Insert(string PriorityName, string Description, string ColorCode)
        {
            
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@PriorityName", PriorityName));
            altParams.Add(new SqlParameter("@Description", Description));
            altParams.Add(new SqlParameter("@ColorCode", ColorCode));
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Priority_Insert", altParams);
            return Convert.ToInt16(dt.Rows[0][0].ToString());
        }

        public int Update(int PriorityID, string PriorityName, string Description, string ColorCode)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@PriorityID", PriorityID));
            altParams.Add(new SqlParameter("@PriorityName", PriorityName));
            altParams.Add(new SqlParameter("@Description", Description));
            altParams.Add(new SqlParameter("@ColorCode", ColorCode));
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Priority_Update", altParams);
            return Convert.ToInt16(dt.Rows[0][0].ToString());
        }

        public int Delete(int PriorityID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@PriorityID", PriorityID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_Priority_Delete", altParams);

        }
    }
}
