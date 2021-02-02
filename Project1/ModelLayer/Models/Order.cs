using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Order
    {
        [Key]//Sets the below to be the key for the database
        public Guid OrderId { get; set; } = Guid.NewGuid(); //Sets a public Guid to the above guid and returns the value
        public Customer Customer { get; set; }
        public Location Location { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Product must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Amount { get; set; }

        public DateTime? Date {get; set;}
    }
}