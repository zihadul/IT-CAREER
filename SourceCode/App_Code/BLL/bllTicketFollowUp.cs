using System.Data;
using DAL;

namespace BLL
{
    public class bllTicketFollowUp
    {
        dalTicketFollowUp objTicketFollowUp = new dalTicketFollowUp();
        

        public DataTable GetList()
        {
          return   objTicketFollowUp.GetList();
        }
        public DataTable GetByID(int FollowUpID)
        {
            return objTicketFollowUp.GetByID(FollowUpID);
        }
        public DataTable GetByTicketID(int TicketID)
        {
            return objTicketFollowUp.GetByTicketID(TicketID);
        }

        public int Insert(int TicketID, string Comments, int StatusID, string FollowUpBy)
        {
            return objTicketFollowUp.Insert(TicketID, Comments, StatusID, FollowUpBy);
        }

      
        public int Delete(int FollowUpID)
        {
            return objTicketFollowUp.Delete(FollowUpID);
        }
    }
}
