using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Community.Models;

namespace Community.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            ViewData["Message"] = "A brief history of the community";

            return View();
        }

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Contact(Contact contact)
        {
            ViewData["Message"] = "Your contact page.";
            if (ModelState.IsValid)
            {

                return View("ContactInputs", contact);
            }
            else
            {
                // there is a validation error
                return View();
            }

        }
    }
}
