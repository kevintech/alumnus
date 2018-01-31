namespace alumnus.Services.EmailSender
{
    public interface IEmailSender
    {
        void SendEmailAsync(string email, string subject, string message);
    }
}