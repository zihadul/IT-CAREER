using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

public sealed class LanguageManager
{
    public new static string ToString()
    {
        return "CURRENT_LANGUAGE";
    }

    /// Current selected culture
    public static CultureInfo CurrentCulture
    {
        get { return Thread.CurrentThread.CurrentCulture; }
        set
        {
            Thread.CurrentThread.CurrentUICulture = value;
            Thread.CurrentThread.CurrentCulture = value;
        }
    }

    public static void ApplyNewLanguageAndRefreshPage(Page p)
    {



        //Refresh the current page to make all control-texts take effect
        //Response.Redirect(Request.Url.AbsoluteUri);
        //return;
        string CurrentPage = p.ToString().Replace("_", ".").Replace("ASP.", "");
        string CurrentCulture = "en-US";// p.Session[LanguageManager.ToString()].ToString();

        DataSet ds = new DataSet();

        ds = p.Cache[CurrentPage] as DataSet ;
       
        if (ds == null)
        {
            ds = ContentResources.GetResourceByCulture(CurrentPage, CurrentCulture);
            p.Cache[CurrentPage] = ds;
        }   

        if (ds.Tables.Count < 0) return;

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            object obj = FindControlRecursive(p, dr[0].ToString().Split('.')[0]);

            if (obj == null) continue;

            if (dr[0] != null)
            {
                if (obj.GetType().Name == "Label")
                {
                    Label ctl = obj as Label;
                    ctl.Text = dr[1].ToString();
                }
                else if (obj.GetType().Name == "LinkButton")
                {
                    LinkButton ctl = obj as LinkButton;
                    ctl.Text = dr[1].ToString();
                }
                else if (obj.GetType().Name == "HtmlTableCell")
                {
                    HtmlTableCell ctl = obj as HtmlTableCell;
                    ctl.InnerHtml = dr[1].ToString();
                }
                else if (obj.GetType().Name == "Literal")
                {
                    Literal ctl = obj as Literal;
                    ctl.Text = dr[1].ToString();
                }
            }
        }
    }

    public static void ApplyNewLanguageAndRefreshPage(Page p, UserControl uc)
    {


        //Refresh the current page to make all control-texts take effect
        //Response.Redirect(Request.Url.AbsoluteUri);
        //return;
        //string CurrentPage = uc.ToString().Replace("ASP.usercontrols_", "").Replace("_", ".");
        Match m = Regex.Match(uc.ToString(), "[a-zA-Z0-9]*_ascx");
        string CurrentPage = "";

        if (m.Success)
            CurrentPage = m.Captures[0].Value.Replace('_', '.');

        string CurrentCulture = p.Session[LanguageManager.ToString()].ToString();
        DataSet ds = new DataSet();
        int v = 0;
        ds = ContentResources.GetResourceByCulture(CurrentPage, CurrentCulture);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            object obj = FindControlRecursive(p, dr[0].ToString().Split('.')[0]);

            if (obj == null) continue;

            if (dr[0] != null)
            {
                if (obj.GetType().Name == "Label")
                {
                    Label ctl = obj as Label;
                    ctl.Text = dr[1].ToString();
                }
                else if (obj.GetType().Name == "LinkButton")
                {
                    LinkButton ctl = obj as LinkButton;
                    ctl.Text = dr[1].ToString();
                }
                else if (obj.GetType().Name == "TableCell")
                {
                    TableCell ctl = obj as TableCell;
                    ctl.Text = dr[1].ToString();
                }
                else if (obj.GetType().Name == "HtmlTableCell")
                {
                    HtmlTableCell ctl = obj as HtmlTableCell;
                    ctl.InnerHtml = dr[1].ToString();
                }
                else if (obj.GetType().Name == "Literal")
                {
                    Literal ctl = obj as Literal;
                    ctl.Text = dr[1].ToString();
                }
                else if (obj.GetType().Name == "CheckBox")
                {
                    CheckBox ctl = obj as CheckBox;
                    ctl.Text = dr[1].ToString();
                }
                else if (obj.GetType().Name == "Image")
                {
                    Image ctl = obj as Image;
                    ctl.ImageUrl = "~/images/" + dr[1].ToString();
                }

            }
        }
    }

    public static Control FindControlRecursive(Control Root, string Id)
    {
        if (Root.ID == Id)
            return Root;

        foreach (Control Ctl in Root.Controls)
        {
            Control FoundCtl = FindControlRecursive(Ctl, Id);
            if (FoundCtl != null)
                return FoundCtl;
        }
        return null;
    }
}