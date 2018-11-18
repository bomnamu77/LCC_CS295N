using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Community.Models;

namespace Community.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        List<User> Users { get; }

        void AddMessage(Message message);
        void AddUser(User user);
        Message GetMessageByID(int msgID);
        //Set Priority method
        void SetPriority(int msgID, int priority);
        //Set Add Reply message method
        void AddReply(int msgID, Message message);
    }
}
