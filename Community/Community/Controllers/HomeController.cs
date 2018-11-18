using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Community.Models;
using System.Web;
using Community.Repositories;

namespace Community.Controllers
{
    public class HomeController : Controller
    {

        IMessageRepository repo;
            
        public HomeController(IMessageRepository r)
        {
            repo = r;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            ViewData["Message"] = "A brief history of the community";

            return View();
        }
        public ViewResult Contact()
        {
            // First user (John, john@g.com) will be a current user
            SetUserData();

            return View();
        }

        public ViewResult ListSentMessage()
        {
            SetUserData();
            // Messages that the first user (John, john@g.com) sent 
            // will be listed in the "Messages Sent" page  
            string userEmail = ViewBag.UserEmail;
            List<Message> messages = repo.Messages.Where(p => p.From.Email == userEmail)
                .Where(p => p.IsReply == false).ToList();/*
                delegate (Message msg)
                {
                    return msg.From.Email == ViewBag.UserEmail
                        && msg.IsReply==false;

                });*/
            messages.Sort((m1, m2) => DateTime.Compare(m1.TimeStamp, m2.TimeStamp));
            
            return View(messages);
        }

        public ViewResult ListReceivedMessage()
        {
            // Messages that the first user (John, john@g.com) received 
            // will be listed in the "Messages Received" page  
            SetUserData();
            string userEmail = ViewBag.UserEmail;
            List<Message> messages = repo.Messages.Where(p => p.To.Email == userEmail)
                .Where(p => p.IsReply == false).ToList();

            return View(messages);
        }
        [HttpGet]
        //Input message get
        public ViewResult InputMessage()
        {
            SetUserData();
            return View();
        }
        [HttpPost]
        public ViewResult InputMessage(Message message)
        {
            SetUserData();
            if (ModelState.IsValid)
            {
                message.TimeStamp = DateTime.Now;
                
                repo.AddMessage(message);

                return View("ViewMessage",message);
                
            }
            else
            {
                // there is a validation error
                return View();
            }


        }

        [HttpGet]
        //Input message get
        public ViewResult ReplyMessage(int msgid)
        {
            SetUserData();
            return View("ReplyMessage", msgid);
            
        }
        [HttpPost]
        public RedirectToActionResult ReplyMessage(int msgid, string text)
        {
            Message orgmsg = repo.GetMessageByID(msgid);

            //revert orginal "from" to new "to" and viceversa
            Message repmsg = new Message();
            repmsg.To = orgmsg.From;
            repmsg.From= orgmsg.To;
           
            repmsg.TimeStamp = DateTime.Now;
            repmsg.Text = text;
            repmsg.IsReply = true;
           
            repo.AddReply(msgid, repmsg);
            

            SetUserData();

            return RedirectToAction("ListReceivedMessage");

            


        }

        [HttpGet]
        //Input message get
        public ViewResult SetPriority(int msgid)
        {
            SetUserData();
            return View("SetPriority", msgid);

            //return View("SetPriority", HttpUtility.HtmlDecode(msgid));
        }
        [HttpPost]
        public RedirectToActionResult SetPriority(int msgid, int priority, string page)
        {
            SetUserData();
            Message msg = repo.GetMessageByID(msgid);

            //priority: 1-Low, 2-Medium, 3- high
            msg.Priority = priority;

            repo.SetPriority(msgid, priority);

            if (page=="sent")
                return RedirectToAction("ListSentMessage");
            else 
                return RedirectToAction("ListReceivedMessage");




        }
        //Set user info to ViewData
        private void SetUserData()
        {
            User user = repo.Users[0];
            ViewBag.UserName = user.Name;
            ViewBag.UserEmail = user.Email;
        }
    }
}
