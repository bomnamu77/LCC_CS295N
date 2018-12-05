using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame.Models
{
    public class User
    {
        private List<Comment> comments = new List<Comment>();
        private List<Game> games= new List<Game>();

        public int UserID { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public ICollection<Game> Games { get { return games; } }
        public ICollection<Comment> Comments { get { return comments; } }
    }
}
