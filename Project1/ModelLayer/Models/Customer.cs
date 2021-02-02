using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Customer
    {
       
        [Key]//Sets the below to be the key for the database
        public Guid CustomerId { get; set; } = Guid.NewGuid(); //Sets a public Guid to the above guid and returns the value

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "User Name")]
        public string Uname { get; set;}

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set;}

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set;}

        public byte[] ByteArrayImage { get; set; }

    }
}