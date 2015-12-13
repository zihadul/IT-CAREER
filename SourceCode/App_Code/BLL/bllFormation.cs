using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for bllFormation
/// </summary>
/// 
namespace BLL
{
    public class bllFormation
    {
        public bllFormation()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        dalFormation objFormation = new dalFormation();
        public int Insert(string FormationName)
        {
            return objFormation.Insert(FormationName);
        }


        public int Update(int FormationID, string FormationName)
        {
            return objFormation.Update(FormationID, FormationName);
        }

        public int Delete(int FormationID)
        {
            return objFormation.Delete(FormationID);
        }
        public DataTable GetAll()
        {
            return objFormation.GetAll();

        }

        public DataTable GetByID(int FormationID)
        {
            return objFormation.GetByID(FormationID);
        }
    }
}
