using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data;
using BLL;


public partial class UserAdministration : System.Web.UI.Page
{
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

    MembershipUserCollection membershipUserCollection;
    bllMember objMember = new bllMember();
    string roleName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(User.IsInRole("Admin")) && !(User.IsInRole("JobSeeker")))
            Response.Redirect("~/Login.aspx", true);
        else
        {
            if (User.IsInRole("Admin"))
            {
                roleName = "Admin";
            }
            else if (User.IsInRole("JobSeeker"))
            {
                roleName = "JobSeeker";
            }
            
        }

        if (Request.QueryString["printmode"] != null)
        {
            gv.Columns[gv.Columns.Count - 1].Visible = false;
            gv.Columns[gv.Columns.Count - 2].Visible = false;
            gv.Columns[gv.Columns.Count - 3].Visible = false;
            btnAddNew.Visible = false;
            pnlContent.Visible = false;
            BindData();
        }
        else
        {
            ddlSearchBy.Items.Add("User Name");
            ddlSearchBy.Items.Add("Email Address");
            btnAddNew.Visible = true;
            pnlContent.Visible = true;
            BindData();
        }
    }

    protected void BindData()
    {
        DataTable dt = objMember.GetAll(roleName);
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {

        Membership.DeleteUser(e.CommandArgument.ToString(), true);
         MessageController.Show(MessageCode._DeleteSucceeded, MessageType.Information, Page);
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txtSearchBy.Text.Trim()))
        {
            MembershipUserCollection membershipUserCollection = null;
            string text = txtSearchBy.Text.Trim();
            text = text.Replace("*", "%");
            text = text.Replace("?", "_");
            if (ddlSearchBy.SelectedIndex == 0 /* userID */)
            {
                membershipUserCollection = Membership.FindUsersByName(text);
            }
            else
            {
                membershipUserCollection = Membership.FindUsersByEmail(text);
            }
            gv.PageSize = 1000; //set this number high so as to display all results
            gv.PageIndex = 0;
            gv.DataSource = membershipUserCollection;
            gv.DataBind();
            hlShowAll.Visible = true;
        }
    }
}