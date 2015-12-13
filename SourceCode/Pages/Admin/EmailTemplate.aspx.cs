using System;
using BLL;
using System.Data;

public partial class Pages_Common_EmailTemplate : System.Web.UI.Page
{
    bllEmailTemplate objEmailTemplate = new bllEmailTemplate();
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!IsPostBack)
        {
           
            BindData();
        }
    }

     private void BindData()
    {
        DataTable dt = objEmailTemplate.GetbyModule("Career");
        gv.DataSource = dt;
        gv.DataBind();
    }
    }
    
    

