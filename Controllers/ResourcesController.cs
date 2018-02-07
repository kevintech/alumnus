using System.Linq;
using Microsoft.AspNetCore.Mvc;
using alumnus.Data;
using Microsoft.AspNetCore.Authorization;

namespace alumnus.Controllers
{
    [Authorize]
    public class ResourcesController : Controller
    {
        private readonly AlumnusContext _context;

        public ResourcesController(AlumnusContext context)
        {
            _context = context;
        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            var listOfResources = _context.Resources.ToList();
            return View(listOfResources);
        }

        public IActionResult New()
        {
            return View("NewRecord");
        }

        public IActionResult Edit(int id)
        {
            var record = _context.Resources.FirstOrDefault(i => i.Id == id);
            return View("Edit", record);
        }
    }
}
