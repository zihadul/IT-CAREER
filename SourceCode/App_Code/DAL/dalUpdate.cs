using System;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;


namespace DAL
{
    public class dalUpdate
    {
      
        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Update_getall",
                                                                                         altParams);
            return dt;
        }

        public DataTable GetByID(int ID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@ID", ID));
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Update_getbyid",
                                                                                         altParams);
            return dt;
        }

        public DataTable GetLatest()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Update_getlatest", altParams);
        }

        public int Insert(string Title, DateTime Date, string Details, string AttachmentName, bool isFeatured)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@Title", Title));
            altParams.Add(new SqlParameter("@Date", Date));
            altParams.Add(new SqlParameter("@Details", Details));
            altParams.Add(new SqlParameter("@AttachmentName", AttachmentName));
            altParams.Add(new SqlParameter("@IsFeatured", isFeatured));

            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Update_insert",
                                                                                         altParams);
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        public int Update(int ID, string Title, DateTime Date, string Details, string AttachmentName, bool isFeatured)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@ID", ID));
            altParams.Add(new SqlParameter("@Title", Title));
            altParams.Add(new SqlParameter("@Date", Date));
            altParams.Add(new SqlParameter("@Details", Details));
            altParams.Add(new SqlParameter("@AttachmentName", AttachmentName));
            altParams.Add(new SqlParameter("@IsFeatured", isFeatured));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Update_update", altParams);
        }

        public int Delete(int ID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@ID", ID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Update_delete", altParams);
        }

        
    }
}