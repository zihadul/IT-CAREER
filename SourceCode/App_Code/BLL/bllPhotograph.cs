using System.Data;
using DAL;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System;

namespace BLL
{
    public class bllPhotograph
    {
        readonly dalPhotograph _objPhotograph = new dalPhotograph();
        private static ICacheManager cache = CacheFactory.GetCacheManager("CachePhotograph");

        public DataTable GetList()
        {
            DataTable dt = (DataTable)cache.GetData("cachePhotograph");
            if (dt == null)
            {
                dt = _objPhotograph.GetList();
                cache.Add("cachePhotograph", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }

            return dt;
        }

        public DataTable GetByProductID(int productid)
        {
            DataTable dt = null; // = (DataTable)cache.GetData("GetByProductID" + productid.ToString());
            if (dt == null)
            {
                dt = _objPhotograph.GetByProductID(productid);
                cache.Add("GetByProductID" + productid.ToString(), dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }

            return dt;
        }

      

        public DataTable GetById(int photographid)
        {
            return _objPhotograph.GetById(photographid);
        }

        public int Insert(string Name, string filename, string description,int productid)
        {
            cache.Flush();
            return _objPhotograph.Insert(Name, filename, description, productid);
        }

        public int Update(int photographid, string Name, string filename, string description, int productid)
        {
            cache.Flush();
            return _objPhotograph.Update(photographid, Name, filename, description,productid);
        }
        public int Delete(int photographid)
        {
            cache.Flush();
            return _objPhotograph.Delete(photographid);
        }

    }
   }