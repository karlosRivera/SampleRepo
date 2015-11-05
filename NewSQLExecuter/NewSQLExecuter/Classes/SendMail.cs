using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Configuration;

namespace NewSQLExecuter
{
    public class SendMail
    {
        private string from;
        private string to;
        private string cc;
        private string bcc;
        private string subject;
        private string attachment;
        private string body;
        private bool textFormatChecked;
        public static string ID = "";
        public static string Pass = "";

        public string From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        public string To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public string Cc
        {
            get
            {
                return cc;
            }
            set
            {
                cc = value;
            }
        }

        public string Bcc
        {
            get
            {
                return bcc;
            }
            set
            {
                bcc = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public string Attachment
        {
            get
            {
                return attachment;
            }
            set
            {
                attachment = value;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        public bool TextFormatChecked
        {
            get
            {
                return textFormatChecked;
            }
            set
            {
                textFormatChecked = value;
            }
        }


        public SendMail()
        {
            this.From = "";
            this.To = "";
            this.Cc = "";
            this.Bcc = "";
            this.Subject = "";
            this.Attachment = "";

            this.Body = "";
            this.TextFormatChecked = true;
        }


        /// <summary>
        /// This method will be used only if 'Local SMTP Server' is used.
        /// </summary>
        /// 
        public bool Send()
        {
            bool flag = false;
            string strMailID = System.Configuration.ConfigurationManager.AppSettings["MailID"] as string;
            if (strMailID != "")
            {
                this.To = strMailID;
            }
            this.from = "New-SQL-Result@bba-reman.com";
            this.Subject = "New SQL Execution Result For Remote DB";

            if (this.To.Trim() != "")
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(this.from, this.To, this.Subject, this.Body);
                mail.Priority = System.Net.Mail.MailPriority.Normal;
                mail.IsBodyHtml = true;
                try
                {
                    SmtpClient emailClient = new SmtpClient("mail2.orcsweb.com");
                    if (this.Attachment != "")
                    {
                        Attachment data = new Attachment(this.Attachment);
                        mail.Attachments.Add(data);

                    }
                    System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("us-sales@bba-reman.com", "S@bba2014!");
                    emailClient.UseDefaultCredentials = false;
                    emailClient.Credentials = SMTPUserInfo;
                    emailClient.Send(mail);
                    flag = true;
                }
                catch (Exception ex)
                {
                    flag = false;
                }
            }

            return flag;
        }

        /// <summary>
        /// Check valid email id
        /// </summary>
        /// <param name="strMailId"></param>
        /// <returns></returns>
        public bool IsMailId(string strMailId)
        {
            Regex objPattern = new Regex("\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            return objPattern.IsMatch(strMailId);
        }
    }
}
