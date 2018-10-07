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
        Contact contact;
        public HomeController()
        {
            contact = new Contact();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            ViewData["Message"] = "A brief history of the community";

            return View();
        }
        public ViewResult Contact()
        {
            List<Contact> contacts = ContactRepository.Contacts;
            return View(contacts);
        }
        [HttpGet]
        public ViewResult ContactInputs()
        {
            return View();
        }
        [HttpPost]
        public ViewResult ContactInputs(Contact contact)
        {
            
            if (ModelState.IsValid)
            {
                contact.TimeStamp = DateTime.Now;
                ContactRepository.AddContact(contact);
                  
                return View("Contact", ContactRepository.Contacts);
                
            }
            else
            {
                // there is a validation error
                return View();
            }


        }
    }
}
