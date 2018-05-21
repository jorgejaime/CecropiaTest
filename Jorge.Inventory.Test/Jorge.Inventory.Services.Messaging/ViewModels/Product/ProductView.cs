using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.Inventory.Services.Messaging.ViewModels.Product
{
    public class ProductView
    {

        public int Id { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public decimal QuantityStock { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal RegularPrice { get; set; }
        public bool ApplyTaxes { get; set; }
        public decimal TaxRate { get; set; }
        public int Location { get; set; }
        public string Image { get; set; }

    }
}
