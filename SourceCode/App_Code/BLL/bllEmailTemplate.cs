using System.Data;
using DAL;

namespace BLL
{
    public class bllEmailTemplate
    {
        dalEmailTemplate objEmailTemplate = new dalEmailTemplate();
       
        public DataTable GetList()
        {
            return objEmailTemplate.GetList();
        }

        public string GetTemplate(string TemplateName)
        {
            DataView dv = GetList().DefaultView;
            dv.RowFilter = "TemplateName='" + TemplateName + "'";
            DataTable dt =  dv.ToTable();

            if (dt.Rows.Count > 0)
                return dt.Rows[0]["Template"].ToString();
            else
                return "";
        }

        public DataTable GetList(int ID)
        {
            return objEmailTemplate.GetList(ID);
        }

        public DataTable GetbyModule(string Module)
        {
            return objEmailTemplate.GetByModule(Module);
        }

        public int Update(int ID, string TemplateTitle, string Template)
        {
            return objEmailTemplate.Update(ID, TemplateTitle, Template);
        }

        
    }
}
