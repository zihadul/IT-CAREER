using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;

namespace DAL
{
    /// <summary>
    /// Summary description for dalRank
    /// </summary>
    public class dalRank
    {
        public dalRank()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string RankName)
        {
            SqlParameter param;
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@RankName", RankName));
            param = new SqlParameter("@ID", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            altParams.Add(param);
            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Rank_Insert", altParams);
            return Convert.ToInt32(param.Value);
        }

        public int Update(int RankID, string RankName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@RankID", RankID));
            altParams.Add(new SqlParameter("@RankName", RankName));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Rank_Update", altParams);
        }


        public int Delete(int RankID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@RankID", RankID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Rank_delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Rank_getAll", altParams);

        }


        public DataTable GetByID(int RankID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@RankID", RankID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Rank_GetByID", altParams);

        }
    }
}