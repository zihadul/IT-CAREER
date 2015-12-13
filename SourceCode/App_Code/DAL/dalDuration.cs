using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;


/// <summary>
/// Summary description for dalDuration
/// </summary>
/// 
namespace DAL
{
    public class dalDuration
    {
        public dalDuration()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string Duration)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@Duration", Duration));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Duration_Insert", altParams);

        }

        public int Update(int DurationID, string Duration)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@DurationID", DurationID));
            altParams.Add(new SqlParameter("@Duration", Duration));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Duration_Update", altParams);
        }


        public int Delete(int DurationID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@DurationID", DurationID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Duration_delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Duration_getAll", altParams);

        }


        public DataTable GetByID(int DurationID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@DurationID", DurationID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Duration_GetByID", altParams);

        }
    }
}