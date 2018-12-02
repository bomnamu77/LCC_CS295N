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

            if (!context.Locations.Any())
            {

                // This is temporary code, just for testing
                context.Locations.AddRange(
                    new Models.Location
                    {
                        Name = "Eugene Symphony",
                        Link = "https://eugenesymphony.org/",
                        Description = "Under the leadership of Music Director and Conductor Francesco Lecce-Chong, the Eugene Symphony's mission is enriching lives through the power of music."
                    },

                    new Models.Location
                    {
                        Name = "Hult Center",
                        Link = "http://www.hultcenter.org/",
                        Description = "Official Home of the Hult Center for the Performing Arts, Eugene, Oregon's most beautiful concert venue for touring shows, concerts, local events and tickets."
                    },

                    new Models.Location
                    {
                        Name = "Beacock Music Eugene",
                        Link = "https://www.beacockmusic.com/",
                        Description = "Music Shop"
                    }
                );

                context.SaveChanges();
            }
            if (!context.Locations.Any())
            {
                context.Peoples.AddRange(
                    new Models.People
                    {
                    Name = "Leonard Bernstein",
                    Link = "https://en.wikipedia.org/wiki/Leonard_Bernstein",
                    Description = "an American composer, conductor, author, music lecturer, and pianist."
                    },
                
                    new Models.People
                    {
                        Name = "Richard Long",
                        Link = "https://www.escorchestra.org/meet-the-conductor/",
                        Description = "Conductor"
                    },
                    new Models.People
                    {
                        Name = "B.J. Novitski",
                        Link = "https://www.escorchestra.org/board-of-directors/",
                        Description = "Secretary/Treasurer/Webmaster"
                    }
                );

                context.SaveChanges();
            }
            
        }
    }

}
