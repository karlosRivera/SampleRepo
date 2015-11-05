#region all using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.ComponentModel;
#endregion

namespace PartIndexerService
{
    #region MailTemplate
    /// <summary>
    /// this class will hold mail related info
    /// </summary>
    public class MailTemplate
    {
        #region all local variable
        string _mailBody = "";
        string _subject = "";
        string _From = "";
        string _To = "";
        bool _status = false;
        string _ErrorMessage = "";
        List<string> oAttachment = null;
        #endregion

        #region ctor
        public MailTemplate()
        {
            oAttachment = new List<string>();
        }
        #endregion

        #region all properties
        public string Body
        {
            get { return _mailBody; }
            set { _mailBody = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string MailFrom
        {
            get { return _From; }
            set { _From = value; }
        }

        public string MailTo
        {
            get { return _To; }
            set { _To = value; }
        }

        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }

        public List<string> Attachment
        {
            get { return oAttachment; }
            //set { _ErrorMessage = value; }
        }
        #endregion
    }
    #endregion

    #region MailTemplateBuilder
    /// <summary>
    /// this class will help user with fluent style access to mail related info
    /// </summary>
    public static class MailTemplateBuilder
    {
        #region All fluent style methods
        /// <summary>
        /// all fluent style method help user to assign and set mail related data before mail sending
        /// </summary>
        public static MailTemplate WithBody(this MailTemplate item, string body)
        {
            item.Body = body;
            return item;
        }

        public static MailTemplate WithSubject(this MailTemplate item, string subject)
        {
            item.Subject = subject;
            return item;
        }

        public static MailTemplate WithSender(this MailTemplate item, string sender)
        {
            item.MailFrom = sender;
            return item;
        }

        public static MailTemplate WithRecepient(this MailTemplate item, string recepient)
        {
            item.MailTo = recepient;
            return item;
        }

        public static MailTemplate WithAttachment(this MailTemplate item, string filepath)
        {
            item.Attachment.Add(filepath);
            return item;
        }
        #endregion

        #region Send
        /// <summary>
        /// this routine will send mail
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static MailTemplate Send(this MailTemplate item)
        {
            MailMessage mail = new MailMessage(item.MailFrom, item.MailTo, item.Subject, item.Body);
            mail.Priority = System.Net.Mail.MailPriority.Normal;
            mail.IsBodyHtml = true;

            if (item.Attachment.Count > 0)
            {
                foreach (string Attachment in item.Attachment)
                {
                    if (File.Exists(Attachment))
                    {
                        Attachment oAttachment = new Attachment(Attachment);
                        mail.Attachments.Add(oAttachment);
                    }
                }
            }

            try
            {
                SmtpClient emailClient = new SmtpClient("mail2.orcsweb.com");
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("bbasupport@bba-reman.com", "supportBBA1");
                emailClient.UseDefaultCredentials = false;
                emailClient.Credentials = SMTPUserInfo;
                emailClient.Send(mail);

                item.Status = true;
                item.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                item.Status = false;
                item.ErrorMessage = ex.Message;
            }

            return item;
        }
        #endregion
    }
    #endregion

}
