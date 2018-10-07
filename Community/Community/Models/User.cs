using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Community.Models
{
    public class User
    {

        // private List<Contact> contacts = new List<Contact>();
        // private List<Reply> replies = new List<Reply>();
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
       // public List<Contact> Contacts { get { return contacts; } }
       // public List<Reply> Replies { get { return replies; } }
    }
}
