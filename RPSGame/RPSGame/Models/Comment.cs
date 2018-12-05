using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame.Models
{
    public class Comment
    {
        public int commentID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }

        public User To { get; set; }
        public string Text { get; set; }

        public bool Cheer { get; set; }
    }
}
