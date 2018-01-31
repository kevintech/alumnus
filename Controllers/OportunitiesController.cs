using Microsoft.AspNetCore.Mvc;
using alumnus.Data;
using alumnus.Models.Oportunities;
using System.Linq;

namespace alumnus.Controllers
{
    public class OportunitiesController : Controller
    {
        private readonly AlumnusContext _context;

        public OportunitiesController(AlumnusContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var listOfOportunities = _context.Oportunities.ToList();
            return View(listOfOportunities);
        }

        public IActionResult New()
        {
            return View("NewRecord");
        }
    }
}
