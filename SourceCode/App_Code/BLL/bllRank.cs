using BLL;
using DAL;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BLL
{
    /// <summary>
    /// Summary description for bllRank
    /// </summary>
    public class bllRank
    {
        public bllRank()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        dalRank objRank = new dalRank();
        public int Insert(string RankName)
        {
            return objRank.Insert(RankName);
        }


        public int Update(int RankID, string RankName)
        {
            return objRank.Update(RankID, RankName);
        }

        public int Delete(int RankID)
        {
            return objRank.Delete(RankID);
        }
        public DataTable GetAll()
        {
            return objRank.GetAll();
             
        }

        public DataTable GetByID(int RankID)
        {
            return objRank.GetByID(RankID);
        }
    }
}