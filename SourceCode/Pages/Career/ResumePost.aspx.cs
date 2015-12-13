using System;
using System.Data;
using System.Web.Security;
using BLL;
using System.Web.UI.WebControls;

public partial class Pages_Career_ResumePost : System.Web.UI.Page
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
            LoadRank();
            LoadFormation();
            LoadUnit();
            LoadArms();
        }
        
    }

    private void LoadCareer()
    {
        
    }
    #region LoadSection

    protected void LoadRank()
    {
        DataTable dt = new bllRank().GetAll();
        if (dt.Rows.Count > 0)
        {
            ListItem li = new ListItem("Select Rank", "0");
            ddlRank.Items.Add(li);
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["RankName"].ToString();
                item.Value = (row["RankID"].ToString());
                ddlRank.Items.Add(item);
            }
        }
        else
        {
            ddlRank.DataSource = null;
            ddlRank.DataBind();
        }
    }

    protected void LoadArms()
    {
        DataTable dt = new bllArms().GetAll();
        if (dt.Rows.Count > 0)
        {
            ListItem li = new ListItem("Select Arms", "0");
            ddlArms.Items.Add(li);
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["ArmsName"].ToString();
                item.Value = (row["ArmsID"].ToString());
                ddlArms.Items.Add(item);
            }
        }
        else
        {
            ddlArms.DataSource = null;
            ddlArms.DataBind();
        }
    }

    protected void LoadFormation()
    {
        DataTable dt = new bllFormation().GetAll();
        if (dt.Rows.Count > 0)
        {
            ListItem li = new ListItem("Select Formation", "0");
            ddlFormation.Items.Add(li);
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["FormationName"].ToString();
                item.Value = (row["FormationID"].ToString());
                ddlFormation.Items.Add(item);
            }
        }
        else
        {
            ddlFormation.DataSource = null;
            ddlFormation.DataBind();
        }
    }

    protected void ddlFormation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlUnit.Items.Clear();
        LoadUnit();
    }

    protected void LoadUnit()
    {
        DataTable dt = new bllUnit().GetByDivisionID(Convert.ToInt32(ddlFormation.SelectedValue));
        ddlUnit.DataSource = dt;
        ddlUnit.DataBind();
    }

   
    #endregion


    public DataTable Interest()
    {
        DataTable dt = new DataTable("CandidateInterest");
        dt.Columns.Add("CandidateIDn", typeof(int));
        dt.Columns.Add("InterestIDn", typeof(int));
        return dt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string strMessage = "";
            DataTable dt = Interest();

            if (CandidateID == 0)
            {
                if (!CheckUserAvailable())
                    strMessage = "<li>User name already exists, try another.</li>";
            }


            if (!Common.IsDate(tbxDateofBirth.Text))
                strMessage += "<li>Invalid Date of Birth.</li>";


            if (strMessage != "")
            {
                MessageController.Show("<ul>" + strMessage + "</ul>", MessageType.Error, Page);
                return;
            }


            if (CandidateID == 0)
            {
                MembershipCreateStatus mcu;
                Membership.CreateUser(tbxUserName.Text, tbxPassword.Text,
                                      tbxEmail.Text, "Email?", tbxEmail.Text, true, out mcu);


                if (mcu == MembershipCreateStatus.Success)
                {

                    Roles.AddUserToRole(tbxUserName.Text, "JobSeeker");

                    CandidateID = objCandidate.Insert(tbxName.Text.Trim(),
                                                      tbxFName.Text.Trim(),
                                                      tbxMName.Text.Trim(),
                                                      Convert.ToInt32(ddlRank.SelectedValue),
                                                      Convert.ToInt32(ddlArms.SelectedValue),
                                                      Convert.ToInt32(ddlFormation.SelectedValue),
                                                      Convert.ToInt32(ddlUnit.SelectedValue),
                                                      Convert.ToInt32(ddlRank.SelectedValue),//prefix no need this page in IT Career
                                                      Convert.ToInt32(tbxArmyNo.Text),
                                                      Convert.ToDateTime(tbxDateofBirth.Text),
                                                      ddlGender.SelectedItem.Text,
                                                      ddlMaritalStatus.SelectedItem.Text,
                                                      tbxReligion.Text,
                                                      tbxPresentAddress.Text,
                                                      tbxPermanentAddress.Text,
                                                      tbxMobile.Text,
                                                      tbxEmail.Text,
                                                      tbxCareerSummery.Text,
                                                      tbxSpecialQualification.Text,
                                                      tbxKeywords.Text,
                                                      tbxUserName.Text);
                   
                    CarrerPhoto.CandidateID = CandidateID;
                    CarrerPhoto.SavePhotograph();
                }
                else
                {
                   
                    MessageController.Show("Error in user creation", MessageType.Error, Page);
                    return;
                }
            }
            else
            {
                objCandidate.Update(CandidateID, tbxName.Text.Trim(),
                                    tbxFName.Text.Trim(),
                                    tbxMName.Text.Trim(),
                                    Convert.ToInt32(ddlRank.SelectedValue),
                                    Convert.ToInt32(ddlArms.SelectedValue),
                                    Convert.ToInt32(ddlFormation.SelectedValue),
                                    Convert.ToInt32(ddlUnit.SelectedValue),
                                    Convert.ToInt32(ddlRank.SelectedValue),//prefix no need this page in IT Career
                                    Convert.ToInt32(tbxArmyNo.Text),
                                    Convert.ToDateTime(tbxDateofBirth.Text),
                                    ddlGender.SelectedItem.Text,
                                    ddlMaritalStatus.SelectedItem.Text,
                                    tbxReligion.Text,
                                    tbxPresentAddress.Text,
                                    tbxPermanentAddress.Text,
                                    tbxMobile.Text,
                                    tbxEmail.Text,
                                    tbxCareerSummery.Text,
                                    tbxSpecialQualification.Text,
                                    tbxKeywords.Text
                                    );

            }


            CarrerEducationTraining1.CandidateID = CandidateID;
            CarrerTraining.CandidateID = CandidateID;
            CarrerSkill.CandidateID = CandidateID;
            
            
            CarrerEducationTraining1.InitializeControl();
            CarrerSkill.InitializeControl();
            CarrerTraining.InitializeControl();
            CarrerPhoto.InitializeControl();
            mv.ActiveViewIndex = 1;

            SetTabCss();
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);
        }
    }

  
    

    protected void lnkCheckUserAvailable_Click(object sender, EventArgs e)
    {
        if(!CheckUserAvailable())
        {

          
            MessageController.Show("User name already exists, try another.", MessageType.Error, Page);
        }
        else
        {
            MessageController.Show("User name is available for you.", MessageType.Information, Page);
        }
    }

    private bool CheckUserAvailable()
    {
        MembershipUser mu = Membership.GetUser(tbxUserName.Text);
        return mu == null;

    }

    protected void btnPersonalDetailPrevious_Click(object sender, EventArgs e)
    {
            CarrerEducationTraining1.InitializeControl();
            mv.ActiveViewIndex = 0;
            SetTabCss();
            LoadUserName();
    }

    private void LoadUserName()
    {
        DataTable dtCandidate = new bllCandidate().GetByUserName(tbxUserName.Text);
       // DataTable dtCandidate = objCandidate.GetByUserName(User.Identity.Name);

        if (dtCandidate.Rows.Count == 0)
        {
            Response.Redirect("ResumePost.aspx");
        }
        else
        {
            CandidateID = int.Parse(dtCandidate.Rows[0]["CandidateID"].ToString());
            tbxName.Text = dtCandidate.Rows[0]["CandidateName"].ToString();
            tbxDateofBirth.Text = Convert.ToDateTime(dtCandidate.Rows[0]["BirthDate"].ToString()).ToString("dd-MMM-yyyy");
            ddlGender.SelectedValue = dtCandidate.Rows[0]["Gender"].ToString();
            ddlMaritalStatus.SelectedValue = dtCandidate.Rows[0]["MaritalStatus"].ToString();
            tbxReligion.Text = dtCandidate.Rows[0]["Religion"].ToString();
            tbxPresentAddress.Text = dtCandidate.Rows[0]["PresentAddress"].ToString();
            tbxPermanentAddress.Text = dtCandidate.Rows[0]["PermanentAddress"].ToString();
            tbxMobile.Text = dtCandidate.Rows[0]["Mobile"].ToString();
            tbxEmail.Text = dtCandidate.Rows[0]["Email"].ToString();
           
            tbxCareerSummery.Text = dtCandidate.Rows[0]["CareerSummary"].ToString();
            tbxSpecialQualification.Text = dtCandidate.Rows[0]["SpecialQualification"].ToString();
            tbxKeywords.Text = dtCandidate.Rows[0]["SearchKeyword"].ToString();
           
            CarrerEducationTraining1.CandidateID = CandidateID;
            CarrerTraining.CandidateID = CandidateID;
            CarrerSkill.CandidateID = CandidateID;
            
            CarrerEducationTraining1.InitializeControl();
            CarrerSkill.InitializeControl();
            CarrerTraining.InitializeControl();
        }
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

            Response.Redirect("~/Pages/Career/ViewResume.aspx");

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

    private  void SetTabCss()
    {
        pnlPersonal.CssClass = "InActiveTab";
        pnlEducationTraining.CssClass = "InActiveTab";
        pnlTraining.CssClass = "InActiveTab";
        pnlSkill.CssClass = "InActiveTab";

        if (mv.ActiveViewIndex == 0)
            pnlPersonal.CssClass = "ActiveTab";
        else if (mv.ActiveViewIndex == 1)
            pnlEducationTraining.CssClass = "ActiveTab";
        else if (mv.ActiveViewIndex == 2)
            pnlTraining.CssClass = "ActiveTab";
        else 
            pnlSkill.CssClass = "ActiveTab";
      
        lblStep.Text = "Step " + (mv.ActiveViewIndex + 1).ToString() + " of 4";

    }

    protected void lnkPersonal_Click(object sender, EventArgs e)
    {

    }
    protected void lnkEducation_Click(object sender, EventArgs e)
    {
        if (CandidateID != 0)
        {
            mv.ActiveViewIndex = 1;
            pnlEducationTraining.CssClass = "ActiveTab";
        }
    }
    protected void lnkCourse_Click(object sender, EventArgs e)
    {

    }
    protected void lnkInterest_Click(object sender, EventArgs e)
    {

    }

    protected void lnkEducation_Click(object sender, CommandEventArgs e)
    {
        mv.ActiveViewIndex = 1;
        pnlEducationTraining.CssClass = "ActiveTab";
        
    }
   
}
