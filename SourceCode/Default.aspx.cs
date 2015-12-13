using System;
using System.IO;


public partial class _Default : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["activeTab"] = "Home";
        string fileName = Path.GetFileName(Request.PhysicalPath);
        LitContent.Text = ContentResources.GetResourceByCultureKey(fileName, "Page Content");
    }
}
