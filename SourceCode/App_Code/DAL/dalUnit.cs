using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;

/// <summary>
/// Summary description for dalUnit
/// </summary>
/// 
namespace DAL
{
    public class dalUnit
    {
        public dalUnit()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string UnitName, int FormationID)
        {
            SqlParameter param;
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@UnitName", UnitName));
            altParams.Add(new SqlParameter("@FormationID", FormationID));
            param = new SqlParameter("@ID", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            altParams.Add(param);
            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Unit_Insert", altParams);
            return Convert.ToInt32(param.Value);
        }

        public int Update(int UnitID, string UnitName, int FormationID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@UnitID", UnitID));
            altParams.Add(new SqlParameter("@UnitName", UnitName));
            altParams.Add(new SqlParameter("@FormationID", FormationID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Unit_Update", altParams);
        }


        public int Delete(int UnitID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@UnitID", UnitID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Unit_Delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Unit_GetAll", altParams);

        }

        public DataTable GetByDivisionID(int FormationID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@FormationID", FormationID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_Unit_GetByFormationID", altParams);

        }
        public DataTable GetByID(int UnitID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@UnitID", UnitID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Unit_GetByID", altParams);

        }
    }
}