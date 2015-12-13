using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;


/// <summary>
/// Summary description for dalInstitution
/// </summary>
/// 
namespace DAL
{
    public class dalInstitution
    {
        public dalInstitution()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string InstitutionName)
        {
            SqlParameter param;
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@InstitutionName", InstitutionName));
            param = new SqlParameter("@ID", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            altParams.Add(param);
            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Institution_Insert", altParams);
            return Convert.ToInt32(param.Value);

        }

        public int Update(int InstitutionID, string InstitutionName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@InstitutionID", InstitutionID));
            altParams.Add(new SqlParameter("@InstitutionName", InstitutionName));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Institution_Update", altParams);
        }


        public int Delete(int InstitutionID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@InstitutionID", InstitutionID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Institution_delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Institution_getAll", altParams);

        }


        public DataTable GetByID(int InstitutionID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@InstitutionID", InstitutionID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Institution_GetByID", altParams);

        }
    }
}