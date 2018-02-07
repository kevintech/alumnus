using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using alumnus.Data;

namespace alumnus.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly AlumnusContext _context;

        public ContactsController(AlumnusContext context)
        {
            _context = context;
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
            return View("Edit", record);
        }
    }
}
