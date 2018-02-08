using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using alumnus.Data;
using alumnus.Models.Contacts;
using Microsoft.AspNetCore.Mvc.Rendering;
using alumnus.Services.EmailSender;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace alumnus.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly AlumnusContext _context;
        private readonly IEmailSender _emailService;
        private const string EMAIL_REMINDER_SUBJECT = "Recordatorio: Validez de Datos del Egresado";

        public ContactsController(AlumnusContext context, IEmailSender emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            var listOfContacts = _context.Contacts.ToList();
            return View(listOfContacts);
        }

        public IActionResult New()
        {
            return View("NewRecord");
        }

        public IActionResult Edit(int id)
        {
            var record = _context.Contacts.FirstOrDefault(i => i.Id == id);
            return View(record);
        }

        [HttpGet]
        public IActionResult Reminder(int id)
        {
            var record = _context.Contacts.FirstOrDefault(i => i.Id == id);
            var message = $@"Estimado Ing. {record.FirstName} {record.LastName},
            
Le recordamos que el periodo de validez de los datos personales que
le proporcionó a la Universidad ha expirado. Le solicitamos que se
comunique con nuestro personal para poder actualizar su información
y garantizar un buen uso de la misma.

Saludos cordiales.";
            var model = new InviteViewModel() {
                Emails = new List<string>() {
                    record.Email
                },
                Contacts = GetEmailsList(record.Email),
                Subject = EMAIL_REMINDER_SUBJECT,
                Message = message
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reminder(int id, [FromBody] InviteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var emails = model.Emails.ToList();
                _emailService.SendEmailAsync(emails, model.Subject, model.Message);
                model.Sent = true;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Invite()
        {
            var listOfContacts = GetEmailsList();
            var model = new InviteViewModel() {
                Contacts = listOfContacts
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Invite(InviteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var emails = model.Emails.ToList();
                _emailService.SendEmailAsync(emails, model.Subject, model.Message);
                model.Contacts = GetEmailsList();
                model.Subject = "";
                model.Message = "";
                model.Sent = true;
            }

            return View(model);
        }

        private List<SelectListItem> GetEmailsList(string email) => _context.Contacts
            .Where(i => string.Equals(email, i.Email, StringComparison.CurrentCultureIgnoreCase))
            .Select(i => new SelectListItem()
            {
                Value = i.Email,
                Text = $"{i.FirstName} {i.LastName}"
            })
            .ToList();

        private List<SelectListItem> GetEmailsList() => _context.Contacts
            .Select(i => new SelectListItem()
            {
                Value = i.Email,
                Text = $"{i.FirstName} {i.LastName}"
            })
            .ToList();
    }
}
