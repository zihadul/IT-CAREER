using System;
using System.Data;
using System.Web.UI.WebControls;
using BLL;

public partial class UserControls_CarrerEmploymentHistory : System.Web.UI.UserControl
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

    public  void InitializeControl()
    {

        DataTable dtEmploymentHistory = objCandidate.GetEmploymentHistory(CandidateID);

        if (dtEmploymentHistory.Rows.Count == 0)
            dtEmploymentHistory.Rows.Add(dtEmploymentHistory.NewRow());


        gvEmploymentHistory.DataSource = dtEmploymentHistory;
        gvEmploymentHistory.DataBind();
        
    }


    #region Employment History
    protected void btnEmploymentHistory_Command(object sender, CommandEventArgs e)
    {
        DataTable dtEmploymentHistory = GetEmploymentHistory();
        dtEmploymentHistory.Rows.RemoveAt(int.Parse(e.CommandArgument.ToString()));

        gvEmploymentHistory.DataSource = dtEmploymentHistory;
        gvEmploymentHistory.DataBind();

    }

    private DataTable GetEmploymentHistory()
    {
        DataTable dtEmploymentHistory = objCandidate.GetEmploymentHistory(0);

        foreach (GridViewRow gvr in gvEmploymentHistory.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {

                TextBox tbxCompanyName = gvr.FindControl("tbxCompanyName") as TextBox;
                TextBox tbxCompanyBusiness = gvr.FindControl("tbxCompanyBusiness") as TextBox;
                TextBox tbxCompanyLocation = gvr.FindControl("tbxCompanyLocation") as TextBox;
                TextBox tbxPositionHeld = gvr.FindControl("tbxPositionHeld") as TextBox;
                TextBox tbxDepartment = gvr.FindControl("tbxDepartment") as TextBox;
                TextBox tbxResponsibilities = gvr.FindControl("tbxResponsibilities") as TextBox;
                TextBox tbxAreaofExperiences = gvr.FindControl("tbxAreaofExperiences") as TextBox;
                TextBox tbxFrom = gvr.FindControl("tbxFrom") as TextBox;
                TextBox tbxTo = gvr.FindControl("tbxTo") as TextBox;
                CheckBox chkIsContinue = gvr.FindControl("chkIsContinue") as CheckBox;


                DataRow dr = dtEmploymentHistory.NewRow();
                dr["CompanyName"] = tbxCompanyName.Text;
                dr["CompanyBusiness"] = tbxCompanyBusiness.Text;
                dr["CompanyLocation"] = tbxCompanyLocation.Text;
                dr["PositionHeld"] = tbxPositionHeld.Text;
                dr["Department"] = tbxDepartment.Text;
                dr["Responsibities"] = tbxResponsibilities.Text;
                dr["AreaOfExperience"] = tbxAreaofExperiences.Text;

                if (Common.IsDate(tbxFrom.Text))
                    dr["FromDate"] = tbxFrom.Text;

                if (Common.IsDate(tbxTo.Text))
                    dr["ToDate"] = tbxTo.Text;

                dr["IsContinue"] = chkIsContinue.Checked;

                dtEmploymentHistory.Rows.Add(dr);

            }
        }

        return dtEmploymentHistory;
    }


    protected void btnAddEmploymentHistory_Click(object sender, EventArgs e)
    {
        DataTable dtEmploymentHistory = GetEmploymentHistory();
        dtEmploymentHistory.Rows.Add(dtEmploymentHistory.NewRow());

        gvEmploymentHistory.DataSource = dtEmploymentHistory;
        gvEmploymentHistory.DataBind();
    }
    #endregion


    public bool SaveEmploymentHistory()
    {
        bool succeed = false;


        try
        {

            DataTable dtEmploymentHistory = GetEmploymentHistory();
            objCandidate.InsertEmploymentHistory(CandidateID, dtEmploymentHistory);

            succeed = true;
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);

        }

        return succeed;
    }

}