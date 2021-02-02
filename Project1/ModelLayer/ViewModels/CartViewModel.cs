using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class CartViewModel
    {
        [Display(Name = "User")]
        public Guid customerGuid { get; set;}

        [Display(Name = "Cart Id")]
        public Guid CartId { get; set; }

        [Display(Name = "Locations")]
        public int locationsId { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }
        public double total { get; set; }

    }
}
