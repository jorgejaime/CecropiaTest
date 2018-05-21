using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Jorge.Inventory.Web.App.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

  
        [MaxLength(25)]
        [Required(ErrorMessage = "The {0} is required")]
        public string Sku { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "The {0} is required")]
        public string Description { get; set; }

        [DisplayName("Quantity Stock")]
        [Required(ErrorMessage = "The {0} is required")]
        public decimal QuantityStock { get; set; }

        [DisplayName("Final Price")]
        [Required(ErrorMessage = "The {0} is required")]
        public decimal FinalPrice { get; set; }

        [DisplayName("Regular Price")]
        [Required(ErrorMessage = "The {0} is required")]
        public decimal RegularPrice { get; set; }

        [DisplayName("Apply Taxes")]
        [Required(ErrorMessage = "The {0} is required")]
        public bool ApplyTaxes { get; set; }

        [DisplayName("Tax Rate")]
        [Required(ErrorMessage = "The {0} is required")]
        public decimal TaxRate { get; set; }

        [DisplayName("Location")]
        [Required(ErrorMessage = "The {0} is required")]
        public int Location { get; set; }

        [DisplayName("Image")]
        public string Image { get; set; }

        public IFormFile File { get; set; }
    }
}
