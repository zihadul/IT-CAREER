using System;
using System.Data;
using BLL;

public partial class Pages_CareerAdmin_JobAddEdit : System.Web.UI.Page
{

    int ID
    {
        set { ViewState["ID"] = value; }
        get { return ViewState["ID"] == null ? 0 : int.Parse(ViewState["ID"].ToString()); }
    }

    bllCareerJob objCareerJob = new bllCareerJob(); 

   

    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                ID = int.Parse(Request.QueryString["ID"]);
                LoadCareer();
            }
        }

    }

    private void LoadCareer()
    {
        DataTable dt = objCareerJob.GetByID(ID);

        if (dt.Rows.Count == 0) return;

        tbxTitle.Text = dt.Rows[0]["JobTitle"].ToString();
        tbxNoOfVacancies.Text = dt.Rows[0]["NoOfVacancies"].ToString();

        tbxEducationQualification.Text = dt.Rows[0]["EducationalQualification"].ToString();
        tbxResponsibility.Text = dt.Rows[0]["Responsibility"].ToString();
        tbxAdditionalRequirements.Text = dt.Rows[0]["AdditionalRequirements"].ToString();
        tbxExperience.Text = dt.Rows[0]["Experience"].ToString();

        rdoSalaryNegotiable.Checked = bool.Parse(dt.Rows[0]["SalaryNagotiable"].ToString());
        rdoSalaryDontMention.Checked = bool.Parse(dt.Rows[0]["SalaryMention"].ToString()); 
        rdoSalaryRange.Checked = bool.Parse(dt.Rows[0]["SalaryDisplayRange"].ToString());

        tbxApplicationDeadline.Text = dt.Rows[0]["ApplicationDeadline"].ToString() == ""
                                          ? ""
                                          : DateTime.Parse(dt.Rows[0]["ApplicationDeadline"].ToString()).ToString("dd-MMM-yyyy");

        tbxOtherBenifits.Text = dt.Rows[0]["OtherBenifits"].ToString();
        chkActive.Checked = bool.Parse(dt.Rows[0]["IsActive"].ToString()); ;
        tbxAgeFrom.Text = dt.Rows[0]["AgeFrom"].ToString();
        tbxAgeTo.Text = dt.Rows[0]["AgeTo"].ToString();
        tbxSalaryMaximum.Text = dt.Rows[0]["SalaryMaximum"].ToString() == "0" ? "" : dt.Rows[0]["SalaryMaximum"].ToString();
        tbxSalaryMinimum.Text = dt.Rows[0]["SalaryMinimum"].ToString() == "0" ? "" : dt.Rows[0]["SalaryMinimum"].ToString();


        if (rdoJobTypeFullTime.Text == dt.Rows[0]["JobType"].ToString())
            rdoJobTypeFullTime.Checked = true;
        else if (rdoJobTypePartTime.Text == dt.Rows[0]["JobType"].ToString())
            rdoJobTypePartTime.Checked = true;
        else
            rdoJobTypeContract.Checked = true;


        if (rdoGenderMale.Text == dt.Rows[0]["Gender"].ToString())
            rdoGenderMale.Checked = true;
        else if (rdoGenderFemale.Text == dt.Rows[0]["Gender"].ToString())
            rdoGenderFemale.Checked = true;
        else
            rdoGenderAny.Checked = true;


        string[] JobLevel = dt.Rows[0]["JobLevel"].ToString().Split(',');

        foreach (string s in JobLevel)
        {
            if (chkEntryLevel.Text == s)
                chkEntryLevel.Checked = true;
            else if (chkMidLevel.Text == s)
                chkMidLevel.Checked = true;
            else if (chkTopLevel.Text == s)
                chkTopLevel.Checked = true;
        }


    }

    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            
            string jobType = "";

            if (rdoJobTypeFullTime.Checked)
                jobType = rdoJobTypeFullTime.Text;
            else if (rdoJobTypePartTime.Checked)
                jobType = rdoJobTypePartTime.Text;
            else
                jobType = rdoJobTypeContract.Text;

            string jobLevel = "";

            if (chkEntryLevel.Checked)
                jobLevel = chkEntryLevel.Text;

            if (chkMidLevel.Checked)
            {
                jobLevel += jobLevel != "" ? "," : "";
                jobLevel += chkMidLevel.Text;
            }

            if (chkTopLevel.Checked)
            {
                jobLevel += jobLevel != "" ? "," : "";
                jobLevel += chkTopLevel.Text;
            }

            int SalaryMinimum = 0;
            int SalaryMaximum= 0;

            if (rdoSalaryRange.Checked)
            {
                if (tbxSalaryMinimum.Text == "" || tbxSalaryMaximum.Text == "")
                {

                    MessageController.Show("Enter Salary Range", MessageType.Error, Page);
                  
                    return;
                }

                SalaryMinimum = int.Parse(tbxSalaryMinimum.Text);
                SalaryMaximum = int.Parse(tbxSalaryMaximum.Text);

            }


            Nullable<DateTime> applicationDate = null;

            if (Common.IsDate(tbxApplicationDeadline.Text))
                applicationDate = DateTime.Parse(tbxApplicationDeadline.Text);

            int ageFrom = 0;
            int ageTo = 0;

            if (tbxAgeFrom.Text != "")
                ageFrom = int.Parse(tbxAgeFrom.Text);

            if (tbxAgeTo.Text != "")
                ageTo = int.Parse(tbxAgeTo.Text);

            string gender = "";

            if (rdoGenderMale.Checked)
                gender = rdoGenderMale.Text;
            else if (rdoGenderFemale.Checked)
                gender = rdoGenderFemale.Text;
            else
                gender = rdoGenderAny.Text;



            if (ID == 0)
            {

                objCareerJob.Insert(tbxTitle.Text,
                                    int.Parse(tbxNoOfVacancies.Text),
                                    jobType, jobLevel, tbxEducationQualification.Text,
                                    tbxResponsibility.Text,
                                    tbxAdditionalRequirements.Text,
                                    tbxExperience.Text,
                                    rdoSalaryNegotiable.Checked,
                                    rdoSalaryDontMention.Checked,
                                    rdoSalaryRange.Checked, SalaryMinimum, SalaryMaximum,
                                    tbxOtherBenifits.Text,
                                    applicationDate, ageFrom, ageTo, gender, chkActive.Checked);

                ClearForm();
            }
            else
            {
                objCareerJob.Update(ID, tbxTitle.Text,
                                    int.Parse(tbxNoOfVacancies.Text),
                                    jobType, jobLevel, tbxEducationQualification.Text,
                                    tbxResponsibility.Text,
                                    tbxAdditionalRequirements.Text,
                                    tbxExperience.Text,
                                    rdoSalaryNegotiable.Checked,
                                    rdoSalaryDontMention.Checked,
                                    rdoSalaryRange.Checked, SalaryMinimum, SalaryMaximum,
                                    tbxOtherBenifits.Text,
                                    applicationDate, ageFrom, ageTo, gender, chkActive.Checked);
            }





            MessageController.Show(MessageCode._SaveSucceeded, MessageType.Information, Page);
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);
        }
    }

    private void ClearForm()
    {
        tbxTitle.Text = "";
        tbxNoOfVacancies.Text = "";
        tbxEducationQualification.Text = "";
        tbxResponsibility.Text = "";
        tbxAdditionalRequirements.Text = "";
        tbxExperience.Text = "";
        rdoSalaryNegotiable.Checked = true;
        rdoSalaryDontMention.Checked = false;
        rdoSalaryRange.Checked = false;
        tbxApplicationDeadline.Text = "";
        tbxOtherBenifits.Text = "";
        chkActive.Checked = false;
        tbxAgeFrom.Text = "";
        tbxAgeTo.Text = "";
        tbxSalaryMaximum.Text = "";
        tbxSalaryMinimum.Text = "";
    }



}
