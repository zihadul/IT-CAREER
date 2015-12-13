using System;
using System.Configuration;
using System.Data;
using BLL;

public partial class Pages_Career_JobView : System.Web.UI.Page
{

    int JobID
    {
        set { ViewState["JobID"] = value; }
        get { return ViewState["JobID"] == null ? 0 : int.Parse(ViewState["JobID"].ToString()); }
    }

   

    bllCareerJob objCareerJob = new bllCareerJob();
    bllCareerCandidateJob objCandidateJob = new bllCareerCandidateJob();
    bllCandidate objCandidate = new bllCandidate();

   

    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                JobID = int.Parse(Request.QueryString["ID"]);
                LoadCareer();
            }
        }

    }

    private void LoadCareer()
    {
        DataTable dt = objCareerJob.GetByID(JobID);

        if (dt.Rows.Count == 0) return;


        tbxTitle.Text = dt.Rows[0]["JobTitle"].ToString();
        tbxNoOfVacancies.Text = dt.Rows[0]["NoOfVacancies"].ToString();

        tbxEducationQualification.Text = dt.Rows[0]["EducationalQualification"].ToString().Replace(Convert.ToChar(10).ToString(), "<li>");
        tbxResponsibility.Text = dt.Rows[0]["Responsibility"].ToString().Replace(Convert.ToChar(10).ToString(), "<li>");
        tbxAdditionalRequirements.Text = dt.Rows[0]["AdditionalRequirements"].ToString().Replace(Convert.ToChar(10).ToString(), "<li>");
        tbxExperience.Text = dt.Rows[0]["Experience"].ToString().Replace(Convert.ToChar(10).ToString(), "<li>");

        bool SalaryNagotiable = bool.Parse(dt.Rows[0]["SalaryNagotiable"].ToString());
        bool SalaryMention = bool.Parse(dt.Rows[0]["SalaryMention"].ToString());
        bool SalaryDisplayRange = bool.Parse(dt.Rows[0]["SalaryDisplayRange"].ToString());

        //if (SalaryNagotiable)
        //    lblSalaryRange.Text = "Nagotiable";

        //if (SalaryMention)
        //    lblSalaryRange.Text = "";

        //if (SalaryDisplayRange)
        //{

        //    lblSalaryRange.Text = dt.Rows[0]["SalaryMinimum"].ToString() == "0"
        //                              ? ""
        //                              : dt.Rows[0]["SalaryMinimum"].ToString();

             
        //    if (dt.Rows[0]["SalaryMaximum"].ToString() != "0")
        //    {
        //        lblSalaryRange.Text = lblSalaryRange.Text == ""
        //                                  ? dt.Rows[0]["SalaryMaximum"].ToString()
        //                                  : (lblSalaryRange.Text + " - " + dt.Rows[0]["SalaryMaximum"].ToString());
        //    }

        //    lblSalaryRange.Text += " monthly in BDT";
        //}


        tbxApplicationDeadline.Text = dt.Rows[0]["ApplicationDeadline"].ToString() == ""
                                          ? ""
                                          : DateTime.Parse(dt.Rows[0]["ApplicationDeadline"].ToString()).ToString("dd-MMM-yyyy");

        tbxOtherBenifits.Text = dt.Rows[0]["OtherBenifits"].ToString().Replace(Convert.ToChar(10).ToString(), "<li>");
        tbxAgeFrom.Text = dt.Rows[0]["AgeFrom"].ToString() + "yrs - " + dt.Rows[0]["AgeTo"].ToString() + "yrs";

        lblJobType.Text = dt.Rows[0]["JobType"].ToString();

        lblGender.Text = dt.Rows[0]["Gender"].ToString();


        string[] JobLevel = dt.Rows[0]["JobLevel"].ToString().Split(',');
        blJobLevel.DataSource = JobLevel;
        blJobLevel.DataBind();



        if (User.IsInRole("JobSeeker"))
        {


            DataTable dtCandidate = objCandidate.GetByUserName(User.Identity.Name);
            if (dtCandidate.Rows.Count > 0)
            {
                int CandidateID = int.Parse(dtCandidate.Rows[0]["CandidateID"].ToString());

                DataTable dtCandidateJob = objCandidateJob.GetCareerCandidateJob(JobID, CandidateID);

                if (dtCandidateJob.Rows.Count > 0)
                {
                    btnApply.Visible = false;
                    MessageController.Show("You have applied for this job on " +
                                     Convert.ToDateTime(dtCandidateJob.Rows[0]["ApplyDate"]).ToString(
                                         "dd-MMM-yyyy hh:mm tt") + ".", MessageType.Information, Page);

                }

            }
            else
            {
                return;
            }


        }
        else
        {
            btnApply.Visible = false;
        }
    }

    protected void btnApply_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        if(!User.IsInRole("JobSeeker"))
        {
            Response.Redirect("~/Login.aspx?ReturnURL=" + "~/Pages/Career/JobView.aspx?ID=" + JobID.ToString());

        }
        else
        {


            DataTable dtCandidate = objCandidate.GetByUserName(User.Identity.Name);

            if (dtCandidate.Rows.Count == 0)
                return;

            int CandidateID = int.Parse(dtCandidate.Rows[0]["CandidateID"].ToString());
            objCandidateJob.InsertCandidateJob(JobID, CandidateID);


            DataTable dtTemplate = new bllEmailTemplate().GetList(6);


            string strBody = "";

            if (dtTemplate.Rows.Count > 0)
                strBody = dtTemplate.Rows[0]["Template"].ToString();

            strBody = strBody.Replace("$JobTitle$", tbxTitle.Text);
            strBody = strBody.Replace("$ApplicantName$", dtCandidate.Rows[0]["CandidateName"].ToString());
            strBody = strBody.Replace("$Mobile$", dtCandidate.Rows[0]["Mobile"].ToString());
            strBody = strBody.Replace("$Email$", dtCandidate.Rows[0]["Email"].ToString());
            strBody = strBody.Replace("$Address$", dtCandidate.Rows[0]["PresentAddress"].ToString());
            strBody = strBody.Replace("$CareerSummery$", dtCandidate.Rows[0]["CareerSummary"].ToString());
            strBody = strBody.Replace("$SpecialQualification$", dtCandidate.Rows[0]["SpecialQualification"].ToString());


            string strSubject = "Application for " + tbxTitle.Text;

            try
            {
                vilt.mailmanager.SendEmail objSendEmail = new vilt.mailmanager.SendEmail();
                objSendEmail.SendMail(ConfigurationManager.AppSettings.Get("MailReceiver"), strSubject, strBody, dtCandidate.Rows[0]["Email"].ToString());
            }
            catch (Exception)
            {
            }

            btnApply.Visible = false;
            MessageController.Show("Your application has been submitted to the authority, you will be contacted very soon. Thank you.", MessageType.Information, Page);

        }
    }
}
