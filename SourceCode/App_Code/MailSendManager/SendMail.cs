using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using System.Web.Security;
using System.Web;

    /// <summary>
    /// Summary description for MailSend
    /// </summary>
    public class SendEmail
    {
        public SendEmail()
        {

        }

        public bool SendSimpleMail(string EmailFrom, string EmailTo, string emailSubject, string emailBody
            , Attachment attahcedfile)
        {


            MailMessage objMessage;
            SmtpClient objClient;
            string toEmail;
            try
            {
               
                MailAddress From;

                if (EmailFrom == "")
                    From = new MailAddress(ConfigurationManager.AppSettings.Get("MailSender"), ConfigurationManager.AppSettings.Get("MailSenderName"));
                else
                    From = new MailAddress(ConfigurationManager.AppSettings.Get("MailSender"), ConfigurationManager.AppSettings.Get("MailSenderName"));

                MailAddressCollection ccAddress = new MailAddressCollection();
                if (EmailTo.Contains(";"))
                {

                    string[] tos = EmailTo.Split(';');
                    if (tos.Length > 1)
                    {
                        for (int i = 1; i < tos.Length; i++)
                        {
                            ccAddress.Add(new MailAddress(tos[i].ToString()));
                        }
                    }
                    toEmail = tos[0];
                }
                else
                {
                    toEmail = EmailTo;
                }
                MailAddress To = new MailAddress(toEmail);
                objMessage = new MailMessage(From, To);

                if (ccAddress.Count > 0)
                {
                    foreach (MailAddress cc in ccAddress)
                    {
                        objMessage.CC.Add(cc);
                    }
                }

                objMessage.IsBodyHtml = true;
                objMessage.Subject = emailSubject;

                objMessage.Body = emailBody;
                objMessage.Priority = MailPriority.Normal;

                objMessage.Attachments.Add(attahcedfile);
                objClient = new SmtpClient();
                objClient.Send(objMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SendSimpleMail(string EmailFrom, string EmailTo, string emailSubject, string emailBody)
        {
            MailMessage objMessage;
            SmtpClient objClient;
            string toEmail;
            try
            {

                MailAddress From;

                if (EmailFrom == "")
                    From = new MailAddress(ConfigurationManager.AppSettings.Get("MailSender"), ConfigurationManager.AppSettings.Get("MailSenderName"));
                else
                    From = new MailAddress(ConfigurationManager.AppSettings.Get("MailSender"), ConfigurationManager.AppSettings.Get("MailSenderName"));


                MailAddressCollection ccAddress = new MailAddressCollection();
                if (EmailTo.Contains(";"))
                {

                    string[] tos = EmailTo.Split(';');
                    if (tos.Length > 1)
                    {
                        for (int i = 1; i < tos.Length; i++)
                        {
                            ccAddress.Add(new MailAddress(tos[i].ToString()));
                        }
                    }
                    toEmail = tos[0];
                }
                else
                {
                    toEmail = EmailTo;
                }
                MailAddress To = new MailAddress(toEmail);
                objMessage = new MailMessage(From, To);

                if (ccAddress.Count > 0)
                {
                    foreach (MailAddress cc in ccAddress)
                    {
                        objMessage.CC.Add(cc);
                    }
                }

                objMessage.IsBodyHtml = true;
                objMessage.Subject = emailSubject;

                objMessage.Body = emailBody;
                objMessage.Priority = MailPriority.Normal;
                
                objClient = new SmtpClient();
                objClient.Send(objMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
