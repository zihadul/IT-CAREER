using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for bllArmyPrefix
/// </summary>
/// 
namespace BLL
{
    public class bllArmyPrefix
    {
        dalArmyPrefix objArmyPrefix = new dalArmyPrefix();
        public bllArmyPrefix()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string PrefixName)
        {
            return objArmyPrefix.Insert(PrefixName);
        }

        public int Update(int ArmyPrefixID, string PrefixName)
        {
            return objArmyPrefix.Update(ArmyPrefixID, PrefixName);
        }

        public int Delete(int ArmyPrefixID)
        {
            return objArmyPrefix.Delete(ArmyPrefixID);
        }
        public DataTable GetAll()
        {

            return objArmyPrefix.GetAll();
        }

        public DataTable GetByID(int ArmyPrefixID)
        {
            return objArmyPrefix.GetByID(ArmyPrefixID);
        }
    }
}