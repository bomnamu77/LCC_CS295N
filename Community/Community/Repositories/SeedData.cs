using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Community.Models;
using System;

namespace Community.Repositories
{
    public class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
            .GetRequiredService<AppDbContext>();
            context.Database.Migrate();
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                        new User
                        {
                            Name = "John",
                            Email = "john@g.com"
                        },
                        new User
                        {
                            Name = "Mary",
                            Email = "mari@g.com"
                        },
                        new User
                        {
                            Name = "Andrew",
                            Email = "andrew@g.com"
                        }
                        );
                context.SaveChanges();
            }
            if (!context.Messages.Any())
            {
                User toUser = context.Users.First(b => b.Email == "john@g.com");
                User fromUser = context.Users.First(b => b.Email == "mari@g.com");
                User fromUser2 = context.Users.First(b => b.Email == "andrew@g.com");
                context.Messages.AddRange(
                    new Models.Message
                    {
                        To = toUser,
                        From = fromUser,
                        //MsgID = Guid.NewGuid().ToString(),

                        TimeStamp = DateTime.Now,
                        Text = "Hello",
                        IsReply = false
                    },
                    new Models.Message
                    {
                        To = toUser,
                        From = fromUser2,
                        //MsgID = Guid.NewGuid().ToString(),

                        TimeStamp = DateTime.Now,
                        Text = "Music List",
                        IsReply = false
                    },
                    new Models.Message
                    {
                        From = toUser,
                        To = fromUser,
                        
                        TimeStamp = DateTime.Now,
                        Text = "Good to meet you!",
                        IsReply = false
                    }
                    ,
                    new Models.Message
                    {
                        From = toUser,
                        To = fromUser2,

                        TimeStamp = DateTime.Now,
                        Text = "Thanks note to donators",
                        IsReply = false
                    }
                );
                context.SaveChanges();

            }
        }
    }

}
