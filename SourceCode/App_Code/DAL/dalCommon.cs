using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{
    public class dalCommon
    {
        public DataTable GetCountry()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_country_get", altParams);
        }


        public int ClearErrorLog(DateTime pTimeUtc)
        {
            ArrayList altParams = new ArrayList();
            
            altParams.Add(new SqlParameter("@TimeUtc", pTimeUtc));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("ELMAH_LogError_Clear", altParams);
        }


        public int EnquiryInsert(string FirstName, string LastName, string Email, 
            bool DemoRequest, string ProductName)
        {
            ArrayList altParams = new ArrayList();
            
            altParams.Add(new SqlParameter("@FirstName", FirstName));
            altParams.Add(new SqlParameter("@LastName", LastName));
            altParams.Add(new SqlParameter("@Email", Email));
            altParams.Add(new SqlParameter("@DemoRequest", DemoRequest));
            altParams.Add(new SqlParameter("@ProductName", ProductName));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_Enquiry_Insert", altParams);

        }

    } //class
} //namespace