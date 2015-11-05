using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartIndexerService
{
    class Utility
    {
        #region MailNotify
        /// <summary>
        /// MailNotify
        /// fire mail when apps start & exit
        /// </summary>
        /// <param name="strStatus"></param>
        public static void MailNotify(string strStatus, string strError = "")
        {
            if (strStatus == "STARTED")
            {
                var template = new MailTemplate()
                    .WithBody("HI,<br/><br/>Part Indexer Started Date" + DateTime.Now.ToLongDateString())
                    .WithSubject("New Part Indexer Started")
                    .WithSender("bbasupport@bba-reman.com")
                    .WithRecepient("tridip@bba-reman.com")
                    .Send();
            }
            else if (strStatus == "STOPPED")
            {
                var template = new MailTemplate()
                    .WithBody("HI,<br/><br/>Part Indexer stopped Date" + DateTime.Now.ToLongDateString())
                    .WithSubject("New Part Indexer Stopped")
                    .WithSender("bbasupport@bba-reman.com")
                    .WithRecepient("tridip@bba-reman.com")
                    .Send();
            }
            else if (strStatus == "TRIGGER")
            {
                var template = new MailTemplate()
                    .WithBody("HI,<br/><br/>Part Indexer Trigger " + DateTime.Now.ToLongDateString())
                    .WithSubject("New Part Indexer Trigger from windown service")
                    .WithSender("bbasupport@bba-reman.com")
                    .WithRecepient("tridip@bba-reman.com")
                    .Send();
            }
            else if (strStatus == "TRIGGER_ERROR")
            {
                var template = new MailTemplate()
                    .WithBody("HI,<br/><br/>Part Indexer Trigger Error date time" + DateTime.Now.ToLongDateString() + "<br/> Error Detail " + strError)
                    .WithSubject("New Part Indexer Trigger Error")
                    .WithSender("bbasupport@bba-reman.com")
                    .WithRecepient("tridip@bba-reman.com")
                    .Send();
            }

        }
        #endregion
    }
}
