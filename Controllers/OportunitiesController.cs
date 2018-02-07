using Microsoft.AspNetCore.Mvc;
using alumnus.Data;
using alumnus.Models.Oportunities;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace alumnus.Controllers
{
    [Authorize]
    public class OportunitiesController : Controller
    {
        private readonly AlumnusContext _context;

        public OportunitiesController(AlumnusContext context)
        {
            _context = context;
        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            var listOfOportunities = _context.Oportunities.ToList();
            return View(listOfOportunities);
        }

        public IActionResult New()
        {
            return View("NewRecord");
        }

        public IActionResult Edit(int id)
        {
            var record = _context.Oportunities.FirstOrDefault(i => i.Id == id);
            return View("Edit", record);
        }
    }
}
