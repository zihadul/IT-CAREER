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

public partial class Master_Default : System.Web.UI.MasterPage
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
                else
                {
                    Page.Title = Page.Title.ToString();
                }

                //Page.Title = SiteMap.CurrentNode.Title;

                if (SiteMap.CurrentNode["PageHeader"] != null)
                {
                    lit_PageHeader.Text = SiteMap.CurrentNode["PageHeader"].ToString();
                }
                else
                {
                    lit_PageHeader.Text = Page.Title.ToString();
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
            else
            {
                Page.Title = Page.Title.ToString();
                lit_PageHeader.Text = Page.Title.ToString();
            }


            if (Page.User.Identity.Name == "")
            {
                if (this.Page.ToString().Replace("ASP.", "").Replace("_", ".") != "pages.services.photoretuching.aspx" &&
                    this.Page.ToString().Replace("ASP.", "").Replace("_", ".") != "pages.services.photoretouchingpricelist.aspx" &&
                    this.Page.ToString().Replace("ASP.", "").Replace("_", ".") != "pages.services.samplework.aspx")
                {
                    Menu11.Visible = false;
                    menuhdn.Visible = false;
                }
            }


        }
    }
}
