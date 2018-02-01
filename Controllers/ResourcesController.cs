using System.Linq;
using Microsoft.AspNetCore.Mvc;
using alumnus.Data;

namespace alumnus.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly AlumnusContext _context;

        public ResourcesController(AlumnusContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var listOfResources = _context.Resources.ToList();
            return View(listOfResources);
        }

        public IActionResult New()
        {
            return View("NewRecord");
        }
    }
}
