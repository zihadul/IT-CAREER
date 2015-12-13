using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class UserControls_ClearErrorLog : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            tbxDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        }

    }

    public void OnBtnSave_Click(object sender, EventArgs e)
    {
        new bllCommon().ClearErrorLog(Convert.ToDateTime(tbxDate.Text));
        MessageController.Show("Error Log Cleared.", MessageType.Information, Page);
    }
}