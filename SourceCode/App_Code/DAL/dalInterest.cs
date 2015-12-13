using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;

/// <summary>
/// Summary description for dalInterest
/// </summary>
/// 
namespace DAL
{
    public class dalInterest
    {
        public dalInterest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string Category,string InterestName)
        {
            SqlParameter param;
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@Category", Category));
            altParams.Add(new SqlParameter("@InterestName", InterestName));
            param = new SqlParameter("@ID", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            altParams.Add(param);
            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Interest_Insert", altParams);
            return Convert.ToInt32(param.Value);
        }

        public int Update(int InterestID,string Category, string InterestName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@InterestID", InterestID));
            altParams.Add(new SqlParameter("@Category", Category));
            altParams.Add(new SqlParameter("@InterestName", InterestName));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Interest_Update", altParams);
        }


        public int Delete(int InterestID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@InterestID", InterestID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Interest_delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Interest_getAll", altParams);

        }


        public DataTable GetByID(int InterestID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@InterestID", InterestID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Interest_GetByID", altParams);

        }
        public DataTable GetByCategory(string Category)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@Category", Category));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Interest_GetByCategory", altParams);

        }

        public DataTable InterestByCandidateID(int CandidateID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Interest_InterestByCandidateID", altParams);

        }
        public DataTable DeleteByCandidateID(int CandidateID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Interest_DeleteByCandidateID", altParams);

        }

        public int InsertCandidateInterest(string XmlData)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@xml", XmlData));
            try
            {
                //return data
                return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Interest_InsertCandidateInterest", altParams);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateCandidateInterest(string XmlData)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@xml", XmlData));
            try
            {
                //return data
                return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Interest_UpdateCandidateInterest", altParams);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}