using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Community.Models
{
    public class Contact
    {
        private List<Reply> replies = new List<Reply>();
        public User User { get; set; }
        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        //replies from this contact
        public List<Reply> Replies { get { return replies; } }
    }
}

