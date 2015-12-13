using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Pages_Admin_Arms : System.Web.UI.Page
{
    bllArms objArms = new bllArms();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        DataTable dt = objArms.GetAll();
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {

            int id = Convert.ToInt32(e.CommandArgument.ToString());
            objArms.Delete(id);
            MessageController.Show(MessageCode._DeleteSucceeded, MessageType.Information, Page);
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