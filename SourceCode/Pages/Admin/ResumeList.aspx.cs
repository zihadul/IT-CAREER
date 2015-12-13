using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Text;

public partial class Pages_Admin_ResumeList : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["printmode"] != null)
            {
                pnlFilter.Visible = false;
                plcPaging.Visible = false;
                litPagingSummary.Visible = false;
                gv.Columns[gv.Columns.Count - 1].Visible = false;
                BindData();
            }
            else
            {
                PageSize = gv.PageSize;
                BindData();
                LoadRank();
                LoadFormation();
                LoadArms();
                LoadInterest();
                LoadCourse();
                LoadInstitution();
            }

        }
        managePaging();
        
    }

    #region variables

    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";


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


    private string UserRole
    {
        get
        {
            if (ViewState["UserRole"] == null)
                ViewState["UserRole"] = "";
            return ViewState["UserRole"].ToString();
        }
        set { ViewState["UserRole"] = value; }
    }

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

    #endregion

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

    protected void LoadInterest()
    {
        DataTable dt = new bllInterest().GetAll();
        if (dt.Rows.Count > 0)
        {
            ListItem li = new ListItem("Select Interest", "0");
            ddlInterest.Items.Add(li);
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["InterestName"].ToString();
                item.Value = (row["InterestID"].ToString());
                ddlInterest.Items.Add(item);
            }
        }
        else
        {
            ddlInterest.DataSource = null;
            ddlInterest.DataBind();
        }
    }

    protected void LoadCourse()
    {
        DataTable dt = new bllCourse().GetAll();
        if (dt.Rows.Count > 0)
        {
            ListItem li = new ListItem("Select Course", "0");
            ddlCourse.Items.Add(li);
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["CourseName"].ToString();
                item.Value = (row["CourseID"].ToString());
                ddlCourse.Items.Add(item);
            }
        }
        else
        {
            ddlCourse.DataSource = null;
            ddlCourse.DataBind();
        }
    }
    protected void LoadInstitution()
    {
        DataTable dt = new bllInstitution().GetAll();
        if (dt.Rows.Count > 0)
        {
            ListItem li = new ListItem("Select Institution", "0");
            ddlInstitution.Items.Add(li);
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["InstitutionName"].ToString();
                item.Value = (row["InstitutionID"].ToString());
                ddlInstitution.Items.Add(item);
            }
        }
        else
        {
            ddlInstitution.DataSource = null;
            ddlInstitution.DataBind();
        }
    }
    #endregion

    #region Filter
    private string GetCriteria()
    {
        string Criteria = "";

        if (ddlRank.SelectedValue != "" && ddlRank.SelectedValue!="0")
            Criteria = " RankID="+ddlRank.SelectedValue;

        if (tbxArmyNo.Text!="")
        {
            if (Criteria == "")
                Criteria = " ArmyNo=" + tbxArmyNo.Text;
            else
                Criteria += " and ArmyNo=" + tbxArmyNo.Text;
        }


        if (ddlArms.SelectedValue != "" && ddlArms.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " ArmsID=" + ddlArms.SelectedValue;
            else
                Criteria += " and ArmsID=" + ddlArms.SelectedValue;
        }
        if (ddlFormation.SelectedValue != "" && ddlFormation.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " FormationID=" + ddlFormation.SelectedValue;
            else
                Criteria += " and FormationID=" + ddlFormation.SelectedValue;
        }
        if (ddlUnit.SelectedValue != "" && ddlUnit.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " UnitID=" + ddlUnit.SelectedValue;
            else
                Criteria += " and UnitID=" + ddlUnit.SelectedValue;
        }
        if (ddlCourse.SelectedValue != "" && ddlCourse.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " CourseID=" + ddlCourse.SelectedValue;
            else
                Criteria += " and CourseID=" + ddlCourse.SelectedValue;
        }
        if (ddlInstitution.SelectedValue != "" && ddlInstitution.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " InstitutionID=" + ddlInstitution.SelectedValue;
            else
                Criteria += " and InstitutionID=" + ddlInstitution.SelectedValue;
        }
       
        return Criteria;
    }

    private string GetCriteriaWithInterest()
    {
        string Criteria = "";

        if (ddlRank.SelectedValue != "" && ddlRank.SelectedValue != "0")
            Criteria = " RankID=" + ddlRank.SelectedValue;

        if (tbxArmyNo.Text != "")
        {
            if (Criteria == "")
                Criteria = " ArmyNo=" + tbxArmyNo.Text;
            else
                Criteria += " and ArmyNo=" + tbxArmyNo.Text;
        }


        if (ddlArms.SelectedValue != "" && ddlArms.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " ArmsID=" + ddlArms.SelectedValue;
            else
                Criteria += " and ArmsID=" + ddlArms.SelectedValue;
        }
        if (ddlFormation.SelectedValue != "" && ddlFormation.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " FormationID=" + ddlFormation.SelectedValue;
            else
                Criteria += " and FormationID=" + ddlFormation.SelectedValue;
        }
        if (ddlUnit.SelectedValue != "" && ddlUnit.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " UnitID=" + ddlUnit.SelectedValue;
            else
                Criteria += " and UnitID=" + ddlUnit.SelectedValue;
        }
        if (ddlCourse.SelectedValue != "" && ddlCourse.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " CourseID=" + ddlCourse.SelectedValue;
            else
                Criteria += " and CourseID=" + ddlCourse.SelectedValue;
        }
        if (ddlInstitution.SelectedValue != "" && ddlInstitution.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " InstitutionID=" + ddlInstitution.SelectedValue;
            else
                Criteria += " and InstitutionID=" + ddlInstitution.SelectedValue;
        }
        if (ddlInterest.SelectedValue != "" && ddlInterest.SelectedValue != "0")
        {
            if (Criteria == "")
                Criteria = " InterestID=" + ddlInterest.SelectedValue;
            else
                Criteria += " and InterestID=" + ddlInterest.SelectedValue;
        }
        return Criteria;
    }
    #endregion
    protected void BindData()
    {
        string Criteria = "";
        if (Request.QueryString["printmode"] != null)
        {
            Criteria = Session["Criteria"].ToString(); ;
        }
        else
        {
            Criteria = GetCriteria();
            Session["Criteria"] = Criteria;
        }

        if (Criteria.Trim() != "") Criteria = " Where " + Criteria;

        DataTable dt = new bllCandidate().GetAllResume(Criteria, CurrentPage * gv.PageSize, gv.PageSize, PrintMode);
        gv.DataSource = dt;
        gv.DataBind();
        if (dt.Rows.Count > 0)
        {
            TotalRec = Convert.ToInt32(dt.Rows[0]["TotalRecords"].ToString());
           
        }
        else
        {
            TotalRec = 0;
            litPagingSummary.Text = "";
        }
    }
   
    private void BindData(string sortExpression, string direction)
    {
        string Criteria = "";
        DataView dv = new bllCandidate().GetAllResume(Criteria, CurrentPage * gv.PageSize, gv.PageSize, PrintMode).DefaultView;
        dv.Sort = sortExpression + direction;
        DataTable dt = dv.ToTable();
        if (dt.Rows.Count > 0)
            TotalRec = Convert.ToInt32(dt.Rows[0]["TotalRecords"].ToString());
        else
        {
            TotalRec = 0;
            litPagingSummary.Text = "";
        }

        gv.DataSource = dt;
        gv.DataBind();
        managePaging();
    }

    protected void GetResumeWithInterest()
    {
        string Criteria = "";
        if (Request.QueryString["printmode"] != null)
        {
            Criteria = Session["Criteria"].ToString(); ;
        }
        else
        {
            Criteria = GetCriteriaWithInterest();
            Session["Criteria"] = Criteria;
        }

        if (Criteria.Trim() != "") Criteria = " Where " + Criteria;

        DataTable dt = new bllCandidate().ResumeWithInterest(Criteria, CurrentPage * gv.PageSize, gv.PageSize, PrintMode);
        if (dt.Rows.Count > 0)
        {
            gv.DataSource = dt;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = null;
            gv.DataBind();
        }
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;

        if (ViewState["SortExpression"] != null)
        {
            if (GridViewSortDirection == SortDirection.Ascending)
                BindData(ViewState["SortExpression"].ToString(), ASCENDING);
            else
                BindData(ViewState["SortExpression"].ToString(), DESCENDING);
        }
        else
            BindData();
    }

    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
            e.Row.Visible = false;
    }

    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;

        ViewState["SortExpression"] = sortExpression;
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            BindData(sortExpression, DESCENDING);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            BindData(sortExpression, ASCENDING);
        }
    }

    #region Paging
    protected void managePaging()
    {

        if (TotalRec > 0)
        {
            // Variable declaration
            int numberOfPages;
            int numberOfRecords = TotalRec;
            int currentPage = CurrentPage;
            StringBuilder strSummary = new StringBuilder();

            // If number of records is more then the page size (specified in global variable)
            // Just to check either gridview have enough records to implement paging
            if (numberOfRecords > PageSize)
            {
                // Calculating the total number of pages
                numberOfPages = (int)Math.Ceiling((double)numberOfRecords / (double)PageSize);
            }
            else
            {
                numberOfPages = 1;
            }

            // Creating a small summary for records.
            strSummary.Append("Displaying <b>");

            // Creating X f X Records
            int floor = (currentPage * PageSize) + 1;
            strSummary.Append(floor.ToString());
            strSummary.Append("</b>-<b>");
            int ceil = ((currentPage * PageSize) + PageSize);

            //let say you have 26 records and you specified 10 page size, 
            // On the third page it will return 30 instead of 25 as that is based on PageSize
            // So this check will see if the ceil value is increasing the number of records. Consider numberOfRecords
            if (ceil > numberOfRecords)
            {
                strSummary.Append(numberOfRecords.ToString());
            }
            else
            {
                strSummary.Append(ceil.ToString());
            }

            // Displaying Total number of records Creating X of X of About X records.
            strSummary.Append("</b> of About <b>");
            strSummary.Append(numberOfRecords.ToString());
            strSummary.Append("</b> Records</br>");
            litPagingSummary.Text = strSummary.ToString();

            if (numberOfPages == 1)
                return;

            //Variable declaration 
            //these variables will used to calculate page number display
            int pageShowLimitStart = 1;
            int pageShowLimitEnd = 1;

            // Just to check, either there is enough pages to implement page number display logic.
            if (pageDispCount > numberOfPages)
            {
                pageShowLimitEnd = numberOfPages; // Setting the end limit to the number of pages. Means show all page numbers
            }
            else
            {
                if (currentPage > 4) // If page index is more then 4 then need to less the page numbers from start and show more on end.
                {
                    //Calculating end limit to show more page numbers
                    pageShowLimitEnd = currentPage + (int)(Math.Floor((decimal)pageDispCount / 2));
                    //Calculating Start limit to hide previous page numbers
                    pageShowLimitStart = currentPage - (int)(Math.Floor((decimal)pageDispCount / 2));
                }
                else
                {
                    //Simply Displaying the 10 pages. no need to remove / add page numbers
                    pageShowLimitEnd = pageDispCount;
                }
            }

            // Since the pageDispCount can be changed and limit calculation can cause < 0 values 
            // Simply, set the limit start value to 1 if it is less
            if (pageShowLimitStart < 1)
                pageShowLimitStart = 1;


            //Dynamic creation of link buttons


            //of course if the page is the 1st page, then there is no need of First or Previous
            if (currentPage > 0)
            {
                // First Link button to display with paging
                LinkButton objLbFirst = new LinkButton();
                objLbFirst.Click += new EventHandler(objLb_Click);
                objLbFirst.Text = "First";
                objLbFirst.ID = "lb_FirstPage";
                objLbFirst.CommandName = "pgChange";
                objLbFirst.EnableViewState = true;
                objLbFirst.CommandArgument = "1";

                //Previous Link button to display with paging
                LinkButton objLbPrevious = new LinkButton();
                objLbPrevious.Click += new EventHandler(objLb_Click);
                objLbPrevious.Text = "Previous";
                objLbPrevious.ID = "lb_PreviousPage";
                objLbPrevious.CommandName = "pgChange";
                objLbPrevious.EnableViewState = true;
                objLbPrevious.CommandArgument = currentPage.ToString();

                plcPaging.Controls.Add(objLbFirst);
                plcPaging.Controls.Add(new LiteralControl("&nbsp;&nbsp;")); // Just to give some space 
                plcPaging.Controls.Add(objLbPrevious);
                plcPaging.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
            }

            //Adding control in a place holder


            // Creatig page numbers based on the start and end limit variables.
            for (int i = pageShowLimitStart; i <= pageShowLimitEnd; i++)
            {
                if ((Page.FindControl("lb_" + i.ToString()) == null) && i <= numberOfPages)
                {
                    LinkButton objLb = new LinkButton();
                    objLb.Click += new EventHandler(objLb_Click);
                    objLb.Text = i.ToString();
                    objLb.ID = "lb_" + i.ToString();
                    objLb.CommandName = "pgChange";
                    objLb.EnableViewState = true;
                    objLb.CommandArgument = i.ToString();

                    if ((currentPage + 1) == i)
                    {
                        objLb.Enabled = false;
                        objLb.CssClass = "activePagination";
                    }
                    plcPaging.Controls.Add(objLb);
                    plcPaging.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                }
            }

            // Last Link button to display with paging


            //of course if the page is the last page, then there is no need of last or next
            if ((currentPage + 1) != numberOfPages)
            {
                LinkButton objLbLast = new LinkButton();
                objLbLast.Click += new EventHandler(objLb_Click);
                objLbLast.Text = "Last";
                objLbLast.ID = "lb_LastPage";
                objLbLast.CommandName = "pgChange";
                objLbLast.EnableViewState = true;
                objLbLast.CommandArgument = numberOfPages.ToString();

                // Next Link button to display with paging
                LinkButton objLbNext = new LinkButton();
                objLbNext.Click += new EventHandler(objLb_Click);
                objLbNext.Text = "Next";
                objLbNext.ID = "lb_NextPage";
                objLbNext.CommandName = "pgChange";
                objLbNext.EnableViewState = true;
                objLbNext.CommandArgument = (currentPage + 2).ToString();

                // Adding Control to the place holder
                plcPaging.Controls.Add(objLbNext);
                plcPaging.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                plcPaging.Controls.Add(objLbLast);
            }
        }
    }

    void objLb_Click(object sender, EventArgs e)
    {
        plcPaging.Controls.Clear();
        LinkButton objlb = (LinkButton)sender;
        CurrentPage = (int.Parse(objlb.CommandArgument.ToString()) - 1);
        gv.PageIndex = CurrentPage;
        BindData();
        managePaging();
    }

    #endregion

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        if (ddlInterest.SelectedValue != "" && ddlInterest.SelectedValue != "0")
        {
            GetResumeWithInterest();
        }
        else
        {
            BindData();
            plcPaging.Controls.Clear();
            managePaging();
        }
       
    }


}