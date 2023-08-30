using System.Net.Mail;

namespace Vira.Core.Senders
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("viradeveloper.co@gmail.com", "شرکت طراحی سایت ویرا");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("viradeveloper.co@gmail.com", "wvacaevkpsnxpuaq");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}
        