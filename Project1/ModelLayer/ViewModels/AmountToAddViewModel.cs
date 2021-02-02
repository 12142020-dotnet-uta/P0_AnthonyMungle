using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class AmountToAddViewModel
    {
        [Display(Name = "User")]
        public Guid CustomerId { get; set; }
        //public Guid CartId { get; set; } 

        [Display(Name = "Inventory")]
        public int inventory { get; set; }

        [Display(Name = "Product")]
        public String Product { get; set; }
        //public Customer Owner { get; set; }

        [Display(Name = "Location")]
        public int location { get; set; }

        [Display(Name = "Discription")]
        public string discription { get; set; }
        public string JpgString { get; set; }

        public int stock { get; set; }
        
        [Range(0, 20)]
        public int amount { get; set; }


    }
}
