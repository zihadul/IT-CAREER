using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for bllInstitution
/// </summary>
/// 
namespace BLL
{
    public class bllInstitution
    {
        dalInstitution objInstitution = new dalInstitution();
        public bllInstitution()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string InstitutionName)
        {
            return objInstitution.Insert(InstitutionName);
        }


        public int Update(int InstitutionID, string InstitutionName)
        {
            return objInstitution.Update(InstitutionID, InstitutionName);
        }

        public int Delete(int InstitutionID)
        {
            return objInstitution.Delete(InstitutionID);
        }
        public DataTable GetAll()
        {
            return objInstitution.GetAll();

        }

        public DataTable GetByID(int InstitutionID)
        {
            return objInstitution.GetByID(InstitutionID);
        }
    }
}