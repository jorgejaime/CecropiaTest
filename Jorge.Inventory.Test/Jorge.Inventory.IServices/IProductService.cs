using Jorge.Inventory.Infrastructure.Messaging;
using Jorge.Inventory.Services.Messaging.Massages.Product;
using System;

namespace Jorge.Inventory.IServices
{
    public interface IProductService
    {
        ContractResponse<GetProductResponse> UpdateProduct(ContractRequest<AddUpdateProductRequest> request);
        ContractResponse<GetProductResponse> AddProduct(ContractRequest<AddUpdateProductRequest> request);
        ContractResponse<GetProductResponse> GetProduct(ContractRequest<GetProductRequest> request);
        ContractResponse<GetAllProductsResponse> GetAllProducts(ContractRequest<BaseRequest> request);
        ContractResponse<BaseResponse> RemoveProduct(ContractRequest<GetProductRequest> request);
    }
}
