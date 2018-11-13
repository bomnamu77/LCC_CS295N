using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Community.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        //public int MsgID { get; set; }
        private List<Message> replies = new List<Message>();
        
        public User From { get; set; }
        public User To { get; set; }
        //[Required(ErrorMessage = "Please enter your message")]
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        //replies from this message
        public List<Message> Replies { get { return replies; } }
        //An indicator whether this is replied message or not, default:false
        public bool IsReply { get; set; } = false;
        //Priority 1-3 (1: low, 2: medium, 3: high), default:0
        public int Priority { get; set; } = 0;
    }
}

