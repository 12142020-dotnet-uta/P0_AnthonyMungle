using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class ProductModelView
    {
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Product Name must be from 3 to 20 characters")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Use letters only")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string JpgString { get; set; }

    }
}
