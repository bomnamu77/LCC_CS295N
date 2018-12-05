using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPSGame.Models;

namespace RPSGame.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users{ get; set; }
        public DbSet<Game> Games{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        
    }
}
