﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Community.Models;

namespace Community.Controllers
{
    public class InfoController : Controller
    {
        Location location;
        People people;
        public InfoController()
        {
            
            // This is temporary code, just for testing
            if (InfoRepository.Locations.Count == 0)  // only do this if it hasn't been done already
            {
                location = new Location()
                {
                    Name = "Eugene Symphony",
                    Link = "https://eugenesymphony.org/",
                    Description = "Under the leadership of Music Director and Conductor Francesco Lecce-Chong, the Eugene Symphony's mission is enriching lives through the power of music."
                };
                
                InfoRepository.AddLocation(location);
                location = new Location()
                {
                    Name = "Hult Center",
                    Link = "http://www.hultcenter.org/",
                    Description = "Official Home of the Hult Center for the Performing Arts, Eugene, Oregon's most beautiful concert venue for touring shows, concerts, local events and tickets."
                };

                InfoRepository.AddLocation(location);

                location = new Location()
                {
                    Name = "Beacock Music Eugene",
                    Link = "https://www.beacockmusic.com/",
                    Description = "Music Shop"
                };

                InfoRepository.AddLocation(location);
            }
            // This is temporary code, just for testing
            if (InfoRepository.Peoples.Count == 0)  // only do this if it hasn't been done already
            {
                people = new People()
                {
                    Name = "Leonard Bernstein",
                    Link = "https://en.wikipedia.org/wiki/Leonard_Bernstein",
                    Description = "an American composer, conductor, author, music lecturer, and pianist."
                };

                InfoRepository.AddPeople(people);
                people = new People()
                {
                    Name = "Richard Long",
                    Link = "https://www.escorchestra.org/meet-the-conductor/",
                    Description = "Conductor"
                };

                InfoRepository.AddPeople(people);
                people = new People()
                {
                    Name = "B.J. Novitski",
                    Link = "https://www.escorchestra.org/board-of-directors/",
                    Description = "Secretary/Treasurer/Webmaster"
                };

                InfoRepository.AddPeople(people);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        //Show Locations data
        public ViewResult Locations()
        {
            
            List<Location> locations = InfoRepository.Locations;
            locations.Sort((b1, b2) => string.Compare(b1.Name, b2.Name, StringComparison.Ordinal));

            return View(locations);
        }
        //Show People data
        public ViewResult People ()
        {
            ViewData["Message"] = "Significant people and links if available";

            List<People> peoples = InfoRepository.Peoples;
            peoples.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal));

            return View(peoples);
        }
    }
    
}