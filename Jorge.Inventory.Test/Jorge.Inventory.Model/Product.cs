using Jorge.Inventory.Infrastructure.Domain;
using System;

namespace Jorge.Inventory.Model
{
    public class Product : EntityBase
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
        public byte[] Image { get; set; }

        protected override void Validate()
        {

        }
    }
}
