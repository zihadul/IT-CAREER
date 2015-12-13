using System.Data;
using DAL;

namespace BLL
{
    public class bllStatus
    {
        dalStatus objStatus = new dalStatus();
       
        public DataTable GetList()
        {
            return objStatus.GetList();
        }

        public DataTable GetByID(int StatusID)
        {
            return objStatus.GetByID(StatusID);
        }

        public int Insert(string StatusName, bool isDefault)
        {
            return objStatus.Insert(StatusName, isDefault);
        }

        public int Update(int StatusID, string StatusName, bool isDefault)
        {
            return objStatus.Update(StatusID, StatusName, isDefault);
        }

        public int Delete(int StatusID)
        {
            return objStatus.Delete(StatusID);
        }

    }
}
