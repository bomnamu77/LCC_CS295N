
using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Repositories
{
    public class MessageRepository:IMessageRepository
    {
        private List<Message> messages = new List<Message>();
        private List<User> users = new List<User>();

        public List<Message> Messages { get { return messages; } }
        public List<User> Users { get { return users; } }

        public MessageRepository()
        {
            AddTestData();
        }
        public void AddMessage(Message message)
        {
            messages.Add(message);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public Message GetMessageByID(string msgID)
        {
            Message message = messages.Find(m => m.MsgID == msgID);
            return message;
        }


        void AddTestData()
        {
            Message message;
            User user;

            message = new Message();

            //Add dummy users
            if (Users.Count == 0)  // only do this if it hasn't been done already
            {
                user = new User()
                {
                    Name = "John",
                    Email = "john@g.com"
                };

                AddUser(user);

                user = new User()
                {
                    Name = "Mary",
                    Email = "mary@g.com"
                };

                AddUser(user);
                user = new User()
                {
                    Name = "Bob",
                    Email = "bob@g.com"
                };

                AddUser(user);


            }
            //Add dummy messages
            if (Messages.Count == 0)  // only do this if it hasn't been done already
            {
                message = new Message()
                {
                    To = Users[0],
                    From = Users[1],
                    //MsgID = Guid.NewGuid().ToString(),
                    MsgID = (Messages.Count + 1).ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Hello",
                    IsReply = false
                };

                AddMessage(message);

                message = new Message()
                {
                    To = Users[0],
                    From = Users[2],
                    //MsgID = Guid.NewGuid().ToString(),
                    MsgID = (Messages.Count + 1).ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Do you have this music?",
                    IsReply = false
                };

                AddMessage(message);

                message = new Message()
                {
                    To = Users[0],
                    From = Users[2],
                    //MsgID = Guid.NewGuid().ToString(),
                    MsgID = (Messages.Count + 1).ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "When is the rehearsal?",
                    IsReply = false
                };

                AddMessage(message);

                message = new Message()
                {
                    To = Users[0],
                    From = Users[1],
                    //MsgID = Guid.NewGuid().ToString(),
                    MsgID = (Messages.Count + 1).ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Next week's assignment!",
                    IsReply = false
                };

                AddMessage(message);
                message = new Message()
                {
                    To = Users[2],
                    From = Users[0],
                    //MsgID = Guid.NewGuid().ToString(),
                    MsgID = (Messages.Count + 1).ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Did you get this?",
                    IsReply = false
                };

                AddMessage(message);


                message = new Message()
                {
                    To = Users[1],
                    From = Users[0],
                    //MsgID = Guid.NewGuid().ToString(),
                    MsgID = (Messages.Count + 1).ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "Due is this Monday!!",
                    IsReply = false
                };

                AddMessage(message);
            }
        }
    }
}
