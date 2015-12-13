using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class Pages_Admin_Formation : System.Web.UI.Page
{
    bllFormation objFormation = new bllFormation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        DataTable dt = objFormation.GetAll();
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {

            int id = Convert.ToInt32(e.CommandArgument.ToString());
            objFormation.Delete(id);
            MessageController.Show(MessageCode._DeleteSucceeded,MessageType.Information, Page);
            BindData();
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);
        }

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
}