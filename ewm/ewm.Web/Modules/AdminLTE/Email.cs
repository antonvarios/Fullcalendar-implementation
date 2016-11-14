using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ewm.Modules.AdminLTE {
    public static class Email {
        public static bool SendEmail(List<string> emails, string msg) {
            foreach (string email in emails) {
                Email.SendEmail(email, msg);
            }
            return true;
        }

        public static bool SendEmail(string email, string msg) {
            try {
                MailAddress to = new MailAddress(email);
                string mailaccount = System.Configuration.ConfigurationManager.AppSettings["mailAccount"];
                string mailPassword = System.Configuration.ConfigurationManager.AppSettings["mailPassword"];
                string smtpHost = System.Configuration.ConfigurationManager.AppSettings["smtpHost"];
                MailAddress from = new MailAddress(mailaccount, "SCHEDULE INFORMATION");
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Yor schedule has been changed";
                mail.Body = msg;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpHost;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(mailaccount, mailPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);
                mail.Dispose();
                return true;
            } catch (System.Exception ex) {
                throw new System.Exception("Mail.Send: " + ex.Message);
            }
        }

    }
}