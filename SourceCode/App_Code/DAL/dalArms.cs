using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;
/// <summary>
/// Summary description for dalArms
/// </summary>
/// 
namespace DAL
{
    public class dalArms
    {
        public dalArms()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Insert(string ArmsName)
        {
            SqlParameter param;
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@ArmsName", ArmsName));

            param = new SqlParameter("@ArmsID", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            altParams.Add(param);

            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Arms_Insert", altParams);
            return Convert.ToInt32(param.Value);

        }

        public int Update(int ArmsID, string ArmsName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ArmsID", ArmsID));
            altParams.Add(new SqlParameter("@ArmsName", ArmsName));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Arms_Update", altParams);
        }


        public int Delete(int ArmsID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ArmsID", ArmsID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Arms_delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Arms_getAll", altParams);

        }


        public DataTable GetByID(int ArmsID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ArmsID", ArmsID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Arms_GetByID", altParams);

        }
    }
}