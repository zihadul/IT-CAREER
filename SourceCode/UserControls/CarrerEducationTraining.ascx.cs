using System;
using System.Data;
using System.Web.UI.WebControls;
using BLL;

public partial class UserControls_CarrerEducationTraining : System.Web.UI.UserControl
{


    public int CandidateID
    {
        set { ViewState["CandidateID"] = value; }
        get { return ViewState["CandidateID"] == null ? 0 : int.Parse(ViewState["CandidateID"].ToString()); }
    }

   bllCandidate objCandidate = new bllCandidate();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitializeControl()
    {

        DataTable dtQualification = objCandidate.GetAcademicQualification(CandidateID);
        if (dtQualification.Rows.Count == 0)
            dtQualification.Rows.Add(dtQualification.NewRow());

        gvEducation.DataSource = dtQualification;
        gvEducation.DataBind();

    }

    #region Academic Qualification
    protected void btnRemoveAcademicQual_Command(object sender, CommandEventArgs e)
    {
        DataTable dtQualification = GetAcademicQual();
        dtQualification.Rows.RemoveAt(int.Parse(e.CommandArgument.ToString()));

        gvEducation.DataSource = dtQualification;
        gvEducation.DataBind();

    }

    private  DataTable GetAcademicQual()
    {
        DataTable dtQualification = objCandidate.GetAcademicQualification(0);

        foreach (GridViewRow gvr in gvEducation.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {

                TextBox tbxExam = gvr.FindControl("tbxExam") as TextBox;
                DropDownList ddlInstitution = gvr.FindControl("ddlInstitution") as DropDownList;
                TextBox tbxResult = gvr.FindControl("tbxResult") as TextBox;
                TextBox tbxYearPassing = gvr.FindControl("tbxYearPassing") as TextBox;
                TextBox tbxDuration = gvr.FindControl("tbxDuration") as TextBox;
                TextBox tbxAchievement = gvr.FindControl("tbxAchievement") as TextBox;


                DataRow dr = dtQualification.NewRow();
                dr["DegreeTitle"] = tbxExam.Text;
                dr["InstitutionID"] = ddlInstitution.SelectedValue;
                dr["Result"] = tbxResult.Text;
                dr["YearOfPassing"] = tbxYearPassing.Text;
                dr["Duration"] = tbxDuration.Text;
                dr["Achievement"] = tbxAchievement.Text;
                dtQualification.Rows.Add(dr);

            }
        }

        return dtQualification;
    }


    protected void btnAddAcademicQualification_Click(object sender, EventArgs e)
    {
        DataTable dtQualification = GetAcademicQual();
        dtQualification.Rows.Add(dtQualification.NewRow());

        gvEducation.DataSource = dtQualification;
        gvEducation.DataBind();
    }
    #endregion

   
    public bool SaveEducationTraining()
    {
        bool succeed = false;
        try
        {
            
            DataTable dtQualification = GetAcademicQual();
            objCandidate.InsertEducationTraining(CandidateID, dtQualification);
            succeed = true;
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);

        }

        return succeed;
    }

    protected void gvEducation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField InstitutionID = e.Row.FindControl("hfInstitutionId") as HiddenField;
            DropDownList ddlInstitution = (DropDownList)e.Row.FindControl("ddlInstitution");
            DataTable dtInstitution = new bllInstitution().GetAll();
            if (InstitutionID.Value.Length > 0)
            {
                ddlInstitution.SelectedValue = InstitutionID.Value;
                if (dtInstitution.Rows.Count > 0)
                {
                    ddlInstitution.DataSource = dtInstitution;
                    ddlInstitution.DataBind();

                }
            }
            else
            {
                ddlInstitution.DataSource = dtInstitution;
                ddlInstitution.DataBind();
            }

        }
    }


}