using System;
using System.Data;

using DAL;

namespace BLL
{
   
    public class bllCommon 
    {
      
        dalCommon objCommon= new dalCommon();

        public DataTable GetCountry()
        {
            return objCommon.GetCountry();
        }

        public int ClearErrorLog(DateTime pTimeUtc)
        {
            return objCommon.ClearErrorLog(pTimeUtc);
        }

        public int EnquiryInsert(string FirstName, string LastName, string Email,
            bool DemoRequest, string ProductName)
        {
            return objCommon.EnquiryInsert(FirstName, LastName, Email, DemoRequest, ProductName);
        }


    } // class
} // namespace