using System;
using System.Web.Security;


public partial class UserControls_Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
      //  Login1.UserName = Login1.UserName.Trim();
      //  MembershipUser mu = Membership.GetUser(Login1.UserName);
        

      //string strRole = string.Empty;
      //string UserRole = "";
      //UserRole = Roles.GetRolesForUser(Login1.UserName)[0];
          if (Roles.IsUserInRole(Login1.UserName,"Admin"))
            {
              Response.Redirect("~/Default.aspx", true);
            }

            else if (Roles.IsUserInRole(Login1.UserName,"JobSeeker"))
            {
                Response.Redirect("~/Default.aspx", true);
            }
          else
              Response.Redirect("~/Default.aspx", true);
       
    }
}
