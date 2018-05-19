

using Jorge.Inventory.Services.Messaging.ViewModels.Product;
using System.Collections.Generic;

namespace Jorge.Inventory.Services.Messaging.Massages.Product
{ 
    public class GetAllProductResponse
    {
        public List<ProductView> Role { get; set; }
    }
}
