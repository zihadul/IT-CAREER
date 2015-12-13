using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;


namespace DAL
{
    public class dalSubscribe
    {
       

        #region Subcribe Request

        public int InsertRequest(int MemberID, int product_id, decimal price, bool Confirmed)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@MemberID", MemberID));
            altParams.Add(new SqlParameter("@product_id", product_id));
            altParams.Add(new SqlParameter("@price", price));
            altParams.Add(new SqlParameter("@Confirmed", Confirmed));
            
            
            try
            {
                DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_subscription_request_insert", altParams);

                return Convert.ToInt32(dt.Rows[0]["RequestID"]);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ConfirmRequest(int RequestID,  bool Confirmed)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@RequestID", RequestID));
            altParams.Add(new SqlParameter("@Confirmed", Confirmed));

            try
            {
                return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_subscription_request_confirm", altParams);


            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetRequest()
        {
            ArrayList altParams = new ArrayList();

            try
            {
                DataSet ds = new DataSet();

                DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_subscription_request_get", altParams);

                ds.Tables.Add(dt);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetRequest(int RequestID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@RequestID", RequestID));

            try
            {
                DataSet ds = new DataSet();

                DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_subscription_request_getrequestid", altParams);

                ds.Tables.Add(dt);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Subcribe Response

        public int InsertResponse(string txn_id, decimal payment_price, string email, string first_name, string last_name, 
           int request_id,   bool is_success,string reason_fault)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@txn_id", txn_id));
            altParams.Add(new SqlParameter("@payment_price", payment_price));
            altParams.Add(new SqlParameter("@email", email));
            altParams.Add(new SqlParameter("@first_name", first_name));
            altParams.Add(new SqlParameter("@last_name", last_name));
            altParams.Add(new SqlParameter("@request_id", request_id));
            altParams.Add(new SqlParameter("@is_success", is_success));
            altParams.Add(new SqlParameter("@reason_fault", reason_fault));


            try
            {
                return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_subscription_response_insert", altParams);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetResponse()
        {
            ArrayList altParams = new ArrayList();

            try
            {
                DataSet ds = new DataSet();
                DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_subscription_response_get", altParams);

                ds.Tables.Add(dt);
                return ds;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        
    }
}

