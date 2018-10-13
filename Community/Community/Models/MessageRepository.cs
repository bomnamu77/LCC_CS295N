
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Models
{
    public class MessageRepository
    {
        private static List<Message> messages = new List<Message>();
        private static List<User> users = new List<User>();

        public static List<Message> Messages { get { return messages; } }
        public static List<User> Users { get { return users; } }

        public static void AddMessage(Message message)
        {
            messages.Add(message);
        }

        public static void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
