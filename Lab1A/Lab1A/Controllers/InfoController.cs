using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab1A.Models;

namespace Lab1A.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Locations()
        {
            ViewData["Message"] = "Important locations and links";

            return View();
        }

        public ViewResult People ()
        {
            ViewData["Message"] = "Significant people and links if available";

            return View();
        }
    }
    
}