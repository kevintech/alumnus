using alumnus.Models.Emails;
using alumnus.Services.EmailSender;
using Microsoft.AspNetCore.Mvc;

namespace alumnus.Controllers.Api
{
    [Route("api/emails")]
    public class EmailsApiController : Controller
    {
        private readonly IEmailSender _emailService;
        private const string EMAIL_SUGGESTION_SUBJECT = "Nueva Sugerencia - Portal de Egresados CUNOC-USAC";
        
        public EmailsApiController(IEmailSender emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult PostSuggestion(Suggestion content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _emailService.SendEmailAsync(email: "kevinfertech@gmail.com",
                subject: EMAIL_SUGGESTION_SUBJECT, message: getMessage(content));
            return new OkResult();
        }

        private static string getMessage(Suggestion content) => $@"<b>Enviado por:</b> {content.FullName}<br/>
            <b>Email del remitente:</b> {content.Email}<br/>
            <b>Mensaje:</b> {content.Message}<br/>";
    }
}