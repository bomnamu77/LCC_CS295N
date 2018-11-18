
using Community.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Repositories
{
    public class MessageRepository:IMessageRepository
    {
        private AppDbContext context;

        public IQueryable<Message> Messages { get { return context.Messages.Include("From").Include("To").Include("Replies"); } }
        public List<User> Users { get { return context.Users.ToList(); } }

        public MessageRepository(AppDbContext appDbContext)
        {
            
            context = appDbContext;
        }
        public void AddMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }
            
        public void AddUser(User user)
        {

            context.Users.Add(user);
            context.SaveChanges();
        }

        public Message GetMessageByID(int msgID)
        {
            Message message = Messages.First(m => m.MessageID == msgID);
            return message;
        }

        public void SetPriority(int msgID, int priority)
        {
            Message message = GetMessageByID(msgID);
            message.Priority = priority;
            context.Messages.Update(message);
            context.SaveChanges();

            
        }
        public void AddReply(int msgID, Message repMsg)
        {

            AddMessage(repMsg);

            Message orgMsg = GetMessageByID(msgID);
            orgMsg.Replies.Add(repMsg);
            context.Messages.Update(orgMsg);
            context.SaveChanges();


        }

    }
}
