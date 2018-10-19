﻿using System;
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
                    return msg.From.Email == "john@g.com" 
                        && msg.IsReply==false;

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
                    return msg.To.Email == "john@g.com"
                        && msg.IsReply == false;

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
            repmsg.IsReply = true;
            MessageRepository.AddMessage(repmsg);
            orgmsg.Replies.Add(repmsg);

            return RedirectToAction("ListReceivedMessage");

            


        }

        [HttpGet]
        //Input message get
        public ViewResult SetPriority(string msgid)
        {
            return View("SetPriority", HttpUtility.HtmlDecode(msgid));
        }
        [HttpPost]
        public RedirectToActionResult SetPriority(string msgid, int priority)
        {
            Message msg = MessageRepository.GetMessageByID(msgid);

            msg.Priority = priority;

            

            return RedirectToAction("ListReceivedMessage");




        }
    }
}
