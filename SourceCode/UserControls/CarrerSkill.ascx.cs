using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class UserControls_CarrerSkill : System.Web.UI.UserControl
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
        LoadInterest();
        LoadHardware();
        LoadNetwork();
    }

    public DataTable Interest()
    {
        DataTable dt = new DataTable("CandidateInterest");
        dt.Columns.Add("CandidateIDn", typeof(int));
        dt.Columns.Add("InterestIDn", typeof(int));
        return dt;
    }
    #region LoadInterest
    protected void LoadInterest()
    {
        //DataTable dt = new bllInterest().GetByCategory(ddlCategory.SelectedItem.Text);
        pnlInterest.Enabled = false;
        DataTable dtInterest = new bllInterest().InterestByCandidateID(CandidateID);
        DataTable dt = new bllInterest().GetByCategory(chkSoftware.Text);
        dlInterest.DataSource = dt;
        dlInterest.DataBind();
        foreach (DataListItem li in dlInterest.Items)
        {
            CheckBox chkInterest = (CheckBox)li.FindControl("chkInterest");
            if (chkInterest != null)
            {
                int InterestID = Convert.ToInt32(((Label)li.FindControl("lblInterestID")).Text);
                foreach (DataRow dr in dtInterest.Rows)
                {
                    if (Convert.ToInt32(dr["InterestID"].ToString()) == InterestID)
                    {
                        chkInterest.Checked = true;
                    }
                }
            }
        }
    }
    protected void LoadHardware()
    {
        //DataTable dt = new bllInterest().GetByCategory(ddlCategory.SelectedItem.Text);
        pnlHardware.Enabled = false;
        DataTable dtInterest = new bllInterest().InterestByCandidateID(CandidateID);
        DataTable dt = new bllInterest().GetByCategory(chkHardware.Text);
        dlHardware.DataSource = dt;
        dlHardware.DataBind();
        foreach (DataListItem li in dlHardware.Items)
        {
            CheckBox chkInterest = (CheckBox)li.FindControl("chkInterest");
            if (chkInterest != null)
            {
                int InterestID = Convert.ToInt32(((Label)li.FindControl("lblInterestID")).Text);
                foreach (DataRow dr in dtInterest.Rows)
                {
                    if (Convert.ToInt32(dr["InterestID"].ToString()) == InterestID)
                    {
                        chkInterest.Checked = true;
                    }
                }
            }
        }
    }
    protected void LoadNetwork()
    {
        //DataTable dt = new bllInterest().GetByCategory(ddlCategory.SelectedItem.Text);
        pnlnetwork.Enabled = false;
        DataTable dtInterest = new bllInterest().InterestByCandidateID(CandidateID);
        DataTable dt = new bllInterest().GetByCategory(chkNetwork.Text);
        dlNetwork.DataSource = dt;
        dlNetwork.DataBind();
        foreach (DataListItem li in dlNetwork.Items)
        {
            CheckBox chkInterest = (CheckBox)li.FindControl("chkInterest");
            if (chkInterest != null)
            {
                int InterestID = Convert.ToInt32(((Label)li.FindControl("lblInterestID")).Text);
                foreach (DataRow dr in dtInterest.Rows)
                {
                    if (Convert.ToInt32(dr["InterestID"].ToString()) == InterestID)
                    {
                        chkInterest.Checked = true;
                    }
                }
            }
        }
    }
    #endregion
    public bool SaveSkill()
    {
        bool succeed = false;
        try
        {
            DataTable dtInterest = GetInterest();
            new bllInterest().DeleteByCandidateID(CandidateID);
            new bllInterest().InsertCandidateInterest(dtInterest);
            succeed = true;
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);

        }

        return succeed;
    }

    #region Professional Qualification
   
    private DataTable GetInterest()
    {
        DataTable dt = Interest();

        foreach (DataListItem li in dlInterest.Items)
        {
            CheckBox chkInterest = (CheckBox)li.FindControl("chkInterest");
            if (chkInterest != null)
            {
                if (chkInterest.Checked == true)
                {
                    int InterestID = Convert.ToInt32(((Label)li.FindControl("lblInterestID")).Text);
                    dt.Rows.Add(CandidateID, InterestID);
                }
            }
        }
        foreach (DataListItem li in dlHardware.Items)
        {
            CheckBox chkInterest = (CheckBox)li.FindControl("chkInterest");
            if (chkInterest != null)
            {
                if (chkInterest.Checked == true)
                {
                    int InterestID = Convert.ToInt32(((Label)li.FindControl("lblInterestID")).Text);
                    dt.Rows.Add(CandidateID, InterestID);
                }
            }
        }
        foreach (DataListItem li in dlNetwork.Items)
        {
            CheckBox chkInterest = (CheckBox)li.FindControl("chkInterest");
            if (chkInterest != null)
            {
                if (chkInterest.Checked == true)
                {
                    int InterestID = Convert.ToInt32(((Label)li.FindControl("lblInterestID")).Text);
                    dt.Rows.Add(CandidateID, InterestID);
                }
            }
        }
        return dt;
    }
    
    #endregion

    #region CheckecChange
    protected void chkSoftware_CheckedChanged(object sender, EventArgs e)
    {
        LoadInterest();
        if (chkSoftware.Checked)
        {
            pnlInterest.Enabled = true;
        }
        else
        {
            pnlInterest.Enabled = false;
        }

    }
    protected void chkHardware_CheckedChanged(object sender, EventArgs e)
    {
        LoadHardware();
        if (chkHardware.Checked)
        {
            pnlHardware.Enabled = true;
        }
        else
        {
            pnlHardware.Enabled = false;
        }

    }
    protected void chkNetwork_CheckedChanged(object sender, EventArgs e)
    {
        LoadNetwork();
        if (chkNetwork.Checked)
        {
            pnlnetwork.Enabled = true;
        }
        else
        {
            pnlnetwork.Enabled = false;
        }

    }
    #endregion
}