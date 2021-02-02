
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Product
    {

        [Key]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Product Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set;}

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Display(Name = "Description")]
        public string Description{ get; set;}

        public byte[] ByteArrayImage { get; set; }

    }
}