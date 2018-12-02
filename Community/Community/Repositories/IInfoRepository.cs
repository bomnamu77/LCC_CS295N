using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Repositories
{
    public interface IInfoRepository
    {

        IQueryable<Location> Locations { get; }
        IQueryable<People> Peoples { get; }

        void AddLocation(Location location);
        void AddPeople(People people);
    }
}
