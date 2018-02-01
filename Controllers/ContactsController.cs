using System.Linq;
using alumnus.Data;
using Microsoft.AspNetCore.Mvc;

namespace alumnus.Controllers
{
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
    }
}
