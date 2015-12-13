using System;
using System.Data;
using System.Web.UI.WebControls;
using BLL;

public partial class UserControls_CarrerOtherInformation : System.Web.UI.UserControl
{


    public int CandidateID
    {
        set { ViewState["CandidateID"] = value; }
        get { return ViewState["CandidateID"] == null ? 0 : int.Parse(ViewState["CandidateID"].ToString()); }
    }


    bllCandidate objCandidate = new bllCandidate();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
        }

    }

    public void InitializeControl()
    {
        DataTable dtReference = objCandidate.GetReference(CandidateID);

        if (dtReference.Rows.Count == 0)
        {
            dtReference.Rows.Add(dtReference.NewRow());
            dtReference.Rows.Add(dtReference.NewRow());
        }


        dl.DataSource = dtReference;
        dl.DataBind();

    }

   

    private DataTable GetReference()
    {
        DataTable dtReference = objCandidate.GetReference(0);
        foreach (DataListItem dataListItem in dl.Items)
        {
            TextBox tbxRefenceName = dataListItem.FindControl("tbxRefenceName") as TextBox;
            TextBox tbxOrganization = dataListItem.FindControl("tbxOrganization") as TextBox;
            TextBox tbxDesignation = dataListItem.FindControl("tbxDesignation") as TextBox;
            TextBox tbxAddress = dataListItem.FindControl("tbxAddress") as TextBox;
            TextBox tbxPhone = dataListItem.FindControl("tbxPhone") as TextBox;
            TextBox tbxMobile = dataListItem.FindControl("tbxMobile") as TextBox;
            TextBox tbxEmail = dataListItem.FindControl("tbxEmail") as TextBox;
            TextBox tbxRelation = dataListItem.FindControl("tbxRelation") as TextBox;


            DataRow dr = dtReference.NewRow();
            dr["RefName"] = tbxRefenceName.Text;
            dr["Organization"] = tbxOrganization.Text;
            dr["Designation"] = tbxDesignation.Text;
            dr["Address"] = tbxAddress.Text;
            dr["PhoneNo"] = tbxPhone.Text;
            dr["MobileNo"] = tbxMobile.Text;
            dr["Email"] = tbxEmail.Text;
            dr["Relation"] = tbxRelation.Text;
            dtReference.Rows.Add(dr);
        }

        return dtReference;
    }



    public bool SaveReference()
    {
        bool succeed = false;

        try
        {
            DataTable dtReference = GetReference();
            objCandidate.InsertReference(CandidateID, dtReference);

            succeed = true;
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);

        }

        return succeed;
    }

    
}