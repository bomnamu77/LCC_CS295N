
using Community.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Repositories
{
    public class FakeMessageRepository:IMessageRepository
    {
        private List<Message> messages = new List<Message>();
        private List<User> users = new List<User>();

        public List<Message> Messages { get { return messages; } }
        public List<User> Users { get { return users; } }

        public FakeMessageRepository()
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

        public Message GetMessageByID(int msgID)
        {
            Message message = messages.Find(m => m.MessageID == msgID);
            return message;
        }

        public void SetPriority(int msgID, int priority)
        {
            Message message = GetMessageByID(msgID);
            message.Priority = priority;

        }

        public void AddReply(int msgID, Message repMsg)
        {

            AddMessage(repMsg);
            Message orgMsg = GetMessageByID(msgID);
            orgMsg.Replies.Add(repMsg);
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
                    Name = "A",
                    Email = "a@g.com"
                };

                AddUser(user);

                user = new User()
                {
                    Name = "B",
                    Email = "b@g.com"
                };

                AddUser(user);
                user = new User()
                {
                    Name = "C",
                    Email = "c@g.com"
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
                    
                    TimeStamp = DateTime.Now,
                    Text = "ABC",
                    IsReply = false
                };

                AddMessage(message);

                message = new Message()
                {
                    To = Users[0],
                    From = Users[2],
                    TimeStamp = DateTime.Now,
                    Text = "EDF",
                    IsReply = false
                };

                AddMessage(message);

                message = new Message()
                {
                    To = Users[0],
                    From = Users[2],
                    //MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "GIG?",
                    IsReply = false
                };

                AddMessage(message);

                message = new Message()
                {
                    To = Users[0],
                    From = Users[1],
                    //MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "COOL!",
                    IsReply = false
                };

                AddMessage(message);
                message = new Message()
                {
                    To = Users[2],
                    From = Users[0],
                    //MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "MEME",
                    IsReply = false
                };

                AddMessage(message);


                message = new Message()
                {
                    To = Users[1],
                    From = Users[0],
                    //MsgID = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now,
                    Text = "TEST",
                    IsReply = false
                };

                AddMessage(message);
            }
        }
    }
}
