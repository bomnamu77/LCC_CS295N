using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Models
{
    public class Location
    {

        
        public int LocationID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Url]
        public string Link { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        

    }
}
