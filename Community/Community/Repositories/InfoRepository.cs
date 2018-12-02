using Community.Models;
using Community.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Repositories
{
    public class InfoRepository:IInfoRepository
    {
        private AppDbContext context;

        public IQueryable<Location> Locations { get { return context.Locations; } }
        public IQueryable<People> Peoples { get { return context.Peoples; } }
        public InfoRepository(AppDbContext appDbContext)
        {

            context = appDbContext;
        }
        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
            
        }
        public void AddPeople(People people)
        {
            context.Peoples.Add(people);
            context.SaveChanges();
            
        }
    }
}
