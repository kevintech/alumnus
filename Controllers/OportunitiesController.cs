using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace alumnus.Controllers
{
    public class OportunitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}