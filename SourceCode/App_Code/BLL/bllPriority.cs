using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DAL;

namespace BLL
{
    public class bllPriority
    {
        dalPriority objPriority = new dalPriority();
        public bllPriority()
        {
        }
        public DataTable GetList()
        {
            return objPriority.GetList();
        }
        public DataTable GetByID(int PriorityID)
        {
            return objPriority.GetByID(PriorityID);
        }
        public int Insert(string PriorityName, string Description, string ColorCode)
        {
            return objPriority.Insert(PriorityName, Description, ColorCode);
        }
        public int Update(int PriorityID, string PriorityName, string Description, string ColorCode)
        {
            return objPriority.Update(PriorityID, PriorityName, Description, ColorCode);
        }
        public int Delete(int PriorityID)
        {
            return objPriority.Delete(PriorityID);
        }
    }
}
