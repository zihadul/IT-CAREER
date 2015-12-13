using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Threading;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["printmode"] != null)
        {
            if (Request.QueryString["printmode"] == "y")
            {
                Page.Theme = "Print";
                Page.MasterPageFile = "~/MasterPages/Print.master";

            }
        }
    }

    protected override void InitializeCulture()
    {
        base.InitializeCulture();
        CultureInfo info = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        info.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        Thread.CurrentThread.CurrentCulture = info;
    }
}
