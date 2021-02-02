using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Cart
    {

        [Key]//Sets the below to be the key for the database
        public Guid CartId { get; set; } = Guid.NewGuid();
        public Product Product { get; set; }
        public Customer Owner { get; set; }
        public int location { get; set; }

        [Range(0, int.MaxValue)]
        public int amount {get; set;}

    } 
}