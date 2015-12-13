using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for bllArms
/// </summary>
/// 
namespace BLL
{
    public class bllArms
    {
        dalArms objArms = new dalArms();
        public bllArms()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string ArmsName)
        {
            return objArms.Insert(ArmsName);
        }


        public int Update(int ArmsID, string ArmsName)
        {
            return objArms.Update(ArmsID, ArmsName);
        }

        public int Delete(int ArmsID)
        {
            return objArms.Delete(ArmsID);
        }
        public DataTable GetAll()
        {
            return objArms.GetAll();

        }

        public DataTable GetByID(int ArmsID)
        {
            return objArms.GetByID(ArmsID);
        }
    }
}