using alumnus.Configuration;
using alumnus.Models.Emails;
using alumnus.Services.EmailSender;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace alumnus.Controllers.Api
{
    [Route("api/emails")]
    public class EmailsApiController : Controller
    {
        private readonly IEmailSender _emailService;
        private readonly SendGridEmailSettings _emailSettings;
        private const string EMAIL_SUGGESTION_SUBJECT = "Nueva Sugerencia - Portal de Egresados CUNOC-USAC";
        
        public EmailsApiController(IEmailSender emailService, IOptions<SendGridEmailSettings> emailOptions)
        {
            _emailService = emailService;
            _emailSettings = emailOptions.Value;
        }

        [HttpPost]
        public IActionResult PostSuggestion(Suggestion content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _emailService.SendEmailAsync(email: _emailSettings.SuggestionsDeliverTo,
                subject: EMAIL_SUGGESTION_SUBJECT, message: getMessage(content));
            return new OkResult();
        }

        private static string getMessage(Suggestion content) => $@"<b>Enviado por:</b> {content.FullName}<br/>
            <b>Email del remitente:</b> {content.Email}<br/>
            <b>Mensaje:</b> {content.Message}<br/>";
    }
}