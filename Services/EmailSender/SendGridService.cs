using System.Collections.Generic;
using System.Linq;
using alumnus.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace alumnus.Services.EmailSender
{
    public class SendGridService : IEmailSender
    {
        private readonly SendGridEmailSettings _emailSettings;

        public SendGridService(IOptions<SendGridEmailSettings> emailOptions)
        {
            _emailSettings = emailOptions.Value;
        }

        public async void SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var from = new EmailAddress(_emailSettings.FromEmail, _emailSettings.FromName);
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }

        public async void SendEmailAsync(IList<string> emails, string subject, string message)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var from = new EmailAddress(_emailSettings.FromEmail, _emailSettings.FromName);
            var to = emails.Select(i => new EmailAddress(i)).ToList();
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }
    }
}