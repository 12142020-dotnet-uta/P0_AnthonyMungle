using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get;set;}
        public Location Location { get; set;}
        public Product Product { get; set;}

        [Range(0, int.MaxValue)]
        public int Quantity { get; set;}
    }
}