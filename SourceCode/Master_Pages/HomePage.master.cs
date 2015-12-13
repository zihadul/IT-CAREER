using System;
using System.Web;
using System.Web.UI.HtmlControls;


public partial class Master_HomePage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
   
        if (!IsPostBack)
        {

            if (SiteMap.CurrentNode != null)
            {
                if (SiteMap.CurrentNode["pagetitle"] != null)
                {
                    Page.Title = SiteMap.CurrentNode["pagetitle"].ToString();
                }

                if (SiteMap.CurrentNode["keywords"] != null)
                {
                    HtmlMeta meta = new HtmlMeta();
                    meta.Name = "Keywords";
                    meta.Content = SiteMap.CurrentNode["Keywords"];
                    Page.Header.Controls.AddAt(1, meta);
                }

                if (SiteMap.CurrentNode.Description != null)
                {
                    HtmlMeta meta = new HtmlMeta();
                    meta.Name = "Description";
                    meta.Content = SiteMap.CurrentNode.Description.ToString();
                    Page.Header.Controls.AddAt(2, meta);
                }
            }


            if (Page.User.Identity.Name == "")
            {
                //Menu11.Visible = false;
                //menuhdn.Visible = false;
            }


        }
    }
}
