using Jorge.Inventory.Infrastructure.Messaging;
using Jorge.Inventory.Services.Messaging.Massages.Product;
using System;
using System.Threading.Tasks;

namespace Jorge.Inventory.Web.App.Services
{
    public interface IProductService
    {
        ContractResponse<GetProductResponse> UpdateProduct(ContractRequest<AddUpdateProductRequest> request);
        ContractResponse<GetProductResponse> AddProduct(ContractRequest<AddUpdateProductRequest> request);
        ContractResponse<GetProductResponse> GetProduct(ContractRequest<GetProductRequest> request);
        Task<ContractResponse<GetAllProductsResponse>> GetAllProducts(ContractRequest<BaseRequest> request);
        ContractResponse<BaseResponse> RemoveProduct(ContractRequest<GetProductRequest> request);
    }
}
