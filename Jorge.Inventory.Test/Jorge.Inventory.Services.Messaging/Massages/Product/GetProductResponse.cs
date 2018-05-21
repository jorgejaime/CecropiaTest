

using Jorge.Inventory.Services.Messaging.ViewModels.Product;

namespace Jorge.Inventory.Services.Messaging.Massages.Product
{ 
    public class GetProductResponse
    {
        public ProductView Product { get; set; }
    }
}
