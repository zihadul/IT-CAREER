using System;


public partial class SiteMap : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

             if (User.IsInRole("Admin"))
             {
                 Session["activeTab"] = "Home";
                SetMenu("Admin");
             }
             else if (User.IsInRole("JobSeeker"))
             {
                 Session["activeTab"] = "Home";
                 SetMenu("JobSeeker");
             }
             else
             {
                 SetMenu("Annonymous");
             }
            

        }
    }

    private void SetMenu(string strRole)
    {


        TreeView1.DataSource = NavigationController.GetSiteMapDataSource(strRole);
        TreeView1.DataBind();

        //TreeView1.Nodes.AddAt (0, new TreeNode("Home", "", "", "~/Default.aspx","")); 

    }

}