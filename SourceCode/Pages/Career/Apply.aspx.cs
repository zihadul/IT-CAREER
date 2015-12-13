using System;
using System.Configuration;
using System.Data;
using BLL;
using System.Net.Mail;

public partial class Pages_Career_Apply : System.Web.UI.Page
{

    // bllCareer objCareer = new bllCareer();



    protected void Page_Load(object sender, EventArgs e)
    {
        //session to select tab on the top


        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                LoadCareer();
            }
        }

    }

    private void LoadCareer()
    {
        //DataTable dt = objCareer.GetByID(Convert.ToInt32(Request.QueryString["id"].ToString()));

        //if (dt.Rows.Count == 0) return;

        //tbxTitle.Text = dt.Rows[0]["title"].ToString();
        //tbxDescription.Text = dt.Rows[0]["description"].ToString();

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Captcha1.ValidateCaptcha(tbxCaptcha.Text);

            if (!Captcha1.UserValidated)
            {

                tbxCaptcha.Text = "";
                return;
            }

            if (fileCV.HasFile)
            {
                string FileName;
                FileName = Server.MapPath("~/Images/Career/" + fileCV.FileName);
                fileCV.SaveAs(FileName);

                Attachment attachmentFile = new Attachment(FileName);

                string Message = "You have got an email from:<br />Name: " + tbxName.Text + "<hr><br />"+"Check Attachment";

                bool Sent = new SendEmail().SendSimpleMail(tbxName.Text, ConfigurationManager.AppSettings["MailReceiver"].ToString(),
                        "Application for \'" + tbxTitle.Text + " post'" + " by " + tbxName.Text, Message, attachmentFile);

                if (Sent)
                    MessageController.Show("Submitted successfully. <br /> You will be here from us very soon. Thanks.", MessageType.Information, Page);

                else
                    MessageController.Show("Could not submit, try again later.", MessageType.Error, Page);


                //File.Delete(FileName);
            }
        }
        catch (Exception ex)
        {
            MessageController.Show(ex.Message, MessageType.Error, Page);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        tbxName.Text = "";

        tbxCaptcha.Text = "";
    }


}
