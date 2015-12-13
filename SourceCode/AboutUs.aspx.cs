using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class AboutUs : BasePage 
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["activeTab"] = "About Us";
        string fileName = Path.GetFileName(Request.PhysicalPath);
        LitContent.Text = ContentResources.GetResourceByCultureKey(fileName, "Page Content");
    }
}
