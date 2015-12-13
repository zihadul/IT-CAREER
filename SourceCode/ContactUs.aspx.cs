using System;
using System.Configuration;

public partial class ContactUs : BasePage
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["activeTab"] = "Contact Us";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Captcha1.ValidateCaptcha(tbxCaptcha.Text);

        if (!Captcha1.UserValidated)
        {
            MessageController.Show("The code you typed does not match the code in the image.", MessageType.Error, Page);
            tbxCaptcha.Text = "";
            return;
        }


       // bool Sent = new SendEmail().SendSimpleMail(tbxEmail.Text, ConfigurationManager.AppSettings["MailReceiver"].ToString(), tbxSubject.Text, message);


        string Message = "You have got an email from:<hr > <br />" + tbxEmail.Text + "<br />" + "<br />" + tbxMessage.Text;
        var emailto = ConfigurationManager.AppSettings["MailReceiver"].ToString();
        bool Sent = new SendEmail().SendSimpleMail("", emailto, tbxSubject.Text, Message);

        if (Sent)
        {
            MessageController.Show(MessageCode._SubmitSucceeded, MessageType.Information, Page);
            tbxMessage.Text = "";
            tbxSubject.Text = "";
            tbxEmail.Text = "";
            tbxCaptcha.Text = "";
        }
        else
        {
           
            MessageController.Show(MessageCode._SubmiFailed, MessageType.Error, Page);
        }

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        tbxMessage.Text = "";
        tbxSubject.Text = "";
        tbxEmail.Text = "";
        
        //tbxCaptcha.Text = "";
    }
    
}
