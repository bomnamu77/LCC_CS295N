using Microsoft.EntityFrameworkCore;
using RPSGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame.Repositories
{
    public class GameRepository:IGameRepository
    {
        
        private AppDbContext context;

        public IQueryable<User> Users { get { return context.Users.Include("Games").Include("Comments"); } }
        public List<Game> Games { get { return context.Games.ToList(); } }
        public List<Comment> Comments { get { return context.Comments.Include("To").ToList(); } }
        
        public GameRepository(AppDbContext appDbContext)
        {

            context = appDbContext;
        }
        public  void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            User user = Users.SingleOrDefault(m => m.Email == email);
            return user;
        }

        public  void AddGame(Game game, User user)
        {
            //User user = GetUserByEmail(email);
            
            user.Games.Add(game);
            context.Users.Update(user);
            context.SaveChanges();
        }

        public  void AddComment(Comment comment, User user)
        {
            //User user = GetUserByEmail(email);
            user.Comments.Add(comment);
            context.Users.Update(user);
            context.SaveChanges();
        }

        
    }
}
