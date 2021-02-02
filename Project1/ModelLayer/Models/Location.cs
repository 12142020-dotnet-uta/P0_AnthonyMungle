using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Location
    {
    
        [Key]
        public int LocationId { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "Location Name")]
        public string LocationName{ get; set;}
    }
}