using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Community.Models;
using Microsoft.EntityFrameworkCore;

namespace Community.Repositories
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<People> Peoples{ get; set; }
        public DbSet<Location> Locations{ get; set; }
        
    }
}
