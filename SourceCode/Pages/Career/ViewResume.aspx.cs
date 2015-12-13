using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using BLL;
using System.Web.UI.WebControls;

public partial class Pages_Career_ViewResume : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["printmode"] != null)
        {
            if (Request.QueryString["printmode"] == "y")
            {
                Page.Theme = "Print";
                Page.MasterPageFile = "~/Master_Pages/Print.master";

            }
        }
    }

    bllCandidate objCandidate = new bllCandidate();
    bllCareerCandidateJob objCandidateJob = new bllCareerCandidateJob(); 

    int CandidateID
    {
        set { ViewState["CandidateID"] = value; }
        get { return ViewState["CandidateID"] == null ? 0 : int.Parse(ViewState["CandidateID"].ToString()); }

    }

    int JobID
    {
        set { ViewState["JobID"] = value; }
        get { return ViewState["JobID"] == null ? 0 : int.Parse(ViewState["JobID"].ToString()); }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["printmode"] != null)
            {
                pnlAction.Visible = false;
                pnlActionCommand.Visible = false;
                pnl1.Visible = false;
                pnlEmail.Visible = false;
                btnSetAction.Visible = false;
                btnSendEmail.Visible = false;
                gvPortfolio.Columns[gvPortfolio.Columns.Count - 1].Visible = false;
                LoadCareer();

                
            }
            else
            {
                LoadCareer();
            }
        }
    }
    private void LoadCareer()
    {

        DataTable dtCandidate;


        if (User.IsInRole("Admin") && Request.QueryString["CandidateID"] != null)
        {

            if (Request.QueryString["JobID"] != null)
                JobID = int.Parse(Request.QueryString["JobID"]);

            if (JobID > 0)
                pnlAction.Visible = true;

            CandidateID = int.Parse(Request.QueryString["CandidateID"]);
            dtCandidate = objCandidate.GetByID(CandidateID);

            string JobTitle = "";

            DataTable dtAction = objCandidateJob.GetJobCandidateShortLis(JobID, CandidateID);

            if (dtAction.Rows.Count > 0)
            {
                rdoShortList.Checked = bool.Parse(dtAction.Rows[0]["ShortListed"].ToString());
                rdoReject.Checked = bool.Parse(dtAction.Rows[0]["Rejected"].ToString());
                tbxComment.Text = dtAction.Rows[0]["Comments"].ToString();
                JobTitle = dtAction.Rows[0]["JobTitle"].ToString();
            }


            DataTable dtTemplate = new bllEmailTemplate().GetList(7);
            if (dtTemplate.Rows.Count > 0)
            {
                string strBody = "";
                strBody = dtTemplate.Rows[0]["Template"].ToString();
                strBody = strBody.Replace("$ApplicantName$", dtCandidate.Rows[0]["CandidateName"].ToString());
                tbxMessage.Content = strBody;
                tbxSubject.Text = "Re " + JobTitle;
            }


        }
        else
            dtCandidate = objCandidate.GetByUserName(User.Identity.Name);
            

        if (dtCandidate.Rows.Count == 0)
        {
            Response.Redirect("ResumePost.aspx");
        }
        else
        {
            CandidateID = int.Parse(dtCandidate.Rows[0]["CandidateID"].ToString());

            if (File.Exists( Server.MapPath( "~/Images/Career/Photo/" + CandidateID.ToString() + ".jpg")))
            {
                imgPhoto.Visible = true;
                imgPhoto.ImageUrl = "~/Images/Career/Photo/" + CandidateID.ToString() + ".jpg";
            }

            tbxName.Text = dtCandidate.Rows[0]["CandidateName"].ToString();


            lblFatherName.Text=dtCandidate.Rows[0]["FatherName"].ToString();
            lblMotherName.Text = dtCandidate.Rows[0]["MotherName"].ToString();
            lblRank.Text = dtCandidate.Rows[0]["RankName"].ToString();
            lblArms.Text = dtCandidate.Rows[0]["ArmsName"].ToString();
            lblFormation.Text = dtCandidate.Rows[0]["FormationName"].ToString();
            lblUnit.Text = dtCandidate.Rows[0]["UnitName"].ToString();
            lblArmyNo.Text = dtCandidate.Rows[0]["ArmyNo"].ToString();
            if (dtCandidate.Rows[0]["BirthDate"].ToString() != "")
            {
                tbxDateofBirth.Text = Convert.ToDateTime(dtCandidate.Rows[0]["BirthDate"].ToString()).ToString("dd-MMM-yyyy");
            }
            lblGender.Text = dtCandidate.Rows[0]["Gender"].ToString();
            lblMaritalStatus.Text = dtCandidate.Rows[0]["MaritalStatus"].ToString();
            tbxReligion.Text = dtCandidate.Rows[0]["Religion"].ToString();
            tbxPresentAddress.Text = dtCandidate.Rows[0]["PresentAddress"].ToString().Replace(Convert.ToChar(10).ToString(), "<br />");
            tbxPermanentAddress.Text = dtCandidate.Rows[0]["PermanentAddress"].ToString().Replace(Convert.ToChar(10).ToString(), "<br />");
            tbxMobile.Text = dtCandidate.Rows[0]["Mobile"].ToString();
            tbxEmail.Text = dtCandidate.Rows[0]["Email"].ToString();
            tbxCareerSummery.Text = dtCandidate.Rows[0]["CareerSummary"].ToString().Replace(Convert.ToChar(10).ToString(), "<br />");
            tbxSpecialQualification.Text = dtCandidate.Rows[0]["SpecialQualification"].ToString().Replace(Convert.ToChar(10).ToString(), "<br />");
            //tbxKeywords.Text = dtCandidate.Rows[0]["SearchKeyword"].ToString();

            DataTable dtInterest = new bllInterest().InterestByCandidateID(CandidateID);
            if (dtInterest.Rows.Count > 0)
            {
                foreach (DataRow dr in dtInterest.Rows)
                {
                    lblInterest.Text = lblInterest.Text + dr["InterestName"].ToString() + ", ";
                }

            }
            else
            {
                pnlInterest.Visible = false;
            }

            gvEducation.DataSource = objCandidate.GetAcademicQualification(CandidateID);
            gvEducation.DataBind();
            pnlAcademicQualification.Visible = gvEducation.Rows.Count != 0;

            gvTraining.DataSource = objCandidate.GetTrainingSummery(CandidateID);
            gvTraining.DataBind();
            pnlTrainingSummery.Visible = gvTraining.Rows.Count != 0;


            //gvProfessionalQualification.DataSource = objCandidate.GetProfessionalQualification(CandidateID);
            //gvProfessionalQualification.DataBind();
            //pnlProfessionalQualification.Visible = gvProfessionalQualification.Rows.Count != 0;
            

            //gvEmploymentHistory.DataSource = objCandidate.GetEmploymentHistory(CandidateID);
            //gvEmploymentHistory.DataBind();
            //pnlEmploymentHistory.Visible = gvEmploymentHistory.Rows.Count != 0;
            

            //dlReference.DataSource = objCandidate.GetReference(CandidateID);
            //dlReference.DataBind();
            //pnlReference.Visible = dlReference.Items.Count != 0;

            gvPortfolio.DataSource = objCandidate.GetPortfolio(CandidateID);
            gvPortfolio.DataBind();
            pnlPortfolio.Visible = gvPortfolio.Rows.Count != 0;

            

        }

    }



    protected void btnAction_Click(object sender, EventArgs e)
    {
        objCandidateJob.InsertJobCandidateShortLis(JobID, CandidateID, rdoShortList.Checked, rdoReject.Checked,
                                                   tbxComment.Text);

        MessageController.Show(MessageCode._SaveSucceeded, MessageType.Information, Page);
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
          string Message = "You have got an Email from:<br />Email: " + tbxEmail.Text + "<br />" + "<br />" + tbxMessage.Content;
         
            vilt.mailmanager.SendEmail objSendEmail = new vilt.mailmanager.SendEmail();
            objSendEmail.SendMail(tbxEmail.Text, tbxSubject.Text, Message, ConfigurationManager.AppSettings.Get("MailSenderName"));

        }
        catch (Exception)
        {
        }
    }

    protected void btnImg_Command(object sender, CommandEventArgs e)
    {

        Image1.ImageUrl = "~/Images/Career/Portfolio/" +e.CommandArgument;
        ImgPopup.Show();
    }
    protected void btnImg1_Command(object sender, CommandEventArgs e)
    {

        Image1.ImageUrl = "~/Images/Career/Portfolio/" + e.CommandArgument;
        ImgPopup.Show();
    }
    protected void btnImg2_Command(object sender, CommandEventArgs e)
    {

        Image1.ImageUrl = "~/Images/Career/Portfolio/" + e.CommandArgument;
        ImgPopup.Show();
    }
    protected void btnImg3_Command(object sender, CommandEventArgs e)
    {
        Image1.ImageUrl = "~/Images/Career/Portfolio/" + e.CommandArgument;
        ImgPopup.Show();
    }

    
}
