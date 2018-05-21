using Jorge.Inventory.Infrastructure.Messaging;
using Jorge.Inventory.IRepositories;
using Jorge.Inventory.IServices;
using Jorge.Inventory.Model;
using Jorge.Inventory.Services.Messaging;
using Jorge.Inventory.Services.Messaging.Massages.Product;
using Jorge.Inventory.Services.Messaging.ViewModels.Product;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Jorge.Inventory.Services
{
    public class ProductService : IProductService
    {

        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
         
            _logger = logger;
            _productRepository = productRepository;
        }

        public ContractResponse<GetProductResponse> GetProduct(ContractRequest<GetProductRequest> request)
        {
            ContractResponse<GetProductResponse> response;
            try
            {
                var model = _productRepository.FindById(request.Data.Id);
                var modelResponse = model?.ToProductView();
               
                response = ContractUtil.CreateResponse(request, new GetProductResponse { Product = modelResponse });
            }
            catch (Exception ex)
            {
                _logger.LogError(20, ex, ex.Message);

                response = ContractUtil.CreateInvalidResponse<GetProductResponse>(ex);
            }

            return response;
        }


        public ContractResponse<GetProductResponse> AddProduct(ContractRequest<AddUpdateProductRequest> request)
        {
            ContractResponse<GetProductResponse> response;

            try
            {
                var model = request.Data.Product.ToProduct();
                var brokenRules = model.GetBrokenRules().ToList();


                if (brokenRules.Any())
                {
                    var message = new GetProductResponse
                    {
                        Product = request.Data.Product,
                    };

                    response = ContractUtil.CreateInvalidResponse<GetProductResponse>(brokenRules, message);
                }
                else
                {
                    _productRepository.Add(model);
                  

                    var product = model.ToProductView();
                    var message = new GetProductResponse
                    {
                        Product = product
                    };

                    response = ContractUtil.CreateResponse<GetProductResponse, AddUpdateProductRequest>(request, message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(20, ex, ex.Message);
                return ContractUtil.CreateInvalidResponse<GetProductResponse>(ex);
            }


            return response;
        }

        public ContractResponse<GetProductResponse> UpdateProduct(ContractRequest<AddUpdateProductRequest> request)
        {
            ContractResponse<GetProductResponse> response;

            try
            {
                var model = request.Data.Product.ToProduct();
                var brokenRules = model.GetBrokenRules().ToList();


                if (brokenRules.Any())
                {
                    var message = new GetProductResponse
                    {
                        Product = request.Data.Product,
                    };

                    response = ContractUtil.CreateInvalidResponse<GetProductResponse>(brokenRules, message);
                }
                else
                {


                    var oldProduct = _productRepository.FindById(request.Data.Product.Id);
                    if (string.IsNullOrEmpty(request?.Data?.Product?.Image))
                        model.Image = oldProduct.Image;

                        _productRepository.Update(model);

                    var product = model.ToProductView();
                    var message = new GetProductResponse
                    {
                        Product = product
                    };

                    response = ContractUtil.CreateResponse<GetProductResponse, AddUpdateProductRequest>(request, message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(20, ex, ex.Message);
                return ContractUtil.CreateInvalidResponse<GetProductResponse>(ex);
            }


            return response;
        }


        public ContractResponse<GetAllProductsResponse> GetAllProducts(ContractRequest<BaseRequest> request)
        {

            ContractResponse<GetAllProductsResponse> response;
            try
            {


                var userList = _productRepository.FindAll();
                var modelResponse = userList.ToProductViewList();

                response = ContractUtil.CreateResponse(request, new GetAllProductsResponse { Products = modelResponse });
            }
            catch (Exception ex)
            {
                _logger.LogError(20, ex, ex.Message);

                response = ContractUtil.CreateInvalidResponse<GetAllProductsResponse>(ex);
            }

            return response;

        }

        public ContractResponse<BaseResponse> RemoveProduct(ContractRequest<GetProductRequest> request)
        {
            ContractResponse<BaseResponse> response;
            try
            {
                var model = new Product { Id = request.Data.Id};
                 _productRepository.Remove(model);
        

                response = ContractUtil.CreateResponse(request, new BaseResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError(20, ex, ex.Message);

                response = ContractUtil.CreateInvalidResponse<BaseResponse>(ex);
            }

            return response;
        }


    }
}
