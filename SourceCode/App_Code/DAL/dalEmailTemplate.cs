using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{
    public class dalEmailTemplate
    {
        
        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_EmailTemplate_Get", altParams);
            return dt;
        }
        public DataTable GetList(int ID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@ID", ID));
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_EmailTemplate_GetByID", altParams);
            return dt;
        }

        public DataTable GetByModule(string Module)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@Module", Module));
            DataTable dt = DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_EmailTemplate_GetByModule", altParams);
            return dt;
        }
       
        public int Update(int ID, string TemplateTitle, string Template)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@ID", ID));
            altParams.Add(new SqlParameter("@TemplateTitle", TemplateTitle));
            altParams.Add(new SqlParameter("@Template", Template));
            return  DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_EmailTemplate_Update", altParams);
        }


        
    
    }
}
