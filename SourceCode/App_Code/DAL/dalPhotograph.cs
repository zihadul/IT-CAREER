using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;
using System;


namespace DAL
{
    public class dalPhotograph
    {

        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_photograph_getall", altParams);
            return dt;
        }

        public DataTable GetByProductID(int productid)
        {

            ArrayList altParams = new ArrayList
                                      {
                                          new SqlParameter("@productid", productid)
                                      };

            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_photograph_getbyproduct", altParams);
            return dt;
        }


        

      

        public DataTable GetById(int photographid)
        {
            ArrayList altParams = new ArrayList { new SqlParameter("@photographid", photographid) };
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_photograph_getbyid", altParams);
        }



        public int Update(int photographid, string photographName, string filename, string description, int productid)
        {
            ArrayList altParams = new ArrayList
                                      {
                                          new SqlParameter("@photographid", photographid),
                                          new SqlParameter("@photographName", photographName),
                                          new SqlParameter("@filenameX", filename),
                                          new SqlParameter("@description", description),
                                          new SqlParameter("@productid", productid)
                                      };

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_photograph_update", altParams);
        }

        public int Insert(string photographName, string filename, string description, int productid)
        {
            ArrayList altParams = new ArrayList
                                      { 
                                          new SqlParameter("@photographName", photographName),
                                          new SqlParameter("@filenameX", filename),
                                          new SqlParameter("@description", description),
                                          new SqlParameter("@productid", productid)
                                      };

            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_photograph_insert",
                                                                                       altParams);
            return Convert.ToInt32(dt.Rows[0][0].ToString());

        }

        public int Delete(int photographid)
        {
            ArrayList altParams = new ArrayList {new SqlParameter("@photographid", photographid)};
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_photograph_delete", altParams);
        }


    }
}
