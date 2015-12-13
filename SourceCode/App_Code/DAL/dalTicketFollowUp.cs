using System;
using System.Data;
using System.Collections;
using TVL.DataLogicLayer;
using System.Data.SqlClient;

namespace DAL
{
    public class dalTicketFollowUp
    {
      
        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_TicketFollowUp_GetAll", altParams);
        }

        public DataTable GetByID(int FollowUpID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@FollowUpID", FollowUpID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_TicketFollowUp_GetByID", altParams);
        }

        public DataTable GetByTicketID(int TicketID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@TicketID", TicketID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_TicketFollowUp_GetByTicketID", altParams);
        }

        public int Insert(int TicketID, string Comments, int StatusID, string FollowUpBy)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@TicketID", TicketID));
            altParams.Add(new SqlParameter("@Comments", Comments));
            altParams.Add(new SqlParameter("@StatusID", StatusID));
            altParams.Add(new SqlParameter("@FollowUpBy", FollowUpBy));
          
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_TicketFollowUp_Insert", altParams);
        }


        public int Delete(int FollowUpID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@FollowUpID", FollowUpID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_TicketFollowUp_Delete", altParams);

        }
    }
}