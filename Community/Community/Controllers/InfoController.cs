using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Community.Models;
using Community.Repositories;

namespace Community.Controllers
{
    public class InfoController : Controller
    {
        

        IInfoRepository repo;

        public InfoController(IInfoRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Show Locations data
        public ViewResult Locations()
        {

            List<Location> locations = repo.Locations.OrderBy(l=>l.Name).ToList() ;
            //locations.Sort((b1, b2) => string.Compare(b1.Name, b2.Name, StringComparison.Ordinal));

            return View(locations);
        }
        [HttpPost]
        public ViewResult Locations(string location)
        {
           
            
            List<Location> locations = (from l in repo.Locations
                                      where l.Name== location 
                                      select l).ToList();
            return View(locations);
        }
        //Show People data
        public ViewResult People ()
        {
            ViewData["Message"] = "Significant people and links if available";

            List<People> peoples = repo.Peoples.OrderBy(p=>p.Name).ToList();
            //peoples.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal));

            return View(peoples);
        }
    }
    
}