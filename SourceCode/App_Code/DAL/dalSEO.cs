using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{

    public class dalSEO
    {
        public DataTable GetByTitle(String Title)
        {
            ArrayList altParams = new ArrayList();

            try
            {
                altParams.Add(new SqlParameter("@title", Title));
                return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_seo_get_by_title", altParams);
            }
            catch (Exception)
            {
                throw;
            }



        }

        public DataTable GetSEO()
        {
            ArrayList SEO = new ArrayList();
            DataTable p = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_seo_getall", SEO);
            return p;
        }

        public int Insert(string title, string content)
        {
            ArrayList SEO = new ArrayList();
            SEO.Add(new SqlParameter("@title", title));
            SEO.Add(new SqlParameter("@content", content));
            DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_seo_insert", SEO);
            return 1;

        }

        public int Update(int seo_id, string title, string content)
        {
            ArrayList SEO = new ArrayList();
            SEO.Add(new SqlParameter("@id", seo_id));
            SEO.Add(new SqlParameter("@title", title));
            SEO.Add(new SqlParameter("@content", content));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_seo_update", SEO);
        }

        public void Delete(int seo_id)
        {
            ArrayList SEO = new ArrayList();
            SEO.Add(new SqlParameter("@id", seo_id));
            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_seo_delete", SEO);
            return;

        }

        public DataTable GetByID(int seo_id)
        {
            ArrayList SEO = new ArrayList();
            SEO.Add(new SqlParameter("@id", seo_id));
            DataTable infoTable = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_seo_getbyid", SEO);
            return infoTable;
        }
    }
}