using System;
using System.Data;
using DAL;
using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace BLL
{
    public class bllUpdate
    {
        private static ICacheManager cache = CacheFactory.GetCacheManager("CacheUpdate");
        dalUpdate objUpdate = new dalUpdate();
        public bllUpdate()
        {
        }
        public DataTable GetList()
        {
            return objUpdate.GetList();
        }

        public DataTable GetByID(int ID)
        {
            return objUpdate.GetByID(ID);
        }

        public DataTable GetLatest()
        {

            DataTable dt = (DataTable)cache.GetData("cacheUpdate");
            if (dt == null)
            {
                dt = objUpdate.GetLatest();

                cache.Add("cacheUpdate", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }

            return dt;


        }


        public int Insert(string Title, DateTime Date, string Details, string AttachmentName, bool isFeatured)
        {
            cache.Flush();
            return objUpdate.Insert(Title, Date, Details, AttachmentName, isFeatured);
        }


        public int Update(int ID, string Title, DateTime Date, string Details, string AttachmentName, bool isFeatured)
        {
            cache.Flush();
            return objUpdate.Update(ID, Title, Date, Details, AttachmentName, isFeatured);
        }

        public int Delete(int ID)
        {
            cache.Flush();
            return objUpdate.Delete(ID);
        }




    }
}
