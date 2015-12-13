using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Configuration;
using System.IO;

public partial class UserControls_Portfolio : System.Web.UI.UserControl
{
    public int CandidateID
    {
        set { ViewState["CandidateID"] = value; }
        get { return ViewState["CandidateID"] == null ? 0 : int.Parse(ViewState["CandidateID"].ToString()); }
    }

    public int maxFileUploadSize
    {
        get
        {
            try
            {
                return Convert.ToInt32(ConfigurationSettings.AppSettings["MaxUploadFileSize"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

    bllCandidate objCandidate = new bllCandidate();
    public static DataTable dtTemp;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitializeControl()
    {

        DataTable dtPortfolio = objCandidate.GetPortfolio(CandidateID);
        if (dtPortfolio.Rows.Count == 0)
            dtPortfolio.Rows.Add(dtPortfolio.NewRow());
        gvPortfolio.DataSource = dtPortfolio;
        gvPortfolio.DataBind();

    }

    #region Portfolio

    protected void btnRemovePortfolio_Command(object sender, CommandEventArgs e)
    {
        DataTable dtPortfolio = GetCandidatePortfolio();
        dtPortfolio.Rows.RemoveAt(int.Parse(e.CommandArgument.ToString()));

        gvPortfolio.DataSource = dtPortfolio;
        gvPortfolio.DataBind();

    }

    private DataTable GetCandidatePortfolio()
    {
        DataTable dtPortfolio = objCandidate.GetPortfolio(0);
       // dtTemp = objCandidate.GetPortfolioTemp(CandidateID);
        string errMessage = "";
        string strImageName = "";
        string strImageName1 = "";
        string strImageName2 = "";
        string strImageName3 = "";
        //int i = 0;

        foreach (GridViewRow gvr in gvPortfolio.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {

                TextBox tbxProjectName = gvr.FindControl("tbxProjectName") as TextBox;
                TextBox tbxDuration = gvr.FindControl("tbxDuration") as TextBox;
                TextBox tbxRemarks = gvr.FindControl("tbxRemarks") as TextBox;
                FileUpload filePhoto = gvr.FindControl("filePhoto") as FileUpload;
                FileUpload filePhoto1 = gvr.FindControl("filePhoto1") as FileUpload;
                FileUpload filePhoto2 = gvr.FindControl("filePhoto2") as FileUpload;
                FileUpload filePhoto3 = gvr.FindControl("filePhoto3") as FileUpload;
                #region PhotoUpload
                if (filePhoto.HasFile)
                {
                    strImageName = Guid.NewGuid() + "-" + System.IO.Path.GetFileName(filePhoto.FileName); // We don't need the path, just the name.

                    int fileSize = filePhoto.PostedFile.ContentLength / 1024;
                    string Extention = filePhoto.FileName.Substring(filePhoto.FileName.Length - 3);
                    if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                        errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                    if (fileSize > maxFileUploadSize)
                        errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";

                    if (filePhoto.HasFile)
                    {
                        if (File.Exists(Server.MapPath("~/Images/Career/Portfolio/") + strImageName))
                            File.Delete(Server.MapPath("~/Images/Career/Portfolio/") + strImageName);

                        filePhoto.SaveAs(Server.MapPath("~/Images/Career/Portfolio/") + strImageName);
                    }
                }
                

                if (filePhoto1.HasFile)
                {
                    strImageName1 = Guid.NewGuid() + "-" + System.IO.Path.GetFileName(filePhoto1.FileName); // We don't need the path, just the name.

                    int fileSize = filePhoto1.PostedFile.ContentLength / 1024;
                    string Extention = filePhoto1.FileName.Substring(filePhoto1.FileName.Length - 3);
                    if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                        errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                    if (fileSize > maxFileUploadSize)
                        errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";

                    if (filePhoto1.HasFile)
                    {
                        if (File.Exists(Server.MapPath("~/Images/Career/Portfolio/") + strImageName1))
                            File.Delete(Server.MapPath("~/Images/Career/Portfolio/") + strImageName1);

                        filePhoto1.SaveAs(Server.MapPath("~/Images/Career/Portfolio/") + strImageName1);
                    }
                }
                

                if (filePhoto2.HasFile)
                {
                    strImageName2 = Guid.NewGuid() + "-" + System.IO.Path.GetFileName(filePhoto2.FileName); // We don't need the path, just the name.

                    int fileSize = filePhoto2.PostedFile.ContentLength / 1024;
                    string Extention = filePhoto2.FileName.Substring(filePhoto2.FileName.Length - 3);
                    if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                        errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                    if (fileSize > maxFileUploadSize)
                        errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";

                    if (filePhoto2.HasFile)
                    {
                        if (File.Exists(Server.MapPath("~/Images/Career/Portfolio/") + strImageName2))
                            File.Delete(Server.MapPath("~/Images/Career/Portfolio/") + strImageName2);

                        filePhoto2.SaveAs(Server.MapPath("~/Images/Career/Portfolio/") + strImageName2);
                    }
                }
               

                if (filePhoto3.HasFile)
                {
                    strImageName3 = Guid.NewGuid() + "-" + System.IO.Path.GetFileName(filePhoto3.FileName); // We don't need the path, just the name.

                    int fileSize = filePhoto3.PostedFile.ContentLength / 1024;
                    string Extention = filePhoto3.FileName.Substring(filePhoto3.FileName.Length - 3);
                    if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                        errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                    if (fileSize > maxFileUploadSize)
                        errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";

                    if (filePhoto3.HasFile)
                    {
                        if (File.Exists(Server.MapPath("~/Images/Career/Portfolio/") + strImageName3))
                            File.Delete(Server.MapPath("~/Images/Career/Portfolio/") + strImageName3);

                        filePhoto3.SaveAs(Server.MapPath("~/Images/Career/Portfolio/") + strImageName3);
                    }
                }

                #endregion
                DataRow dr = dtPortfolio.NewRow();
                dr["ProjectName"] = tbxProjectName.Text;
                dr["Remarks"] = tbxRemarks.Text;
                dr["Duration"] = tbxDuration.Text;
                dr["Image"] = strImageName;
                dr["Image1"] = strImageName1;
                dr["Image2"] = strImageName2;
                dr["Image3"] = strImageName3;
                dtPortfolio.Rows.Add(dr);
                //dtTemp = dtPortfolio;
               // i++;

            }
        }

        return dtPortfolio;
    }

    private DataTable GetCandidatePortfolioTemp()
    {
        DataTable dtPortfolio = objCandidate.GetPortfolio(0);
        dtTemp = objCandidate.GetPortfolioTemp(CandidateID);
        string errMessage = "";
        int i=0;

        foreach (GridViewRow gvr in gvPortfolio.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                string strImageName = "";
                string strImageName1 = "";
                string strImageName2 = "";
                string strImageName3 = "";
                TextBox tbxProjectName = gvr.FindControl("tbxProjectName") as TextBox;
                TextBox tbxDuration = gvr.FindControl("tbxDuration") as TextBox;
                TextBox tbxRemarks = gvr.FindControl("tbxRemarks") as TextBox;
                FileUpload filePhoto = gvr.FindControl("filePhoto") as FileUpload;
                FileUpload filePhoto1 = gvr.FindControl("filePhoto1") as FileUpload;
                FileUpload filePhoto2 = gvr.FindControl("filePhoto2") as FileUpload;
                FileUpload filePhoto3 = gvr.FindControl("filePhoto3") as FileUpload;
                #region PhotoUpload
                if (filePhoto.HasFile)
                {
                    strImageName = Guid.NewGuid() + "-" + System.IO.Path.GetFileName(filePhoto.FileName); // We don't need the path, just the name.

                    int fileSize = filePhoto.PostedFile.ContentLength / 1024;
                    string Extention = filePhoto.FileName.Substring(filePhoto.FileName.Length - 3);
                    if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                        errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                    if (fileSize > maxFileUploadSize)
                        errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";

                    if (filePhoto.HasFile)
                    {
                        if (File.Exists(Server.MapPath("~/Images/Career/Portfolio/") + strImageName))
                            File.Delete(Server.MapPath("~/Images/Career/Portfolio/") + strImageName);

                        filePhoto.SaveAs(Server.MapPath("~/Images/Career/Portfolio/") + strImageName);
                    }
                }
                else
                {
                    if(dtTemp.Rows.Count>i)
                        strImageName=dtTemp.Rows[i]["Image"].ToString();
                }

                if (filePhoto1.HasFile)
                {
                    strImageName1 = Guid.NewGuid() + "-" + System.IO.Path.GetFileName(filePhoto1.FileName); // We don't need the path, just the name.

                    int fileSize = filePhoto1.PostedFile.ContentLength / 1024;
                    string Extention = filePhoto1.FileName.Substring(filePhoto1.FileName.Length - 3);
                    if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                        errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                    if (fileSize > maxFileUploadSize)
                        errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";

                    if (filePhoto1.HasFile)
                    {
                        if (File.Exists(Server.MapPath("~/Images/Career/Portfolio/") + strImageName1))
                            File.Delete(Server.MapPath("~/Images/Career/Portfolio/") + strImageName1);

                        filePhoto1.SaveAs(Server.MapPath("~/Images/Career/Portfolio/") + strImageName1);
                    }
                }
                else
                {
                    if (dtTemp.Rows.Count > i)
                        strImageName1 = dtTemp.Rows[i]["Image1"].ToString();
                }

                if (filePhoto2.HasFile)
                {
                    strImageName2 = Guid.NewGuid() + "-" + System.IO.Path.GetFileName(filePhoto2.FileName); // We don't need the path, just the name.

                    int fileSize = filePhoto2.PostedFile.ContentLength / 1024;
                    string Extention = filePhoto2.FileName.Substring(filePhoto2.FileName.Length - 3);
                    if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                        errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                    if (fileSize > maxFileUploadSize)
                        errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";

                    if (filePhoto2.HasFile)
                    {
                        if (File.Exists(Server.MapPath("~/Images/Career/Portfolio/") + strImageName2))
                            File.Delete(Server.MapPath("~/Images/Career/Portfolio/") + strImageName2);

                        filePhoto2.SaveAs(Server.MapPath("~/Images/Career/Portfolio/") + strImageName2);
                    }
                }
                else
                {
                    if (dtTemp.Rows.Count > i)
                        strImageName2 = dtTemp.Rows[i]["Image2"].ToString();
                }

                if (filePhoto3.HasFile)
                {
                    strImageName3 = Guid.NewGuid() + "-" + System.IO.Path.GetFileName(filePhoto3.FileName); // We don't need the path, just the name.

                    int fileSize = filePhoto3.PostedFile.ContentLength / 1024;
                    string Extention = filePhoto3.FileName.Substring(filePhoto3.FileName.Length - 3);
                    if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                        errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                    if (fileSize > maxFileUploadSize)
                        errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";

                    if (filePhoto3.HasFile)
                    {
                        if (File.Exists(Server.MapPath("~/Images/Career/Portfolio/") + strImageName3))
                            File.Delete(Server.MapPath("~/Images/Career/Portfolio/") + strImageName3);

                        filePhoto3.SaveAs(Server.MapPath("~/Images/Career/Portfolio/") + strImageName3);
                    }
                }
                else
                {
                    if (dtTemp.Rows.Count > i)
                        strImageName3 = dtTemp.Rows[i]["Image3"].ToString();
                }
                

                #endregion
                DataRow dr = dtPortfolio.NewRow();
                dr["ProjectName"] = tbxProjectName.Text;
                dr["Remarks"] = tbxRemarks.Text;
                dr["Duration"] = tbxDuration.Text;
                dr["Image"] = strImageName;
                dr["Image1"] = strImageName1;
                dr["Image2"] = strImageName2;
                dr["Image3"] = strImageName3;
                dtPortfolio.Rows.Add(dr);
               
                i++;

            }
        }

        return dtPortfolio;
    }


    protected void btnAddPortfolio_Click(object sender, EventArgs e)
    {
        DataTable dtQualification = GetCandidatePortfolioTemp();
        objCandidate.InsertPortfolioTemp(CandidateID, dtQualification);
        dtQualification.Rows.Add(dtQualification.NewRow());
        gvPortfolio.DataSource = dtQualification;
        gvPortfolio.DataBind();
    }
    #endregion

    public bool SavePortfolio()
    {
        bool succeed = false;
        try
        {

            DataTable dtPortfolio = GetCandidatePortfolioTemp();
            objCandidate.InsertPortfolio(CandidateID, dtPortfolio);
            succeed = true;
            
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);

        }

        return succeed;
    }

   
   
}