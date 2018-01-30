using Microsoft.Extensions.Options;
using alumnus.Configuration;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;

namespace alumnus.Services.EmailSender
{
    public class EmailSenderService
    {
        private readonly EmailSettings _emailSettings;

        public EmailSenderService(IOptions<EmailSettings> emailOptions)
        {
            _emailSettings = emailOptions.Value;
        }

        public async void SendEmailAsync(string email, string subject, string message)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(_emailSettings.ApiBaseUri) })
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(_emailSettings.ApiKey)));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("from", _emailSettings.From),
                    new KeyValuePair<string, string>("to", email),
                    new KeyValuePair<string, string>("subject", subject),
                    new KeyValuePair<string, string>("html", message)
                });
                await client.PostAsync(_emailSettings.RequestUri, content).ConfigureAwait(false);
            }
        }
    }
}