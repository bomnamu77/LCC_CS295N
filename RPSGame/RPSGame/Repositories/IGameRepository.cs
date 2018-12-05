using RPSGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame.Repositories
{
    public interface IGameRepository
    {
        IQueryable<User> Users{ get; }
        List<Game> Games { get; }
        List <Comment> Comments { get; }
        
        void AddUser(User user);
        void AddGame(Game game, User user);
        void AddComment(Comment comment, User user);
        User GetUserByEmail(string email);
    }
}
