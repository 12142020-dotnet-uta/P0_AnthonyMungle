using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public Guid CustomerId { get; set; } //Maybe NewGuid()
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

    }
}
