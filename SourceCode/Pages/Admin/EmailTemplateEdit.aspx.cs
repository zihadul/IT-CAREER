using System;
using System.Data;
using BLL;

public partial class Pages_Common_EmailTemplateEdit : System.Web.UI.Page
{
    bllEmailTemplate objEmailTemplate = new bllEmailTemplate();
    public int ID
    {
        get
        {
            try
            {
                return Convert.ToInt32(hdnID.Value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set
        {
            hdnID.Value = value.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                ID = Convert.ToInt16(Request.QueryString["ID"].ToString());
                LoadTemplate();
            }
        }
    }

    private void LoadTemplate()
    {
        DataTable dt = objEmailTemplate.GetList(ID);
        if (dt.Rows.Count > 0)
        {
            tbxTemplateTitle.Text = dt.Rows[0]["TemplateTitle"].ToString();
            lblVariables.Text = dt.Rows[0]["Variables"].ToString();
            txtContent.Content = dt.Rows[0]["Template"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ID > 0)
        {
            objEmailTemplate.Update(ID, tbxTemplateTitle.Text, txtContent.Content);
            MessageController.Show(MessageCode._SaveSucceeded, MessageType.Information, Page);
        }
    }
}
