using Community.Controllers;
using Community.Models;

using Community.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace Community.Test
{
    public class CommunityTest
    {
        [Fact]
        public void InputMessageTest()
        {
            //Arrange
            var repo = new FakeMessageRepository();
            var homeController = new HomeController(repo);


            //Act
            Message message = new Message
            {
                To = new User { Name = "Spider Man", Email = "parkp@g.com" },
                From = new User { Name = "Iron Man", Email = "starkt@g.com" },
                MsgID = Guid.NewGuid().ToString(),
                TimeStamp = DateTime.Now,
                Text = "Hello",
                IsReply = false
            };


            homeController.InputMessage(message);

            //Assert
            Assert.Equal("Hello",
                repo.Messages[repo.Messages.Count - 1].Text);
        }

        [Fact]
        public void ListSentMessageTest()
        {
            //Arrange
            var repo = new FakeMessageRepository();
            var homeController = new HomeController(repo);


            //Act
            Message message = new Message
            {
                To = new User { Name = "Spider Man", Email = "parkp@g.com" },
                From = repo.Users[0],
                MsgID = Guid.NewGuid().ToString(),
                TimeStamp = DateTime.Now,
                Text = "Hello",
                IsReply = false
            };


            homeController.InputMessage(message);
            var result = homeController.ListSentMessage();
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Message>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void ListReceivedMessageTest()
        {
            //Arrange
            var repo = new FakeMessageRepository();
            var homeController = new HomeController(repo);


            //Act
            Message message = new Message
            {
                From = new User { Name = "Spider Man", Email = "parkp@g.com" },
                To = repo.Users[0],
                MsgID = Guid.NewGuid().ToString(),
                TimeStamp = DateTime.Now,
                Text = "Hello",
                IsReply = false
            };


            homeController.InputMessage(message);
            var result = homeController.ListReceivedMessage();
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Message>>(
                viewResult.ViewData.Model);
            Assert.Equal(5, model.Count());
        }

        [Fact]
        public void ReplyMessageTest()
        {
            //Arrange
            var repo = new FakeMessageRepository();
            var homeController = new HomeController(repo);


            //Act
            string msgID="";
            foreach (Message m in repo.Messages)
            {
                if (m.To.Equals(repo.Users[0]))
                {
                    msgID = m.MsgID;
                    break;
                }
            }

            homeController.ReplyMessage(msgID, "ReplyTest");

            //Assert
            Assert.Equal("ReplyTest",
               repo.Messages[repo.Messages.Count - 1].Text);
            Assert.True(repo.Messages[repo.Messages.Count - 1].IsReply);
            
        }

        [Fact]
        public void SetPriorityTest()
        {
            //Arrange
            var repo = new FakeMessageRepository();
            var homeController = new HomeController(repo);


            //Act
            string msgID = repo.Messages[0].MsgID;
            
            homeController.SetPriority(msgID,2, "ListSentMessage");

            //Assert
            Assert.Equal(2, repo.Messages[0].Priority);
            
        }
    }
}
