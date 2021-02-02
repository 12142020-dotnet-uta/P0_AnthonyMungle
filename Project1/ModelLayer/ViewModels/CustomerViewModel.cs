using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
     public class CustomerViewModel
    {
     
       // [Key]//Sets the below to be the key for the database

        public Guid CustomerId { get; set; } = Guid.NewGuid(); //Sets a public Guid to the above guid and returns the value

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "User Name")]
        public string Uname { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Display(Name = "Picture")]
        public string JpgString {get; set;}
        public IFormFile IformFileImage { get; set; }

    }
}
