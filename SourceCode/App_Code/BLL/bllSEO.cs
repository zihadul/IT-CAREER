using System;
using System.Data;
using DAL;
// -- added for caching ---
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace BLL
{

    /// <summary>
    /// Summary description for bllCEO
    /// </summary>
    /// 
    public class bllSEO
    {
        private static ICacheManager cacheSEO = CacheFactory.GetCacheManager("CacheSEO");

        private dalSEO objDalSEO = new dalSEO();

        public DataTable GetByTitle(String Title)
        {
            DataTable dt = (DataTable) cacheSEO.GetData("GetByTitle" + Title);
            if (dt == null)
            {
                dt = objDalSEO.GetByTitle(Title);
                cacheSEO.Add("GetByTitle" + Title, dt, CacheItemPriority.Normal, new RefreshCache(),
                             new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            return dt;
        }



        // private string DateBirth;
        public DataTable GetSEO()
        {

            DataTable dt = (DataTable) cacheSEO.GetData("GetSEO");
            if (dt == null)
            {
                dt = objDalSEO.GetSEO();
                cacheSEO.Add("GetSEO", dt, CacheItemPriority.Normal, new RefreshCache(),
                             new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            return dt;

        }

        public void Delete(int seo_id)
        {
            objDalSEO.Delete(seo_id);
            cacheSEO.Flush();
        }

        public int Insert(string title, string content)
        {
            cacheSEO.Flush();
            return objDalSEO.Insert(title, content);
        }

        public int Update(int seo_id, string title, string content)
        {
            cacheSEO.Flush();
            return objDalSEO.Update(seo_id, title, content);

        }

        public DataTable GetByID(int seo_id)
        {
            return objDalSEO.GetByID(seo_id);
        }

    }
}
