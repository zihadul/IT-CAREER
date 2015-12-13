using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Admin_SliderAdmin : System.Web.UI.Page
{
    bllSlider objSlider = new bllSlider();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindData();
        }

    }
    private void BindData()
    {
        DataView dv = objSlider.GetList().DefaultView;

        DataTable dt = dv.ToTable();
        gv.DataSource = dt;
        gv.DataBind();
    }
    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());

        DataTable dt = objSlider.GetByID(id);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["ImageName"].ToString() != "")
            {
                Common.DeleteFile(Server.MapPath("~/Resources/UserFile/Slider/" + dt.Rows[0]["ImageName"].ToString()));
                Common.DeleteFile(Server.MapPath("~/Resources/UserFile/Slider/thumbs/" + dt.Rows[0]["ImageName"].ToString()));
            }
            MessageController.Show(MessageCode._DeleteSucceeded, MessageType.Information, Page);
            objSlider.Delete(id);
            BindData();
        }
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }

}