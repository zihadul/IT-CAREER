using System;
using System.Data;
using DAL;

namespace BLL
{
    public class bllSubscribe
    {
        dalSubscribe objSubscribe = new dalSubscribe();

       
        #region Subcribe Request

        public int InsertRequest(int MemberID, int product_id, decimal price, bool Confirmed)
        {
            try
            {
                return objSubscribe.InsertRequest(MemberID, product_id, price, Confirmed);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ConfirmRequest(int RequestID, bool Confirmed)
        {
            try
            {
                return objSubscribe.ConfirmRequest(RequestID, Confirmed);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetRequest()
        {
            try
            {
                return objSubscribe.GetRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetRequest(int RequestID)
        {
            try
            {
                return objSubscribe.GetRequest(RequestID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Subcribe Response

        public int InsertResponse(string txn_id, decimal payment_price, string email, string first_name, string last_name,
           int request_id,   bool is_success, string reason_fault)
        {
           
            try
            {
                return objSubscribe.InsertResponse(txn_id, payment_price, email, first_name, last_name,
                request_id, is_success, reason_fault);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetResponse()
        {

            try
            {
                return objSubscribe.GetResponse();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        
    }
}