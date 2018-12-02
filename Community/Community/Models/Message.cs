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
        
        private List<Message> replies = new List<Message>();
        
        public User From { get; set; }
        
        public User To { get; set; }
        
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter your message")]
        public string Text { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
        //replies from this message
        // ICollection is more flexible than List and can be modified. IEnumerable can't be modified
        public ICollection<Message> Replies { get { return replies; } }
        
        //An indicator whether this is replied message or not, default:false
        public bool IsReply { get; set; } = false;
        //Priority 1-3 (1: low, 2: medium, 3: high), default:0
        [Required]
        [Range(0,3)]
        public int Priority { get; set; } = 0;
    }
}

