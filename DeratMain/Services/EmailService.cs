using DeratMain.Interfaces.Services;
using DeratMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DeratMain.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(EmailModel emailModel)
        {
            foreach (var client in emailModel.Emails)
            {
                MailAddress from = new MailAddress("deratcontrol@gmail.com", "DeratControl");
                MailAddress to = new MailAddress(client);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "DeratControl";
                m.Body = emailModel.Content;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("deratcontrol@gmail.com", "210499Qq");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
            }
           
        }

        public async Task SendEmailToSupport(EmailSupportModel  emailSupportModel)
        {
            MailAddress from = new MailAddress("voytik.roman21@gmail.com", emailSupportModel.FullName);
            MailAddress to = new MailAddress("deratcontrol@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "DeratControl";
            m.Body = $"Mail from {emailSupportModel.FullName} Id: {emailSupportModel.UserId}, Role: {emailSupportModel.Role}" + " " + emailSupportModel.Content;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("voytik.roman21@gmail.com", "210499Qq");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}
