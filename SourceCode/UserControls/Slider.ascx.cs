using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControls_Slider : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadSlider();
        }
    }

    private void LoadSlider()
    {
        DataTable dt = new bllSlider().GetActive();
        rptSlider.DataSource = dt;
        rptSlider.DataBind();

    }
}