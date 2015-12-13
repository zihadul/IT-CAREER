using System;
using System.Configuration;
using System.Net.Mail;
using System.Threading;


namespace vilt.mailmanager
{
    public class SendEmail
    {
        private string _MailFrom = "";
        private string _EmailAddressTo = "";
        private string _emailSubject = "";
        private string _emailBody = "";
        private string _clientEmail = "";

        public void Send(string MailFrom, string strMailTo, string strSubject, string strBody)
        {

            if (ConfigurationManager.AppSettings.Get("SendEmail") == "false") return;

            _MailFrom = MailFrom;
            _EmailAddressTo = strMailTo;
            _emailSubject = strSubject;
            _emailBody = strBody;
            _clientEmail = "";


            Thread threadNotify = new Thread(new ThreadStart(SendMail));
            threadNotify.Name = Guid.NewGuid().ToString();
            threadNotify.Start();
        }



        private  void SendMail()
        {
            MailMessage objMessage;
            SmtpClient objClient;
            try
            {


                MailAddress From = new MailAddress(_MailFrom, _clientEmail);

                objMessage = new MailMessage(From, new MailAddress(_EmailAddressTo));
                objMessage.IsBodyHtml = true;
                objMessage.Subject = _emailSubject;
                objMessage.Body = _emailBody;
                objMessage.Priority = MailPriority.High;

                objClient = new SmtpClient();
                //objClient.

                objClient.Send(objMessage);
            }
            catch (Exception)
            {
            }
        }


        public void SendMail(string EmailAddressTo, string emailSubject, string emailBody, string clientEmail)
        {
            if (ConfigurationManager.AppSettings.Get("SendEmail") == "false") return;

            _MailFrom = ConfigurationManager.AppSettings.Get("MailSender");
            _EmailAddressTo = EmailAddressTo;
            _emailSubject = emailSubject;
            _emailBody = emailBody;
            _clientEmail = clientEmail;

            Thread threadNotify = new Thread(new ThreadStart(SendMail));
            threadNotify.Name = Guid.NewGuid().ToString();
            threadNotify.Start();
        }
    }
}

