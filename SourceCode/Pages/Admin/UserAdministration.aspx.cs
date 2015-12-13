using BLL;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;


public partial class UserAdministration : System.Web.UI.Page
{
    
    MembershipUserCollection membershipUserCollection;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            ddlSearchBy.Items.Add("User Name");
            ddlSearchBy.Items.Add("Email Address");
            BindData();
        }
    }

    protected void BindData()
    {
        //membershipUserCollection = Membership.GetAllUsers();

        //gv.DataSource = membershipUserCollection;
        //gv.DataBind();
        //lblNumberOfTotalUsers.Text = gv.Rows.Count.ToString();

        string Criteria = "";
        DataView dv = new bllMember().GetAllUser().DefaultView;

        Criteria = "RoleName= 'Admin' or RoleName= 'JobSeeker'";
        dv.RowFilter = Criteria;
        DataTable dt = dv.ToTable();

        gv.DataSource = dt;
        gv.DataBind();
        lblNumberOfTotalUsers.Text = gv.Rows.Count.ToString();

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
                lblNumberOfTotalUsers.Text = membershipUserCollection.Count.ToString();
                
                hlShowAll.Visible = true;
            }
      }
}