using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    class MainScreenViewModel
    {
        public Guid CustomerId { get; set; } //Sets a public Guid to the above guid and returns the value

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "User Name")]
        public string Uname { get; set; }
    }
}
