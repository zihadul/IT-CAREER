using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Pages_CareerAdmin_Candidates : BasePage
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

    int JobID
    {
        set { ViewState["JobID"] = value; }
        get { return ViewState["JobID"] == null ? 0 : int.Parse(ViewState["JobID"].ToString()); }
    }

    bllCareerCandidateJob objCareerCandidateJob = new bllCareerCandidateJob();
    bllCandidate objCandidate = new bllCandidate(); 

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
                litPagingSummary.Visible = false;

                gv.Columns[gv.Columns.Count - 1].Visible = false;
                gv.Columns[gv.Columns.Count - 2].Visible = false;

            }


            if (Request.QueryString["JobID"] != null)
                JobID = int.Parse(Request.QueryString["JobID"]);

            if (Request.QueryString["ShortList"] != null)
                ddlAction.SelectedValue = "Short Listed";


            PageSize = gv.PageSize;
            BindData();
        }
        else
        {
            managePaging();
        }

       

       
    }
   
    #endregion

    #region Methods

   

    private  string GetCriteria()
    {


        string Criteria = "";

        if (tbxTitle.Text.Trim() != "")
            Criteria = " CareerCandidateDetail.CandidateName like '%" + tbxTitle.Text.Trim() + "%' ";


        if (ddlGender.SelectedValue != "All")
        {
            if (Criteria == "")
                Criteria = " CareerCandidateDetail.Gender='" + ddlGender.SelectedValue + "' ";
            else
                Criteria += " And CareerCandidateDetail.Gender='" + ddlGender.SelectedValue + "' ";
            
        }
      
        if (tbxAge.Text != "")
        {
            if (Criteria == "")
                Criteria = " dbo.CalculateAge(CareerCandidateDetail.BirthDate)" + ddlAgeOperator.SelectedValue +
                           tbxAge.Text;
            else
                Criteria += " And dbo.CalculateAge(CareerCandidateDetail.BirthDate)" + ddlAgeOperator.SelectedValue +
                           tbxAge.Text;
        }


        //if (tbxExpectedSalary.Text != "")
        //{
        //    if (Criteria == "")
        //        Criteria = " CareerCandidateDetail.ExpectedSalary" + ddlSalaryOperator.SelectedValue +
        //                   tbxExpectedSalary.Text;
        //    else
        //        Criteria += " And CareerCandidateDetail.ExpectedSalary" + ddlSalaryOperator.SelectedValue +
        //                   tbxExpectedSalary.Text;
        //}

        if (tbxExperience.Text != "")
        {
            if (Criteria == "")
                Criteria = " CareerCandidateDetail.YearOfExperience" + ddlExperienceOperator.SelectedValue +
                           tbxExperience.Text;
            else
                Criteria += " And CareerCandidateDetail.YearOfExperience" + ddlExperienceOperator.SelectedValue +
                           tbxExperience.Text;
        }


        return Criteria;
    }

    private void BindData()
    {
        plcPaging.Controls.Clear();
        string Criteria = GetCriteria();

        bool ShortListed = false;
        bool Rejected = false;

        if (ddlAction.SelectedValue == "Short Listed")
            ShortListed = true;
        else if (ddlAction.SelectedValue == "Rejected")
            Rejected = true;

        DataTable dt = objCareerCandidateJob.GetCareerCandidateJob(CurrentPage * gv.PageSize, gv.PageSize, 
            Criteria,JobID, tbxQualification.Text.Trim(), tbxTraining.Text.Trim(), ShortListed, Rejected,  PrintMode);

        if (dt.Rows.Count < 10)
        {
            plcPaging.Visible = false;
        }
        else
        {
            plcPaging.Visible = true;
        }

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


    private void BindData(string sortExpression, string direction)
    {
        string Criteria = GetCriteria(); 

        plcPaging.Controls.Clear();

        bool ShortListed = false;
        bool Rejected = false;

        if (ddlAction.SelectedValue == "Short Listed")
            ShortListed = true;
        else if (ddlAction.SelectedValue == "Rejected")
            Rejected = true;

        DataView dv = objCareerCandidateJob.GetCareerCandidateJob(CurrentPage * gv.PageSize, gv.PageSize,
            Criteria, JobID, tbxQualification.Text.Trim(), tbxTraining.Text.Trim(), ShortListed, Rejected, PrintMode).DefaultView;
        dv.Sort = sortExpression + direction;


        DataTable dt = dv.ToTable();

        if (dt.Rows.Count < 10)
        {
            plcPaging.Visible = false;
        }
        else
        {
            plcPaging.Visible = true;
        }

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

    private void BindAndSort()
    {
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
            strSummary.Append("</b> Candidates</br>");
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

        LinkButton objlb = (LinkButton)sender;
        CurrentPage = (int.Parse(objlb.CommandArgument.ToString()) - 1);
        gv.PageIndex = CurrentPage;
        BindData();
    }

   

  
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        BindAndSort();
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



    #endregion



    protected void btnFilter_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType != DataControlRowType.DataRow) return;
        int CandidateID = int.Parse(gv.DataKeys[e.Row.RowIndex].Value.ToString());


        HyperLink hyView = e.Row.FindControl("hyView") as HyperLink;

        string JobID = "";

        if (Request.QueryString["JobID"] != null)
            JobID = Request.QueryString["JobID"];


        hyView.NavigateUrl = "~/Pages/Career/ViewResume.aspx?CandidateID=" + CandidateID.ToString() + "&JobID=" + JobID;


        DataList dlEmploymentHistory = e.Row.FindControl("dlEmploymentHistory") as DataList;


        dlEmploymentHistory.DataSource = objCandidate.GetEmploymentHistory(CandidateID);
        dlEmploymentHistory.DataBind();


        HiddenField hdnShortListed = e.Row.FindControl("hdnShortListed") as HiddenField;
        HiddenField hdnRejected = e.Row.FindControl("hdnRejected") as HiddenField;

        bool ShortListed = false;
        bool Rejected = false;


        if (hdnShortListed.Value != "")
            ShortListed = Convert.ToBoolean(hdnShortListed.Value);

        if (hdnRejected.Value != "")
            Rejected = Convert.ToBoolean(hdnRejected.Value);


        if (ShortListed)
            e.Row.BackColor = System.Drawing.Color.FromName("#9AD2AF");
        else if (Rejected)
            e.Row.BackColor = System.Drawing.Color.FromName("#EADBD0");
            
    }
}
