using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jorge.Inventory.Infrastructure.Messaging;
using Jorge.Inventory.IServices;
using Jorge.Inventory.Services.Messaging.Massages.Product;
using Jorge.Inventory.Services.Messaging.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jorge.Inventory.Web.Services.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var response = await Task.Run(() =>
            {
                var productsResponse = _productService.GetAllProducts(new ContractRequest<BaseRequest> ());
                return Json(productsResponse);
            });

            return response;
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            var response = await Task.Run(() =>
            {
                var productsResponse = _productService.GetProduct(ContractUtil.CreateRequest(new GetProductRequest { Id = id }));
                return Json(productsResponse);
            });

            return response;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody]ContractRequest<AddUpdateProductRequest> request)
        {
            var response = await Task.Run(() =>
            {
                var productsResponse = _productService.AddProduct(request);
                return Json(productsResponse);
            });

            return response;
        }


        [HttpPut("{id}")]
        public async Task<JsonResult> Put(int id, [FromBody]ContractRequest<AddUpdateProductRequest> request)
        {
            var response = await Task.Run(() =>
            {
                var productsResponse = _productService.UpdateProduct(request);
                return Json(productsResponse);
            });

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var response = await Task.Run(() =>
            {
                var productsResponse = _productService.RemoveProduct(ContractUtil.CreateRequest(new GetProductRequest { Id = id }));
                return Json(productsResponse);
            });

            return response;
        }



    }
}
