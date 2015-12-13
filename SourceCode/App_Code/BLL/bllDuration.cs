
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for bllDuration
/// </summary>
/// 
namespace BLL
{
    public class bllDuration
    {
	    public bllDuration()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
        dalDuration objDuration = new dalDuration();
        public int Insert(string Duration)
        {
            return objDuration.Insert(Duration);
        }


        public int Update(int DurationID, string Duration)
        {
            return objDuration.Update(DurationID, Duration);
        }

        public int Delete(int DurationID)
        {
            return objDuration.Delete(DurationID);
        }
        public DataTable GetAll()
        {
            return objDuration.GetAll();

        }

        public DataTable GetByID(int DurationID)
        {
            return objDuration.GetByID(DurationID);
        }
    }
}