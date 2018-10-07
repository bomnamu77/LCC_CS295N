using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Community.Models
{
    public class Reply
    {
        public User User { get; set; }
        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        
        public Contact Contact { get; set; }
        public Reply ReplyTo { get; set; }
    }
}
