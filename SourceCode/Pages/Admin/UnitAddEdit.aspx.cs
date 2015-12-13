using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Pages_Admin_UnitAddEdit : System.Web.UI.Page
{

    bllUnit objUnit = new bllUnit();
    bllFormation objFormation = new bllFormation();
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
            {
                LoadDefault();
            }
            else
            {
                LoadDivision();

            }
        }
    }


    private void LoadDivision()
    {
        ddlFormation.Items.Clear();
        ddlFormation.DataSource = objFormation.GetAll();
        ddlFormation.DataBind();
    }

    protected void LoadDefault()
    {
        DataTable dt = objUnit.GetByID(ID);
        if (dt.Rows.Count > 0)
        {
            tbxUnit.Text = dt.Rows[0]["UnitName"].ToString();
            ddlFormation.SelectedValue = dt.Rows[0]["FormationID"].ToString();
            LoadDivision();

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ID == 0)
        {
            try
            {
                objUnit.Insert(tbxUnit.Text.Trim(), Convert.ToInt32(ddlFormation.SelectedValue));
                Clear();
                MessageController.Show(MessageCode._SaveSucceeded,MessageType.Information, Page);
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
                objUnit.Update(ID, tbxUnit.Text.Trim(), Convert.ToInt32(ddlFormation.SelectedValue));
                ID = 0;
                Clear();
                MessageController.Show(MessageCode._UpdateSucceeded, MessageType.Information, Page);
            }
            catch (Exception)
            {
                MessageController.Show(MessageCode._UpdateFailed, MessageType.Error, Page);
            }
        }
    }

    protected void Clear()
    {
        tbxUnit.Text = "";
        LoadDivision();
    }
}