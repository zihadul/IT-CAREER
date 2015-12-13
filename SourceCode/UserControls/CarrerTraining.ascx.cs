using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class UserControls_CarrerTraining : System.Web.UI.UserControl
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
        DataTable dtTraining = objCandidate.GetTrainingSummery(CandidateID);
        if (dtTraining.Rows.Count == 0)
            dtTraining.Rows.Add(dtTraining.NewRow());

        gvTraining.DataSource = dtTraining;
        gvTraining.DataBind();

    }

    public bool SaveTrainingSummery()
    {
        bool succeed = false;
        try
        {
            DataTable dtTraining = GetTrainingSummery();
            objCandidate.InsertTraining(CandidateID, dtTraining);
            succeed = true;
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);

        }

        return succeed;
    }

    #region Training Summery

    protected void btnTrainingSummery_Command(object sender, CommandEventArgs e)
    {
        DataTable dtTraining = GetTrainingSummery();
        dtTraining.Rows.RemoveAt(int.Parse(e.CommandArgument.ToString()));

        gvTraining.DataSource = dtTraining;
        gvTraining.DataBind();

    }

    private DataTable GetTrainingSummery()
    {
        DataTable dtTraining = objCandidate.GetTrainingSummery(0);

        foreach (GridViewRow gvr in gvTraining.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlCourse = gvr.FindControl("ddlCourse") as DropDownList;
                DropDownList ddlDuration = gvr.FindControl("ddlDuration") as DropDownList;
                DropDownList ddlInstitution = gvr.FindControl("ddlInstitution") as DropDownList;
                TextBox tbxYear = gvr.FindControl("tbxYear") as TextBox;
                TextBox tbxResult = gvr.FindControl("tbxResult") as TextBox;


                DataRow dr = dtTraining.NewRow();
                dr["CourseID"] = ddlCourse.SelectedValue;
                dr["DurationID"] = ddlDuration.SelectedValue;
                dr["InstitutionID"] = ddlInstitution.SelectedValue;
                dr["Year"] = tbxYear.Text;
                dr["Result"] = tbxResult.Text;
                dtTraining.Rows.Add(dr);
            }
        }

        return dtTraining;
    }

    protected void btnAddTrainingSummery_Click(object sender, EventArgs e)
    {
        DataTable dtTraining = GetTrainingSummery();
        dtTraining.Rows.Add(dtTraining.NewRow());

        gvTraining.DataSource = dtTraining;
        gvTraining.DataBind();
    }
    #endregion

    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlCourse = (DropDownList)e.Row.FindControl("ddlCourse");
            DropDownList ddlDuration=(DropDownList)e.Row.FindControl("ddlDuration");
            DropDownList ddlInstitution=(DropDownList)e.Row.FindControl("ddlInstitution");
            HiddenField CourseID = e.Row.FindControl("hfCourseID") as HiddenField;
            HiddenField DurationID = e.Row.FindControl("hfDuration") as HiddenField;
            HiddenField InstitutionID = e.Row.FindControl("hfInstitutionID") as HiddenField;
            DataTable dt = new bllCourse().GetAll();
            if (dt.Rows.Count > 0)
            {
                if (CourseID.Value.Length > 0)
                {
                    ddlCourse.SelectedValue = CourseID.Value;
                    ddlCourse.DataSource = dt;
                    ddlCourse.DataBind();
                }
                else
                {
                    ddlCourse.DataSource = dt;
                    ddlCourse.DataBind();
                }
               
            }
            DataTable dtDuration = new bllDuration().GetAll();
            if(dtDuration.Rows.Count > 0)
            {
                if (DurationID.Value.Length > 0)
                {
                    ddlDuration.SelectedValue = DurationID.Value;
                    ddlDuration.DataSource = dtDuration;
                    ddlDuration.DataBind();
                }
                else
                {
                    ddlDuration.DataSource = dtDuration;
                    ddlDuration.DataBind();
                }
            }
            DataTable dtInstitution = new bllInstitution().GetAll();
            if(dtInstitution.Rows.Count > 0)
            {
                if (InstitutionID.Value.Length > 0)
                {
                    ddlInstitution.SelectedValue = InstitutionID.Value;
                    ddlInstitution.DataSource = dtInstitution;
                    ddlInstitution.DataBind();
                    
                }
                else
                {
                    ddlInstitution.DataSource = dtInstitution;
                    ddlInstitution.DataBind();
                }
            }
           
        }
    }
}