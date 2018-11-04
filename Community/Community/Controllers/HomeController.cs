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
            // Messages that the first user (John, john@g.com) sent 
            // will be listed in the "Messages Sent" page  
            List<Message> messages = repo.Messages.FindAll(
                delegate (Message msg)
                {
                    return msg.From.Email == repo.Users[0].Email
                        && msg.IsReply==false;

                });
            messages.Sort((m1, m2) => DateTime.Compare(m1.TimeStamp, m2.TimeStamp));
            SetUserData();
            return View(messages);
        }

        public ViewResult ListReceivedMessage()
        {
            // Messages that the first user (John, john@g.com) received 
            // will be listed in the "Messages Received" page  
            List<Message> messages = repo.Messages.FindAll(
                delegate (Message msg)
                {
                    return msg.To.Email == repo.Users[0].Email
                        && msg.IsReply == false;

                });
            SetUserData();
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
                message.MsgID = Guid.NewGuid().ToString();
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
        public ViewResult ReplyMessage(string msgid)
        {
            SetUserData();
            return View("ReplyMessage", HttpUtility.HtmlDecode(msgid));
        }
        [HttpPost]
        public RedirectToActionResult ReplyMessage(string msgid, string text)
        {
            Message orgmsg = repo.GetMessageByID(msgid);

            //revert orginal "from" to new "to" and viceversa
            Message repmsg = new Message();
            repmsg.To = orgmsg.From;
            repmsg.From= orgmsg.To;

            repmsg.MsgID = Guid.NewGuid().ToString();
            repmsg.TimeStamp = DateTime.Now;
            repmsg.Text = text;
            repmsg.IsReply = true;
            repo.AddMessage(repmsg);
            orgmsg.Replies.Add(repmsg);

            SetUserData();

            return RedirectToAction("ListReceivedMessage");

            


        }

        [HttpGet]
        //Input message get
        public ViewResult SetPriority(string msgid)
        {
            SetUserData();
            return View("SetPriority", HttpUtility.HtmlDecode(msgid));
        }
        [HttpPost]
        public RedirectToActionResult SetPriority(string msgid, int priority, string page)
        {
            Message msg = repo.GetMessageByID(msgid);
            
            msg.Priority = priority;

            SetUserData();

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
