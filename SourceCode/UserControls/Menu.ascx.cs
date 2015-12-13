using System;
using System.Web.Security;


public partial class UserControls_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         
            if (Page.User.Identity.Name != "")
            {
                string[] strUserRole = Roles.GetRolesForUser(Page.User.Identity.Name);

                if (strUserRole[0].ToString() == "Admin")
                {
                    SetMenu(strUserRole[0].ToString());
                }
                else if (strUserRole[0].ToString() == "JobSeeker")
                {
                    SetMenu(strUserRole[0].ToString());
                }

                else
                    SetMenu("Annonymous");

            }
            else
            
            {
                string CurrentPage = Request.Url.AbsoluteUri.ToLower();

                if (CurrentPage.Contains("/career/"))
                {
                    SetMenu("Career");
                }
            }
            
        }
    }

    private void SetMenu(string strRole)
    {
        TreeView1.DataSource = NavigationController.GetSiteMapDataSource(strRole);
        TreeView1.DataBind();

    }
   
}
