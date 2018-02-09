namespace alumnus.Configuration
{
    public class SendGridEmailSettings
    {
        public string ApiKey { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string SuggestionsDeliverTo { get; set; }
    }
}