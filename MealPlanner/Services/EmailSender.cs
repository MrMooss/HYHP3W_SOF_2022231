﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace MealPlanner.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("mealplanner91@gmail.com", "wjdqqmdihrqsguna"),
                EnableSsl = true
            })
            {
                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("mealplanner91@gmail.com"),
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = htmlMessage,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,
                };
                message.To.Add(email);
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                }
            }
            return Task.CompletedTask;
        }
    }
}
