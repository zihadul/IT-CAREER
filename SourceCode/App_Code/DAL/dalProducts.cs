using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{
    
    public class dalProducts
    {
        
        #region Method(s)

        /// <summary>
        /// Gets products list
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_products_get", altParams);
        }
        public DataTable GetListAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_products_get_all", altParams);
        }
        public DataTable GetFeaturedProductsList()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_products_get_featured", altParams);
        }

        /// <summary>
        /// Gets evolution versions 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetDemo()
        {
            ArrayList altParams = new ArrayList();

            try
            {
                return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_products_getDemo", altParams);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets latest products
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetLatest()
        {
            ArrayList altParams = new ArrayList();
           
            try
            {
                return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_products_get_latest", altParams);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets product by product id
        /// </summary>
        /// <param name="product_id">int</param>
        /// <returns>DataTable</returns>
        public DataTable GetByID(int product_id)
        {
            ArrayList altParams = new ArrayList();
           
            try
            {
                altParams.Add(new SqlParameter("@product_id", product_id));
                return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_products_getbyid", altParams);
            }
            catch (Exception)
            {
                throw;
            }

            

        }
        public DataTable GetTopN(int topN)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@topN", topN));
            try
            {

                return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_product_get_topN", altParams);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(string product_name, string summery_description, string description,
            decimal price, string category, string image_path, string original_version_path,
            string evaluation_version_path, string chm_help, string pdf_help, string tag,
            bool Featured, string features, bool visible, string url, 
            bool enablepurchase, string  overview)
        {
            ArrayList altParams = new ArrayList();
            try
            {
                altParams.Add(new SqlParameter("@product_name", product_name));
                altParams.Add(new SqlParameter("@summery_description", summery_description));
                altParams.Add(new SqlParameter("@description", description));
                altParams.Add(new SqlParameter("@price", price));
                altParams.Add(new SqlParameter("@category", category));
                altParams.Add(new SqlParameter("@image_path", image_path));
                altParams.Add(new SqlParameter("@original_version_path", original_version_path));
                altParams.Add(new SqlParameter("@evaluation_version_path", evaluation_version_path));
                altParams.Add(new SqlParameter("@chm_help", chm_help));
                altParams.Add(new SqlParameter("@pdf_help", pdf_help));
                altParams.Add(new SqlParameter("@tag", tag));
                altParams.Add(new SqlParameter("@Featured", Featured));
                altParams.Add(new SqlParameter("@features", features));
                altParams.Add(new SqlParameter("@visibility", visible));
                altParams.Add(new SqlParameter("@url", url));
                altParams.Add(new SqlParameter("@enablepurchase", enablepurchase));
                altParams.Add(new SqlParameter("@overview", overview));
                

                return  DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure ("usp_products_insert", altParams);

            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public int Update(int product_id, string product_name, string summery_description, string description,
            decimal price, string category, string image_path, string original_version_path,
            string evaluation_version_path, string chm_help, string pdf_help, string tag,
            bool Featured, string features, bool visible, string url, bool enablepurchase, string overview)
        {
            ArrayList altParams = new ArrayList();
            try
            {
                altParams.Add(new SqlParameter("@product_id", product_id));
                altParams.Add(new SqlParameter("@product_name", product_name));
                altParams.Add(new SqlParameter("@summery_description", summery_description));
                altParams.Add(new SqlParameter("@description", description));
                altParams.Add(new SqlParameter("@price", price));
                altParams.Add(new SqlParameter("@category", category));
                altParams.Add(new SqlParameter("@image_path", image_path));
                altParams.Add(new SqlParameter("@original_version_path", original_version_path));
                altParams.Add(new SqlParameter("@evaluation_version_path", evaluation_version_path));
                altParams.Add(new SqlParameter("@chm_help", chm_help));
                altParams.Add(new SqlParameter("@pdf_help", pdf_help));
                altParams.Add(new SqlParameter("@tag", tag));
                altParams.Add(new SqlParameter("@Featured", Featured));
                altParams.Add(new SqlParameter("@features", features));
                altParams.Add(new SqlParameter("@visibility", visible));
                altParams.Add(new SqlParameter("@url", url));
                altParams.Add(new SqlParameter("@enablepurchase", enablepurchase));
                altParams.Add(new SqlParameter("@overview", overview));
                
                return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_products_update", altParams);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public int Delete(int product_id)
        {
            ArrayList altParams = new ArrayList();
            try
            {
                altParams.Add(new SqlParameter("@product_id", product_id));
                return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_products_delete", altParams);
            
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        #endregion
    } //class
} //namespace