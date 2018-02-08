using System.Collections.Generic;

namespace alumnus.Services.EmailSender
{
    public interface IEmailSender
    {
        void SendEmailAsync(string email, string subject, string message);
        void SendEmailAsync(IList<string> emails, string subject, string message);
    }
}