using System;
using System.Data;
using BLL;
using System.Web.UI.WebControls;

public partial class Pages_Career_EditResume : System.Web.UI.Page
{

    bllCandidate objCandidate = new bllCandidate();

    int CandidateID
    {
        set { ViewState["CandidateID"] = value; }
        get { return ViewState["CandidateID"] == null ? 0 : int.Parse(ViewState["CandidateID"].ToString()); }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCareer();
        }
    }
    #region LoadSection

    protected void LoadRank()
    {
        DataTable dt = new bllRank().GetAll();
        ddlRank.DataSource = dt;
        ddlRank.DataBind();
    }

    protected void LoadArms()
    {
        DataTable dt = new bllArms().GetAll();
        ddlArms.DataSource = dt;
        ddlArms.DataBind();
    }
    protected void LoadPrefix()
    {
        DataTable dt = new bllArmyPrefix().GetAll();
        ddlPrefix.DataSource = dt;
        ddlPrefix.DataBind();
    }

    protected void LoadFormation()
    {
        DataTable dt = new bllFormation().GetAll();
        ddlFormation.DataSource = dt;
        ddlFormation.DataBind();
    }

    protected void ddlFormation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlFormation.SelectedValue) > 0)
        {
            ddlUnit.Items.Clear();
            LoadUnit();
        }
    }

    protected void LoadUnit()
    {
        DataTable dt = new bllUnit().GetByDivisionID(Convert.ToInt32(ddlFormation.SelectedValue));
        ddlUnit.DataSource = dt;
        ddlUnit.DataBind();
    }
    #endregion
    private void LoadCareer()
    {

        DataTable dtCandidate = objCandidate.GetByUserName(User.Identity.Name);

        if (dtCandidate.Rows.Count == 0)
        {
            Response.Redirect("ResumePost.aspx");
        }
        else
        {
            CandidateID = int.Parse(dtCandidate.Rows[0]["CandidateID"].ToString());
            tbxName.Text = dtCandidate.Rows[0]["CandidateName"].ToString();
            tbxFName.Text = dtCandidate.Rows[0]["FatherName"].ToString();
            tbxMName.Text = dtCandidate.Rows[0]["MotherName"].ToString();
            tbxArmyNo.Text = dtCandidate.Rows[0]["ArmyNo"].ToString();
            DataTable dtRank = new bllRank().GetAll();
            if (dtRank.Rows.Count > 0)
            {
                ddlRank.SelectedValue = dtCandidate.Rows[0]["RankID"].ToString();
                ddlRank.DataSource = dtRank;
                ddlRank.DataBind();
            }

            DataTable dtArms = new bllArms().GetAll();
            if (dtArms.Rows.Count > 0)
            {
                ddlArms.SelectedValue = dtCandidate.Rows[0]["ArmsID"].ToString();
                ddlArms.DataSource = dtArms;
                ddlArms.DataBind();
            }
            DataTable dtFormation = new bllFormation().GetAll();
            if (dtFormation.Rows.Count > 0)
            {
                ddlFormation.SelectedValue = dtCandidate.Rows[0]["FormationID"].ToString();
                ddlFormation.DataSource = dtFormation;
                ddlFormation.DataBind();
            }
            DataTable dtUnit = new bllUnit().GetByDivisionID(Convert.ToInt32(ddlFormation.SelectedValue));
            if (dtUnit.Rows.Count > 0)
            {
                ddlUnit.SelectedValue = dtCandidate.Rows[0]["UnitID"].ToString();
                ddlUnit.DataSource = dtUnit;
                ddlUnit.DataBind();
            }
            DataTable dtPrefix = new bllArmyPrefix().GetAll();
            if (dtPrefix.Rows.Count > 0)
            {
                ddlPrefix.SelectedValue = dtCandidate.Rows[0]["PrefixID"].ToString();
                ddlPrefix.DataSource = dtPrefix;
                ddlPrefix.DataBind();

            }

            if (dtCandidate.Rows[0]["BirthDate"].ToString() != "")
            {
                tbxDateofBirth.Text = Convert.ToDateTime(dtCandidate.Rows[0]["BirthDate"].ToString()).ToString("dd-MMM-yyyy");
            }
            ddlGender.SelectedValue = dtCandidate.Rows[0]["Gender"].ToString();
            ddlMaritalStatus.SelectedValue = dtCandidate.Rows[0]["MaritalStatus"].ToString();
            //tbxReligion.Text = dtCandidate.Rows[0]["Religion"].ToString();
            ddlReligion.SelectedValue = dtCandidate.Rows[0]["Religion"].ToString();
            tbxPresentAddress.Text = dtCandidate.Rows[0]["PresentAddress"].ToString();
            tbxPermanentAddress.Text = dtCandidate.Rows[0]["PermanentAddress"].ToString();
            tbxMobile.Text = dtCandidate.Rows[0]["Mobile"].ToString();
            tbxEmail.Text = dtCandidate.Rows[0]["Email"].ToString();

            tbxCareerSummery.Text = dtCandidate.Rows[0]["CareerSummary"].ToString();
            tbxSpecialQualification.Text = dtCandidate.Rows[0]["SpecialQualification"].ToString();
            //tbxKeywords.Text = dtCandidate.Rows[0]["SearchKeyword"].ToString();

            CarrerEducationTraining1.CandidateID = CandidateID;
            CarrerTraining.CandidateID = CandidateID;
            CarrerSkill.CandidateID = CandidateID;
            CarrerPhoto.CandidateID = CandidateID;
            Portfolio.CandidateID = CandidateID;



            CarrerEducationTraining1.InitializeControl();
            CarrerTraining.InitializeControl();
            CarrerSkill.InitializeControl();
            CarrerPhoto.InitializeControl();
            Portfolio.InitializeControl();


        }

    }
    public DataTable Interest()
    {
        DataTable dt = new DataTable("CandidateInterest");
        dt.Columns.Add("CandidateIDn", typeof(int));
        dt.Columns.Add("InterestIDn", typeof(int));
        return dt;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (SavePersonalInformation())
        {
            mv.ActiveViewIndex = 1;
            SetTabCss();
        }
    }

    public bool SavePersonalInformation()
    {
        bool succeed = false;
        try
        {
            string strMessage = "";
            DataTable dt = Interest();
            if (!Common.IsDate(tbxDateofBirth.Text))
                strMessage += "<li>Invalid Date of Birth.</li>";


            if (strMessage != "")
            {
                MessageController.Show("<ul>" + strMessage + "</ul>", MessageType.Error, Page);
                return false;
            }

            objCandidate.Update(CandidateID, tbxName.Text.Trim(),
                                tbxFName.Text.Trim(),
                                tbxMName.Text.Trim(),
                                Convert.ToInt32(ddlRank.SelectedValue),
                                Convert.ToInt32(ddlArms.SelectedValue),
                                Convert.ToInt32(ddlFormation.SelectedValue),
                                Convert.ToInt32(ddlUnit.SelectedValue),
                                Convert.ToInt32(ddlPrefix.SelectedValue),
                                Convert.ToInt32(tbxArmyNo.Text),
                                Convert.ToDateTime(tbxDateofBirth.Text),
                                ddlGender.SelectedItem.Text,
                                ddlMaritalStatus.SelectedItem.Text,
                                ddlReligion.SelectedItem.Text,
                                tbxPresentAddress.Text,
                                tbxPermanentAddress.Text,
                                tbxMobile.Text,
                                tbxEmail.Text,
                                tbxCareerSummery.Text,
                                tbxSpecialQualification.Text,
                                "");

            CarrerPhoto.CandidateID = CandidateID;
            CarrerPhoto.SavePhotograph();
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);
        }
        return succeed;
    }
    #region ClickNext

    protected void btnEducation_Click(object sender, EventArgs e)
    {
        if (CarrerEducationTraining1.SaveEducationTraining())
        {

            mv.ActiveViewIndex = 2;

            SetTabCss();

        }

    }

    protected void btnTraining_Click(object sender, EventArgs e)
    {
        if (CarrerTraining.SaveTrainingSummery())
        {

            mv.ActiveViewIndex = 3;

            SetTabCss();

        }
    }
    protected void btnSkill_Click(object sender, EventArgs e)
    {
        if (CarrerSkill.SaveSkill())
        {

            mv.ActiveViewIndex = 4;

            SetTabCss();

        }
    }

    protected void btnPortfolio_Click(object sender, EventArgs e)
    {
        if (Portfolio.SavePortfolio() & SavePersonalInformation() & CarrerEducationTraining1.SaveEducationTraining() & CarrerTraining.SaveTrainingSummery() & CarrerSkill.SaveSkill())
        {
            Response.Redirect("ViewResume.aspx");
        }
        else
        {
            Response.Redirect("ViewResume.aspx");
        }
        
    }



    protected void btnSkip_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex++;
        SetTabCss();
    }

    protected void Prev_Click(object sender, EventArgs e)
    {

        mv.ActiveViewIndex--;
        SetTabCss();

    }
    #endregion
    private void SetTabCss()
    {
        pnlPersonal.CssClass = "InActiveTab";
        pnlEducationTraining.CssClass = "InActiveTab";
        pnlTraining.CssClass = "InActiveTab";
        pnlSkill.CssClass = "InActiveTab";
        pnlPortfolio.CssClass = "InActiveTab";

        if (mv.ActiveViewIndex == 0)
            pnlPersonal.CssClass = "ActiveTab";
        else if (mv.ActiveViewIndex == 1)
            pnlEducationTraining.CssClass = "ActiveTab";
        else if (mv.ActiveViewIndex == 2)
            pnlTraining.CssClass = "ActiveTab";
        else if (mv.ActiveViewIndex == 3)
            pnlSkill.CssClass = "ActiveTab";
        else
            pnlPortfolio.CssClass = "ActiveTab";

        lblStep.Text = "Step " + (mv.ActiveViewIndex + 1).ToString() + " of 5";

    }


    #region Link
    protected void lnkPersonal_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 0;
        SetTabCss();
    }
    protected void lnkEducation_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 1;
        SetTabCss();
    }
    protected void lnkCourse_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 2;
        SetTabCss();
    }
    protected void lnkInterest_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 3;
        SetTabCss();
    }
    protected void lnkPortfolio_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 4;
        SetTabCss();
    }
    #endregion Link

}
