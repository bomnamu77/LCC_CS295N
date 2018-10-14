using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Community.Models;
using System.Web;

namespace Community.Controllers
{
    public class HomeController : Controller
    {
        Message message;
        User user;
        public HomeController()
        {
            message = new Message();

            //Add dummy users
            if (MessageRepository.Users.Count == 0)  // only do this if it hasn't been done already
            {
                user = new User()
                {
                    Name = "John",
                    Email = "john@g.com"
                };

                MessageRepository.AddUser(user);

                user = new User()
                {
                    Name = "Mary",
                    Email = "mary@g.com"
                };

                MessageRepository.AddUser(user);
                user = new User()
                {
                    Name = "Bob",
                    Email = "bob@g.com"
                };

                MessageRepository.AddUser(user);

                
            }
            //Add dummy messages
            if (MessageRepository.Messages.Count == 0)  // only do this if it hasn't been done already
            {
                message = new Message()
                {
                    To = MessageRepository.Users[0],
                    From = MessageRepository.Users[1],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Hello"
                };

                MessageRepository.AddMessage(message);

                message = new Message()
                {
                    To = MessageRepository.Users[0],
                    From = MessageRepository.Users[2],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Do you have this music?"
                };

                MessageRepository.AddMessage(message);

                message = new Message()
                {
                    To = MessageRepository.Users[0],
                    From = MessageRepository.Users[2],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "When is the rehearsal?"
                };

                MessageRepository.AddMessage(message);

                message = new Message()
                {
                    To = MessageRepository.Users[0],
                    From = MessageRepository.Users[1],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Next week's assignment!"
                };

                MessageRepository.AddMessage(message);
                message = new Message()
                {
                    To = MessageRepository.Users[2],
                    From = MessageRepository.Users[0],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Did you get this?"
                };

                MessageRepository.AddMessage(message);

             
                message = new Message()
                {
                    To = MessageRepository.Users[1],
                    From = MessageRepository.Users[0],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Due is this Monday!!"
                };

                MessageRepository.AddMessage(message);
            }
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
            User user = MessageRepository.Users[0];
            return View("Contact",  HttpUtility.HtmlDecode(user.Name));
        }

        public ViewResult ListSentMessage()
        {
            // Messages that the first user (John, john@g.com) sent 
            // will be listed in the "Messages Sent" page  
            List<Message> messages = MessageRepository.Messages.FindAll(
                delegate (Message msg)
                {
                    return msg.From.Name == "John" 
                        && msg.From.Email == "john@g.com";

                });
            messages.Sort((m1, m2) => DateTime.Compare(m1.TimeStamp, m2.TimeStamp));

            return View(messages);
        }

        public ViewResult ListReceivedMessage()
        {
            // Messages that the first user (John, john@g.com) received 
            // will be listed in the "Messages Received" page  
            List<Message> messages = MessageRepository.Messages.FindAll(
                delegate (Message msg)
                {
                    return msg.To.Name == "John"
                        && msg.To.Email == "john@g.com";

                });

            return View(messages);
        }
        [HttpGet]
        //Input message get
        public ViewResult InputMessage()
        {
            return View();
        }
        [HttpPost]
        public ViewResult InputMessage(Message message)
        {
            
            if (ModelState.IsValid)
            {
                message.MsgID = Guid.NewGuid().ToString();
                message.TimeStamp = DateTime.Now;
                MessageRepository.AddMessage(message);

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
            return View("ReplyMessage", HttpUtility.HtmlDecode(msgid));
        }
        [HttpPost]
        public RedirectToActionResult ReplyMessage(string msgid, string text)
        {
            Message orgmsg = MessageRepository.GetMessageByID(msgid);

            Message repmsg = new Message();
            repmsg.To = orgmsg.From;
            repmsg.From= orgmsg.To;

            repmsg.MsgID = Guid.NewGuid().ToString();
            repmsg.TimeStamp = DateTime.Now;
            repmsg.Text = text;
            MessageRepository.AddMessage(repmsg);
            orgmsg.Replies.Add(repmsg);

            return RedirectToAction("ListReceivedMessage");

            


        }
    }
}
