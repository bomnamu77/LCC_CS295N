
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

        static MessageRepository()
        {
            AddTestData();
        }
        public static void AddMessage(Message message)
        {
            messages.Add(message);
        }

        public static void AddUser(User user)
        {
            users.Add(user);
        }

        public static Message GetMessageByID(string msgID)
        {
            Message message = messages.Find(m => m.MsgID == msgID);
            return message;
        }


        static void AddTestData()
        {
            Message message;
            User user;

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
                    Text = "Hello",
                    IsReply = false
                };

                MessageRepository.AddMessage(message);

                message = new Message()
                {
                    To = MessageRepository.Users[0],
                    From = MessageRepository.Users[2],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Do you have this music?",
                    IsReply = false
                };

                MessageRepository.AddMessage(message);

                message = new Message()
                {
                    To = MessageRepository.Users[0],
                    From = MessageRepository.Users[2],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "When is the rehearsal?",
                    IsReply = false
                };

                MessageRepository.AddMessage(message);

                message = new Message()
                {
                    To = MessageRepository.Users[0],
                    From = MessageRepository.Users[1],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Next week's assignment!",
                    IsReply = false
                };

                MessageRepository.AddMessage(message);
                message = new Message()
                {
                    To = MessageRepository.Users[2],
                    From = MessageRepository.Users[0],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Did you get this?",
                    IsReply = false
                };

                MessageRepository.AddMessage(message);


                message = new Message()
                {
                    To = MessageRepository.Users[1],
                    From = MessageRepository.Users[0],
                    MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Due is this Monday!!",
                    IsReply = false
                };

                MessageRepository.AddMessage(message);
            }
        }
    }
}
