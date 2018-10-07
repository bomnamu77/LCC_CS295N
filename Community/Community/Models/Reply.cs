using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Community.Models
{
    public class Reply
    {
        private List<Reply> replies = new List<Reply>();
        public User User { get; set; }
        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }

        //if it's the reply to the contact, the contact of this reply
        //even if it's the reply to another reply, the original contact where the another reply is attached
        public Contact Contact { get; set; }
        //if it's the reply to another reply, the reply that this reply is attached to
        public Reply ReplyTo { get; set; }
        //replies attached from this reply
        public List<Reply> Replies { get { return replies; } } 
    }
}
