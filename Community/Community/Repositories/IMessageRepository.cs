using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Community.Models;

namespace Community.Repositories
{
    public interface IMessageRepository
    {
        List<Message> Messages { get; }
        List<User> Users { get; }

        void AddMessage(Message message);
        void AddUser(User user);
        Message GetMessageByID(string msgID);
    }
}
