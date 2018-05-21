

using Jorge.Inventory.Services.Messaging.ViewModels.Product;
using System.Collections.Generic;

namespace Jorge.Inventory.Services.Messaging.Massages.Product
{ 
    public class GetAllProductsResponse
    {
        public List<ProductView> Products { get; set; }
    }
}
