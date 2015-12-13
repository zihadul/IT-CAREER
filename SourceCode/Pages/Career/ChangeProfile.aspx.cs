using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class Pages_Admin_ChangeProfile : System.Web.UI.Page
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
            LoadProfile();
        }
    }

    #region LoadSection

    protected void LoadRank()
    {
        DataTable dt = new bllRank().GetAll();
        ddlRank.DataSource = dt;
        ddlRank.DataBind();
    }
    protected void LoadPrefix()
    {
        DataTable dt = new bllArmyPrefix().GetAll();
        ddlPrefix.DataSource = dt;
        ddlPrefix.DataBind();
    }


    protected void LoadArms()
    {
        DataTable dt = new bllArms().GetAll();
        ddlArms.DataSource = dt;
        ddlArms.DataBind();
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

    public void LoadProfile()
    {
        DataTable dtCandidate = objCandidate.GetByUserName(User.Identity.Name);
        if (dtCandidate.Rows.Count > 0)
        {
            CandidateID = int.Parse(dtCandidate.Rows[0]["CandidateID"].ToString());
            tbxName.Text = dtCandidate.Rows[0]["CandidateName"].ToString();
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
               ddlPrefix.SelectedValue=dtCandidate.Rows[0]["PrefixID"].ToString();
               ddlPrefix.DataSource = dtPrefix;
               ddlPrefix.DataBind();

            }
            tbxMobile.Text = dtCandidate.Rows[0]["Mobile"].ToString();
            tbxEmail.Text = dtCandidate.Rows[0]["Email"].ToString();
        }
    }
    protected void btnPortfolio_Click(object sender, EventArgs e)
    {
        if (CandidateID > 0)
        {
            objCandidate.UpdateProfile(CandidateID, tbxName.Text, Convert.ToInt32(ddlRank.SelectedValue), Convert.ToInt32(ddlArms.SelectedValue), Convert.ToInt32(ddlFormation.SelectedValue), Convert.ToInt32(ddlUnit.SelectedValue),
                Convert.ToInt32(ddlPrefix.SelectedValue), tbxArmyNo.Text, tbxMobile.Text, tbxEmail.Text);
            MessageController.Show(MessageCode._UpdateSucceeded, MessageType.Information, Page);
        }
    }
}