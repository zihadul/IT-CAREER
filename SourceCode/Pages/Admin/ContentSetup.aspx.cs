using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Admin_ContentSetup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPagesList();
        }
    }

    protected void BindPagesList()
    {
        DataSet ds = ContentResources.GetPages("");
        ddlPage.DataSource = ds;
        ddlPage.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool ret = ContentResources.UpdateResource(ddlPage.SelectedItem.Text, "Page Content", txtContent.Content);
        if (ret)
        {
            lblMessage.Text = "Data saved.";
            this.Cache.Remove(ddlPage.SelectedValue.ToLower());
        }
        else
            lblMessage.Text = "Error occured when saving data.";
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlPage.SelectedIndex != -1))
        {
            string values = ContentResources.GetResourceByCultureKey(ddlPage.SelectedItem.Value, "Page Content");
            if (values != null)
            {
                txtContent.Content = values;
            }
        }
    }
}