using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Web.Security;

public partial class Pages_Admin_ArmyPrefixList : System.Web.UI.Page
{
    bllArmyPrefix objArmyPrefix = new bllArmyPrefix();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["printmode"] != null)
        {
            if (Request.QueryString["printmode"] == "y")
            {
                Page.Theme = "Print";
                Page.MasterPageFile = "~/MasterPages/Print.master";

            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }

    }
    protected void BindData()
    {
        DataTable dt = objArmyPrefix.GetAll();
        gv.DataSource = dt;
        gv.DataBind();
    }
    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {

            int ID = Convert.ToInt32(e.CommandArgument.ToString());
            objArmyPrefix.Delete(ID);
            MessageController.Show(MessageCode._DeleteSucceeded, MessageType.Information, Page);
            BindData();
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);
        }

    }
}