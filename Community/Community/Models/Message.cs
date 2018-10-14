using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Community.Models
{
    public class Message
    {
        private List<Message> replies = new List<Message>();
        public string MsgID { get; set; }
        public User From { get; set; }
        public User To { get; set; }
        [Required(ErrorMessage = "Please enter your message")]
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        //replies from this message
        public List<Message> Replies { get { return replies; } }
    }
}

