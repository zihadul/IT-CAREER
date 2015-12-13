using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;

/// <summary>
/// Summary description for dalArmyPrefix
/// </summary>
/// 
namespace DAL
{
    public class dalArmyPrefix
    {
        public dalArmyPrefix()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string PrefixName)
        {
            SqlParameter param;
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@PrefixName", PrefixName));
            param = new SqlParameter("@ID", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            altParams.Add(param);
            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_ArmyPrefix_Insert", altParams);
            return Convert.ToInt32(param.Value);

        }

        public int Update(int ArmyPrefixID, string PrefixName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ArmyPrefixID", ArmyPrefixID));
            altParams.Add(new SqlParameter("@PrefixName", PrefixName));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_ArmyPrefix_Update", altParams);
        }


        public int Delete(int ArmyPrefixID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ArmyPrefixID", ArmyPrefixID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_ArmyPrefix_Delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_ArmyPrefix_GetAll", altParams);

        }


        public DataTable GetByID(int ArmyPrefixID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ArmyPrefixID", ArmyPrefixID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_ArmyPrefix_GetByID", altParams);

        }
    }
}