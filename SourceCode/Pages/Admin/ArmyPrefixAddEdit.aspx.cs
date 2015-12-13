using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Web.Security;

public partial class Pages_Admin_ArmyPrefixAddEdit : System.Web.UI.Page
{
    bllArmyPrefix objArmyPrefix = new bllArmyPrefix();
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

    protected void LoadDefault()
    {
        DataTable dt = objArmyPrefix.GetByID(ID);
        if (dt.Rows.Count > 0)
        {
            tbxPrefix.Text = dt.Rows[0]["PrefixName"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ID == 0)
        {
            try
            {
                objArmyPrefix.Insert(tbxPrefix.Text.Trim());
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
                objArmyPrefix.Update(ID, tbxPrefix.Text.Trim());
                MessageController.Show(MessageCode._UpdateSucceeded, MessageType.Information, Page);
            }
            catch (Exception)
            {
                MessageController.Show(MessageCode._UpdateFailed, MessageType.Information, Page);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}