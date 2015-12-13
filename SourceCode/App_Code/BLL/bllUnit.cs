using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for bllUnit
/// </summary>
/// 
namespace BLL
{
    public class bllUnit
    {
        public bllUnit()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        dalUnit objUnit = new dalUnit();
        public int Insert(string UnitName, int DivisionID)
        {
            return objUnit.Insert(UnitName, DivisionID);
        }


        public int Update(int UnitID, string UnitName, int DivisionID)
        {
            return objUnit.Update(UnitID, UnitName, DivisionID);
        }

        public int Delete(int UnitID)
        {
            return objUnit.Delete(UnitID);
        }
        public DataTable GetByDivisionID(int DivisionID)
        {
            return objUnit.GetByDivisionID(DivisionID);
        }

        public DataTable GetAll()
        {
            return objUnit.GetAll();

        }

        public DataTable GetByID(int UnitID)
        {
            return objUnit.GetByID(UnitID);
        }
    }
}