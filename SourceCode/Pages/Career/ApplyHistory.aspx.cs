using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Career_ApplyHistory : System.Web.UI.Page
{
    #region Members
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";

    private SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }




    const int pageDispCount = 10;
    int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
                return 0;
            else
                return Convert.ToInt32(ViewState["CurrentPage"].ToString());
        }
        set { ViewState["CurrentPage"] = value; }

    }
    int TotalRec
    {
        get
        {
            if (ViewState["TotalRec"] == null)
                return 0;
            else
                return Convert.ToInt32(ViewState["TotalRec"].ToString());
        }
        set { ViewState["TotalRec"] = value; }

    }
    int PageSize
    {
        get
        {
            if (ViewState["PageSize"] == null)
                return 0;
            else
                return Convert.ToInt32(ViewState["PageSize"].ToString());
        }
        set { ViewState["PageSize"] = value; }

    }
    bool PrintMode
    {
        get
        {
            if (ViewState["PrintMode"] == null)
                return false;
            else
                return Convert.ToBoolean(ViewState["PrintMode"].ToString());
        }
        set { ViewState["PrintMode"] = value; }

    }

    bllCareerJob objCareerJob = new bllCareerJob();

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["printmode"] != null)
            {
                PrintMode = true;
                plcPaging.Visible = false;

                gv.Columns[gv.Columns.Count - 1].Visible = false;
                gv.Columns[gv.Columns.Count - 2].Visible = false;
            }

            PageSize = gv.PageSize;
            BindData();
        }
        
    }

    #endregion

    #region Methods



    private string GetCriteria()
    {
        string Criteria = "";

        if (ddlJobType.SelectedItem.Text != "All")
            Criteria = " JobType='" + ddlJobType.SelectedItem.Text + "' ";


        if (ddlJobLevel.SelectedItem.Text != "All")
        {
            if (Criteria == "")
                Criteria = " JobLevel like '%" + ddlJobLevel.SelectedItem.Text + "%' ";
            else
                Criteria += " and JobLevel like '%" + ddlJobLevel.SelectedItem.Text + "%' ";
        }

        return Criteria;
    }

    private void BindData()
    {
        plcPaging.Controls.Clear();
        string Criteria = GetCriteria();

        DataView dv =new bllCandidate().GetByCandidateUserName(User.Identity.Name).DefaultView;

        dv.RowFilter = Criteria;
        DataTable dt = dv.ToTable();

        if (dt.Rows.Count < 20)
        {
            plcPaging.Visible = false;
        }
        else
        {
            plcPaging.Visible = true;
        }

        if (dt.Rows.Count > 0)
            TotalRec = Convert.ToInt32(dt.Rows.Count.ToString());
        else
            TotalRec = 0;



        gv.DataSource = dt;
        gv.DataBind();
       
    }



    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
            e.Row.Visible = false;
    }

  

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindData();
    }

    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;

        ViewState["SortExpression"] = sortExpression;
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
           
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
           
        }
    }


    #endregion



    protected void btnFilter_Click(object sender, EventArgs e)
    {
        BindData();
    }
}