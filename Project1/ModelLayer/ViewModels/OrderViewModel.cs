using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Order number")]
        public Guid OrderId { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        public DateTime? Date { get; set; }
    }
}
