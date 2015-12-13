using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Pages_Admin_ArmsAddEdit : System.Web.UI.Page
{
    bllArms objArms = new bllArms();
    int ID
    {
        set { ViewState["ID"] = value; }
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["ID"].ToString());
            }
            catch
            {
                return 0;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                ID = Convert.ToInt32(Request.QueryString["ID"].ToString());
            }

            if (ID > 0)
                LoadDefault();
        }
    }

    protected void LoadDefault()
    {
        DataTable dt = objArms.GetByID(ID);
        if (dt.Rows.Count > 0)
        {
            tbxName.Text = dt.Rows[0]["ArmsName"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ID == 0)
        {
            try
            {
                objArms.Insert(tbxName.Text.Trim());
                tbxName.Text = "";
                MessageController.Show(MessageCode._SaveSucceeded, MessageType.Information, Page);
            }
            catch (Exception ex)
            {
                MessageController.Show(ex.Message, MessageType.Error, Page);
            }
        }
        else
        {
            try
            {
                objArms.Update(ID, tbxName.Text.Trim());
                tbxName.Text = "";
                ID = 0;
                MessageController.Show(MessageCode._UpdateSucceeded, MessageType.Information, Page);
            }
            catch (Exception)
            {
                MessageController.Show(MessageCode._UpdateFailed, MessageType.Error, Page);
            }
        }
    }
}