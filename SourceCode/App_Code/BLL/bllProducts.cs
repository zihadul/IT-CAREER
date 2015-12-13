using System;
using System.Data;
using DAL;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace BLL
{

    public class bllProducts
    {

        private static ICacheManager cacheProduct = CacheFactory.GetCacheManager("CacheProduct");
        dalProducts objProduct = new dalProducts(); // Object to access DAL.
       

        #region Data Retrival and Manipulation Method(s)

      
        
        public DataTable GetList()
        {
            DataTable dt = (DataTable)cacheProduct.GetData("cacheProductsGetVisible");
            if (dt == null)
            {
                dt = objProduct.GetList();
                cacheProduct.Add("cacheProductsGetVisible", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            return dt;
        }
        public DataTable GetListAll()
        {
            DataTable dt = (DataTable)cacheProduct.GetData("cacheProductsGetAll");
            if (dt == null)
            {
                dt = objProduct.GetList();
                cacheProduct.Add("cacheProductsGetAll", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            return dt;
        }
        public DataTable GetTopN(int topN)
        {
            try
            {
                DataTable dt = (DataTable)cacheProduct.GetData("GetTopN" + topN.ToString());

                if (dt == null)
                {
                    dt = objProduct.GetTopN(topN);
                    cacheProduct.Add("GetTopN" + topN.ToString(), dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
                }
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable GetFeaturedProductsList()
        {
            try
            {
                DataTable dt = (DataTable)cacheProduct.GetData("GetFeaturedProductsList");

                if (dt == null)
                {

                    dt = objProduct.GetFeaturedProductsList();
                    cacheProduct.Add("GetFeaturedProductsList", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
                }
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }


       


        /// <summary>
        /// Gets evolution versions 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetDemo()
        {
            try
            {

                DataTable dt = (DataTable)cacheProduct.GetData("cacheProductsDemo");
                if (dt == null)
                {
                    dt = objProduct.GetDemo();
                    cacheProduct.Add("cacheProductsDemo", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
                   
                }
                return dt;
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
            try
            {
                DataTable dt = (DataTable)cacheProduct.GetData("cacheProductsLatest");
                if (dt == null)
                {

                    dt = objProduct.GetLatest();
                    cacheProduct.Add("cacheProductsLatest", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
                    //cacheProduct.Add("cacheProductsLatest", dt);
                }
                return dt;
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
            try
            {
                cacheProduct.Flush();
                DataTable dt = (DataTable)cacheProduct.GetData("cacheProductsByID" + product_id.ToString());
                if (dt == null)
                {
                    dt = objProduct.GetByID(product_id);
                    cacheProduct.Add("cacheProductsByID", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
                    //cacheProduct.Add("cacheProduct" + product_id.ToString(), dt);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Insert(string product_name, string summery_description, string description,
            decimal price, string category, string image_path, string original_version_path,
            string evaluation_version_path, string chm_help, string pdf_help, string tag,
            bool Featured, string features, bool visible, string url, bool enablepurchase, string overview)
        {
            try
            {
                cacheProduct.Flush();
                return objProduct.Insert(product_name, summery_description, description, price, category,
                    image_path, original_version_path, evaluation_version_path, chm_help, pdf_help,
                    tag, Featured, features, visible, url, enablepurchase, overview);


            }
            catch (Exception)
            {
                throw;
            }
           
           

        }

        public int Update(int product_id, string product_name, string summery_description, string description,
            decimal price, string category, string image_path, string original_version_path,
            string evaluation_version_path, string chm_help, string pdf_help,
            string tag, bool Featured, string features, bool visible, string url, bool enablepurchase, string overview)
        {
            try
            {
                cacheProduct.Flush();
                return objProduct.Update(product_id, product_name, summery_description, description, price, category,
                    image_path, original_version_path, evaluation_version_path,
                    chm_help, pdf_help, tag, Featured, features, visible, url, enablepurchase, overview);
                
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        /// <summary>
        /// Delete product information by product id
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns>How many rows effected</returns>
        public int Delete(int product_id)
        {
            try
            {
                cacheProduct.Flush();
                return objProduct.Delete(product_id);
               
            }
            catch (Exception)
            {
                throw;
            }
         
        }
      

        #endregion
    } // class
} // namespace