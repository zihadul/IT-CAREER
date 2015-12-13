using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Web.Security;

public partial class UserControls_Registration : System.Web.UI.UserControl
{

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
            LoadPrefix();
        }
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

    protected void LoadPrefix()
    {
        DataTable dt = new bllArmyPrefix().GetAll();
        if (dt.Rows.Count > 0)
        {
            ListItem li = new ListItem("Select Prefix", "0");
            ddlPrefix.Items.Add(li);
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["PrefixName"].ToString();
                item.Value = (row["ArmyPrefixID"].ToString());
                ddlPrefix.Items.Add(item);
            }
        }
        else
        {
            ddlPrefix.DataSource = null;
            ddlPrefix.DataBind();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        MembershipUser mu = Membership.GetUser(tbxUserName.Text);
        if (mu == null)
        {
            MembershipCreateStatus mcu;
            Membership.CreateUser(tbxUserName.Text, tbxPassword.Text,
                                  tbxEmail.Text, "Army No?", tbxArmyNo.Text, true, out mcu);
            Roles.AddUserToRole(tbxUserName.Text, "JobSeeker");
            CandidateID = new bllMember().MemberInsert(tbxName.Text,Convert.ToInt32(ddlPrefix.SelectedValue),Convert.ToInt32(tbxArmyNo.Text), Convert.ToInt32(ddlRank.SelectedValue), Convert.ToInt32(ddlArms.SelectedValue),
                    Convert.ToInt32(ddlFormation.SelectedValue), Convert.ToInt32(ddlUnit.SelectedValue),tbxMobile.Text,tbxEmail.Text,tbxUserName.Text);

            FormsAuthentication.RedirectFromLoginPage(tbxUserName.Text, true);
            Response.Redirect("~/Pages/Career/ViewResume.aspx", true);
            
            
        }
        else
        {
            MessageController.Show("User name/Army no. already exists, try another.", MessageType.Error, Page);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        tbxName.Text = "";
        tbxArmyNo.Text = "";
        tbxMobile.Text = "";
        tbxEmail.Text = "";
        tbxPassword.Text = "";
        tbxConfirmPassword.Text = "";
        ddlPrefix.SelectedValue = "0";
        ddlArms.SelectedValue = "0";
        ddlFormation.SelectedValue = "0";
        ddlRank.SelectedValue = "0";
        ddlUnit.SelectedValue = null;
    }
}