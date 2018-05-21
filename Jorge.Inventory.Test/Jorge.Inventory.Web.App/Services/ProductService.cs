using AutoMapper;
using Jorge.Inventory.Infrastructure.Messaging;
using Jorge.Inventory.Model;
using Jorge.Inventory.Services.Messaging;
using Jorge.Inventory.Services.Messaging.Massages.Product;
using Jorge.Inventory.Services.Messaging.ViewModels.Product;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jorge.Inventory.Web.App.Services
{
    public class ProductService : IProductService
    {

        private readonly ILogger<ProductService> _logger;
        private readonly IConfiguration _configuration;
      
        private readonly RestClient _client;

        public ProductService(ILogger<ProductService> logger, IConfiguration configuration)
        {
         
            _logger = logger;
            _configuration = configuration;
            var baseUrl = _configuration["serviceUrl"];
            _client = new RestClient(baseUrl);
        }

        private RestRequest CreateRequest<T>( ContractRequest<T> request, string url, RestSharp.Method method)
            where T : class
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            var requestService = new RestRequest(url, method);
            requestService.AddHeader("Cache-Control", "no-cache");
            requestService.AddHeader("Content-Type", "application/json; charset-utf-8");
            requestService.AddParameter("application/json", json, ParameterType.RequestBody);

            return requestService;
        }

        public ContractResponse<GetProductResponse> GetProduct(ContractRequest<GetProductRequest> request)
        {
            ContractResponse<GetProductResponse> response;
            try
            {
                var requestService = CreateRequest(request, $"products/{request.Data.Id}", Method.GET);
                var responseService = _client.Execute<ContractResponse<GetProductResponse>>(requestService);
                response = responseService.Data;
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
                var requestService = CreateRequest(request, "products", Method.POST);
                var responseService = _client.Execute<ContractResponse<GetProductResponse>>(requestService);
                response = responseService.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(20, ex, ex.Message);
                response = ContractUtil.CreateInvalidResponse<GetProductResponse>(ex);
            }


            return response;
        }

        public ContractResponse<GetProductResponse> UpdateProduct(ContractRequest<AddUpdateProductRequest> request)
        {
            ContractResponse<GetProductResponse> response;

            try
            {
                var requestService = CreateRequest(request, $"products/{request.Data.Product.Id}", Method.PUT);
                var responseService = _client.Execute<ContractResponse<GetProductResponse>>(requestService);
                response = responseService.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(20, ex, ex.Message);
                response = ContractUtil.CreateInvalidResponse<GetProductResponse>(ex);
            }


            return response;
        }


        public async Task<ContractResponse<GetAllProductsResponse>> GetAllProducts(ContractRequest<BaseRequest> request)
        {

            ContractResponse<GetAllProductsResponse> response;
            try
            {


                var requestService = CreateRequest(request, "products", Method.GET);
                var responseService = await _client.ExecuteGetTaskAsync<ContractResponse<GetAllProductsResponse>>(requestService);
                response =  responseService.Data;

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
                var requestService = CreateRequest(request, $"products/{request.Data.Id}", Method.DELETE);
                var responseService = _client.Execute<ContractResponse<BaseResponse>>(requestService);
                response = responseService.Data;
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
