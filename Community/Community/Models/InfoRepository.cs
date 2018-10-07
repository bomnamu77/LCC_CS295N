using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Models
{
    public class InfoRepository
    {
        private static List<Location> locations = new List<Location>();
        private static List<People> peoples = new List<People>();

        public static List<Location> Locations { get { return locations; } }
        public static List<People> Peoples { get { return peoples; } }
        public static void AddLocation(Location location)
        {
            locations.Add(location);
        }
        public static void AddPeople(People people)
        {
            peoples.Add(people);
        }
    }
}
