using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Master_Pages_PrintMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptInclude("jquey0", Page.ResolveClientUrl("~/JavaScripts/JavaScript.js"));
        Page.ClientScript.RegisterClientScriptInclude("jquey1", Page.ResolveClientUrl("~/JavaScripts/jquery.js"));

        if (SiteMap.CurrentNode != null)
        {
            Page.Title = SiteMap.CurrentNode.Title;
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
        else
        {
            if (Page.Title.ToString() != "")
            {
                Page.Title = Page.Title.ToString();
                lit_PageHeader.Text = Page.Title.ToString();
            }

        }
    }
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["printmode"] != null) return;

        string pageUrl = Request.Url.AbsoluteUri;
        if (pageUrl.IndexOf('?') != -1)
            pageUrl = pageUrl + "&printmode=y";
        else
            pageUrl = pageUrl + "?printmode=y";

        Response.Redirect(pageUrl, true);
    }
}
