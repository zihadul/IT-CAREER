using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Pages_CareerAdmin_JobAdministration : BasePage
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

    bllCareerJob objCareerJob= new bllCareerJob();

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
            Criteria = " JobTitle like '%" + tbxTitle.Text.Trim() + "%' ";


        if (ddlActive.SelectedValue != "")
        {
            if (Criteria == "")
                Criteria = " IsActive=" + ddlActive.SelectedValue;
            else
                Criteria += " and IsActive=" + ddlActive.SelectedValue;
        }

      

        if (Common.IsDate(tbxFrom.Text) && Common.IsDate(tbxTo.Text))
        {
           
            if (Criteria == "")
                Criteria = " CONVERT(DATETIME, CONVERT(NVARCHAR(10), PostDate, 102)) Between '" + Convert.ToDateTime(tbxFrom.Text).ToString("yyyy-MM-dd") + "' And '" + Convert.ToDateTime(tbxTo.Text).ToString("yyyy-MM-dd") + "'";
            else
                Criteria += " And  CONVERT(DATETIME, CONVERT(NVARCHAR(10), PostDate, 102)) Between '" + Convert.ToDateTime(tbxFrom.Text).ToString("yyyy-MM-dd") + "' And '" + Convert.ToDateTime(tbxTo.Text).ToString("yyyy-MM-dd") + "'";
        }
        else if (Common.IsDate(tbxFrom.Text))
        {


            if (Criteria == "") Criteria = " CONVERT(DATETIME, CONVERT(NVARCHAR(10), PostDate, 102))>='" + Convert.ToDateTime(tbxFrom.Text).ToString("yyyy-MM-dd") + "'";
            else Criteria += " And  CONVERT(DATETIME, CONVERT(NVARCHAR(10), PostDate, 102))>='" + Convert.ToDateTime(tbxFrom.Text).ToString("yyyy-MM-dd") + "'";

        }
        else if (Common.IsDate(tbxTo.Text))
        {


            if (Criteria == "")
                Criteria = " CONVERT(DATETIME, CONVERT(NVARCHAR(10), PostDate, 102))='" + Convert.ToDateTime(tbxTo.Text).ToString("yyyy-MM-dd") + "' ";
            else
                Criteria += " And  CONVERT(DATETIME, CONVERT(NVARCHAR(10), PostDate, 102))='" + Convert.ToDateTime(tbxTo.Text).ToString("yyyy-MM-dd") + "' ";
        }


        return Criteria;
    }

    private void BindData()
    {
        plcPaging.Controls.Clear();
        string Criteria = GetCriteria(); 

        DataTable dt = objCareerJob.GetList(CurrentPage * gv.PageSize, gv.PageSize, Criteria, PrintMode);

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
        DataView dv = objCareerJob.GetList(CurrentPage * gv.PageSize, gv.PageSize, Criteria, PrintMode).DefaultView;
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
            strSummary.Append("</b> Jobs</br>");
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

   

    protected void btnCDelete_Command(object sender, CommandEventArgs e)
    {

        int TicketID = int.Parse(e.CommandArgument.ToString());
        objCareerJob.Delete(TicketID);
        MessageController.Show(MessageCode._DeleteSucceeded, MessageType.Information, Page);
        BindAndSort();
    }
    


    #endregion



    protected void btnFilter_Click(object sender, EventArgs e)
    {
        BindData();
    }
}
