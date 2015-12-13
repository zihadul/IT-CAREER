using System;
using System.Configuration;
using System.IO;

public partial class UserControls_CarrerPhotograph : System.Web.UI.UserControl
{


    public int CandidateID
    {
        set { ViewState["CandidateID"] = value; }
        get { return ViewState["CandidateID"] == null ? 0 : int.Parse(ViewState["CandidateID"].ToString()); }
    }

    public bool ErrorOccurred
    {
        set { ViewState["ErrorOccurred"] = value; }
        get { return ViewState["ErrorOccurred"] == null ? false : bool.Parse(ViewState["ErrorOccurred"].ToString()); }
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


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitializeControl()
    {
        if (CandidateID > 0)
        {
            if (File.Exists(Server.MapPath("~/Images/Career/Photo/" + CandidateID.ToString() + ".jpg")))
            {
                imgPhoto.Visible = true;
                imgPhoto.ImageUrl = "~/Images/Career/Photo/" + CandidateID.ToString() + ".jpg";
            }
        }

    }

    private bool CheckUploadFileSize()
    {
        int fileSize = filePhoto.PostedFile.ContentLength / 1024;
        if (fileSize > maxFileUploadSize) return false;
        else return true;
    }

    public bool SavePhotograph()
    {
        bool succeed = false;

        try
        {
            string errMessage = "";

            if (filePhoto.HasFile)
            {
                string Extention = filePhoto.FileName.Substring(filePhoto.FileName.Length - 3);
                if (Extention.ToLower() != "jpg" && Extention.ToLower() != "jpeg" && Extention.ToLower() != "bmp" && Extention.ToLower() != "png" && Extention.ToLower() != "gif")
                    errMessage += "<li>Invalid applicant photo format. Allowed formats are: jpg, jpeg, bmp, png and gif.</li>";
                if (!CheckUploadFileSize())
                    errMessage += "<li>Uploaded applicant photo size is greater than " + maxFileUploadSize.ToString() + "KB. Compress the file and try again.</li>";
            }

            if (errMessage != "")
            {
                ErrorOccurred = true;
                MessageController.Show(errMessage, MessageType.Error, Page);
                return false;
            }

            ErrorOccurred = false;

            if (filePhoto.HasFile)
            {
                if (File.Exists(Server.MapPath("~/Images/Career/Photo/") + CandidateID.ToString() + ".jpg"))
                    File.Delete(Server.MapPath("~/Images/Career/Photo/") + CandidateID.ToString() + ".jpg");

                filePhoto.SaveAs(Server.MapPath("~/Images/Career/Photo/") + CandidateID.ToString() + ".jpg");
            }

            succeed = true;
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);

        }

        return succeed;
    }
   

    
}