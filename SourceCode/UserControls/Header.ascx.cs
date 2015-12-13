using System;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class UserControls_Header : System.Web.UI.UserControl
{
    public bool SiteMapBarVisibility
    {
        get
        {
            return siteMapBar.Visible;
        }

        set
        {

            siteMapBar.Visible = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Page.User.Identity.Name != "")
                {
                    lblUser.Text = Page.User.Identity.Name;
                    string[] strUserRole = Roles.GetRolesForUser(Page.User.Identity.Name);
                    if (strUserRole[0].ToString() == "Admin" || strUserRole[0].ToString() == "JobSeeker")
                        SetMenu("Register");
                }
                else
                {
                    lblUser.Text = "Guest";
                    SetMenu("Annonymous");

                }

            }
        }
        catch (Exception)
        {

        }
    }

    private void SetMenu(string strRole)
    {
        Menu1.DataSource = NavigationController.GetSiteMapDataSource(strRole);
        Menu1.DataBind();
    }


    protected void SiteMapPath1_ItemCreated(object sender, SiteMapNodeItemEventArgs e)
    {
        if (e.Item.ItemIndex == 0 || (e.Item.ItemIndex == 1 && e.Item.ItemType == SiteMapNodeItemType.PathSeparator))
        {
            e.Item.Visible = false;

        }
    }

    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        Session["RedirectFrom"] = null;
        Session["MemberID"] = null;

        Response.Redirect("~/Default.aspx", true);
    }

}
