using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;
/// <summary>
/// Summary description for dalFormation
/// </summary>
/// 
namespace DAL
{
    public class dalFormation
    {
        public dalFormation()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string FormationName)
        {
            SqlParameter param;
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@FormationName", FormationName));
            param = new SqlParameter("@ID", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            altParams.Add(param);
            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Formation_Insert", altParams);
            return Convert.ToInt32(param.Value);

        }

        public int Update(int FormationID, string FormationName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@FormationID", FormationID));
            altParams.Add(new SqlParameter("@FormationName", FormationName));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Formation_Update", altParams);
        }


        public int Delete(int FormationID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@FormationID", FormationID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Formation_delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Formation_getAll", altParams);

        }


        public DataTable GetByID(int FormationID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@FormationID", FormationID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Formation_GetByID", altParams);

        }
    }
}