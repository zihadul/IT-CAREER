using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using BLL;

public partial class Pages_Admin_RankAddEdit : System.Web.UI.Page
{
    
    bllRank objRank = new bllRank();

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
        DataTable dt = objRank.GetByID(ID);
        if (dt.Rows.Count > 0)
        {
            tbxName.Text = dt.Rows[0]["RankName"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ID == 0)
        {
            try
            {
                objRank.Insert(tbxName.Text.Trim());
                tbxName.Text = "";
                MessageController.Show(MessageCode._SaveSucceeded, MessageType.Information,Page);
            }
            catch (Exception ex)
            {
                MessageController.Show(ex.Message, MessageType.Error,Page);
            }
        }
        else
        {
            try
            {
                objRank.Update(ID, tbxName.Text.Trim());
                tbxName.Text = "";
                ID = 0;
                MessageController.Show(MessageCode._UpdateSucceeded,MessageType.Information, Page);
            }
            catch (Exception)
            {
                MessageController.Show(MessageCode._UpdateFailed, MessageType.Error,Page);
            }
        }
    }
}