using System;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string CurrentPage = Request.Url.AbsoluteUri.ToLower();

            if (CurrentPage.Contains("/career/"))
            {
                lnkPostResume.Visible = true;
            }
        }
    }
}
