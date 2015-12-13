using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Master_OneColoumn : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Page.ClientScript.RegisterClientScriptInclude("jquey0", Page.ResolveClientUrl("~/JavaScripts/JavaScript.js"));
        Page.ClientScript.RegisterClientScriptInclude("jquey1", Page.ResolveClientUrl("~/JavaScripts/jquery.js"));

        if (!IsPostBack)
        {

            if (SiteMap.CurrentNode != null)
            {
                if (SiteMap.CurrentNode["pagetitle"] != null)
                {
                    Page.Title = SiteMap.CurrentNode["pagetitle"].ToString();
                }
                //Page.Title = SiteMap.CurrentNode.Title;

                if (SiteMap.CurrentNode["PageHeader"] != null)
                {
                    lit_PageHeader.Text = SiteMap.CurrentNode["PageHeader"].ToString();
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


        }
    }
}
