using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPSGame.Models;
using RPSGame.Repositories;
using RPSGame.Infrastructure;

namespace RPSGame.Controllers
{
    public class GameController : Controller
    {
        

        IGameRepository repo;

        public GameController(IGameRepository r)
        {
            repo = r;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetUser(string path)
        {
            User user;
            if (IsUserExist())
            {
                user = repo.GetUserByEmail(GetUser());

                ViewBag.UserName = user.Name;
                ViewBag.UserEmail = user.Email;

                if (path != "")
                    return RedirectToAction(path, user);
              

            }
            return View();
        }
        [HttpPost]
        public IActionResult SetUser(string path, User user)
        {
            //only when the input values are valid
            if (ModelState.IsValid)
            {
                User userExist = repo.GetUserByEmail(user.Email);
                if (userExist == null)
                {
                
                        repo.AddUser(user);
                        userExist = repo.GetUserByEmail(user.Email);
                
                }
                SaveUser(userExist.Email);
                ViewBag.UserName = user.Name;
                ViewBag.UserEmail = user.Email;

                if (path != "")
                    return RedirectToAction(path, user);
                return View();
            }
            else
                return View();
            
        }
        public IActionResult PlayGame(User user)
        {
            ViewBag.UserName = user.Name;
            ViewBag.UserEmail = user.Email;


            
            return View();
        }
        [HttpPost]
        public IActionResult PlayGame(int selection, User user)
        {
            Random rnd = new Random();
            //1 : Rock, 2: Paper, 3:Scissors
            int compSelection = rnd.Next(1, 3);
            int result = 0;
            if (compSelection == selection)
                result = 0; //draw
            else if ((compSelection == 1 && selection == 2) || (compSelection == 2 && selection == 3) || (compSelection == 3 && selection == 1))
                result = 1; //user wins
            else
                result = 2; //user loses
            User actualUser = repo.GetUserByEmail(user.Email);
            Game game = new Game
            {
                //Gamer = actualUser,
                TimeStamp = DateTime.Now,
                Result = result
            };
            
            repo.AddGame(game, actualUser);

            ViewBag.UserName = actualUser.Name;
            ViewBag.UserEmail = actualUser.Email;

            return View("ViewResult", game);
        }
        public IActionResult MyRecord(User user)
        {
            ViewBag.UserName = user.Name;
            ViewBag.UserEmail = user.Email;

            User actualUser = repo.GetUserByEmail(user.Email);
            List<Game> games = null;
            if (repo.Games!= null)
            {
                games = actualUser.Games.ToList();
            }

            return View(games);
        }

        public IActionResult LeaderBoard(User user)
        {
            ViewBag.UserName = user.Name;
            ViewBag.UserEmail = user.Email;

            List<User> users = repo.Users.OrderByDescending(u => u.Games.Count(g => g.Result == 1)).ToList();
                
                        
            return View(users);
        }
        [HttpPost]
        public IActionResult LeaderBoard(User user, string name)
        {
            ViewBag.UserName = user.Name;
            ViewBag.UserEmail = user.Email;

            
            //Search messages that sender has entered email
            List<User> users = repo.Users.Where(u=>u.Name == name).OrderByDescending(u => u.Games.Count(g => g.Result == 1)).ToList();

            return View(users);
        }
        public IActionResult ViewComment(string to, string commenter)
        {
            User toUser = repo.GetUserByEmail(to);
            ViewBag.ToUser = to;
            ViewBag.FromUser = commenter;


            List<Comment> comments = repo.Comments.Where(c => c.To.Email == to).ToList();
            

            return View(comments);
        }
        public IActionResult AddComment(string to, string commenter)
        {
            ViewBag.ToUser = to;
            ViewBag.FromUser = commenter;

            return View();
        }
        [HttpPost]
        public IActionResult AddComment(string to, string commenter, string commentText, string cheer)
        {
            User toUser = repo.GetUserByEmail(to);
            User fromUser = repo.GetUserByEmail(commenter);
            ViewBag.ToUser = toUser.Email;
            ViewBag.FromUser = fromUser.Email;

            //Get Cheer value
            bool bCheer= false;
            if (cheer == "cheer")
                bCheer = true;

            repo.AddComment(
                new Comment
                { FromName = fromUser.Name,
                    FromEmail = fromUser.Email,
                    TimeStamp = DateTime.Now,
                    Text = commentText,
                    Cheer = bCheer },
                toUser);

            
            

            return RedirectToAction("LeaderBoard", toUser);
        }

        private bool IsUserExist()
        {
            if (HttpContext.Session.GetJson<string>("UserEmail") == null)
                return false;
            else 
                return true; 
        }
        private string GetUser()
        {
            string user = HttpContext.Session.GetJson<string>("UserEmail") ;
            return user;
        }
        private void SaveUser(string user)
        {
            HttpContext.Session.SetJson("UserEmail", user);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.SetJson("UserEmail", null);
            return View("../Home/index");
        }
    }
}