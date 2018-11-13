using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Community.Models
{
    public class User
    {
        public int UserID { get; set; }
        //[Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please enter your email address")]
        //[RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
    }
}
