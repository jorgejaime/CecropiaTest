using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Http;
using Jorge.Inventory.Services.Messaging.Massages.Product;
using Jorge.Inventory.Web.App.Models.DataTable;
using Jorge.Inventory.Services.Messaging.ViewModels.Product;
using Jorge.Inventory.Web.App.Services;
using Jorge.Inventory.Infrastructure.Messaging;
using Jorge.Inventory.Web.App.Models.Product;
using AutoMapper;
using System.Threading.Tasks;
using Jorge.Inventory.Web.App.Models;

namespace Jorge.Inventory.Web.App.Controllers
{ 

    public class ProductsController : BaseController
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        private readonly IConfiguration _configuration;

        public ProductsController(
            IProductService productService,
            ILogger<ProductsController> logger,
            IConfiguration configuration)
        {
            _productService = productService;
            _logger = logger;
            _configuration = configuration;
        }


        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
             
                var responseProduct = await _productService.GetAllProducts( new ContractRequest<BaseRequest>());
                var modelList = responseProduct.Data.Products;
                var response = new DataTableResponseViewModel<ProductView>
                {
                    Data = modelList,
                    RecordsFiltered = modelList.Count,
                    RecordsTotal = modelList.Count
                };

                return Json(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting products");
                var response = new DataTableResponseViewModel<ProductView>
                {
                    Data = new List<ProductView>(),
                    RecordsFiltered = 0,
                    RecordsTotal = 0,
                    Error = "Error getting products"
                };
                return Json(response);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductViewModel
            {
             
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = Mapper.Map<ProductView>(model);
                    if (model.File?.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            model.File.CopyTo(memoryStream);
                            product.Image = Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                    var response = _productService.AddProduct(new ContractRequest<AddUpdateProductRequest> { Data = new AddUpdateProductRequest { Product = product } });
                    SetErrorMessages(response.ErrorMessages);
                    ViewBag.IsSuccess = response.IsValid;

                    if (response.IsValid)
                    {
                        return RedirectToAction(nameof(ProductsController.Index), "Products");
                    }
                    else
                    {
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating product");
                    ModelState.AddModelError(string.Empty, "Unexpected Error");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProduct(new ContractRequest<GetProductRequest> { Data = new GetProductRequest { Id = id } });
            if (product?.Data?.Product == null)
            {
                return NotFound();
            }
            var model = Mapper.Map<ProductViewModel>(product.Data.Product);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = Mapper.Map<ProductView>(model);
                    if (model.File?.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            model.File.CopyTo(memoryStream);
                            product.Image = Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                    var response = _productService.UpdateProduct( new ContractRequest<AddUpdateProductRequest> { Data =  new AddUpdateProductRequest { Product = product } });
                    SetErrorMessages(response.ErrorMessages);
                    ViewBag.IsSuccess = response.IsValid;

                    return View(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Editing product");
                    ModelState.AddModelError(string.Empty, "Unexpected Error");
                    ViewBag.IsSuccess = false;
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            var result = new JsonResultViewModel<string>
            {
                IsValid = true,
                Message = "Deleted."
            };

            try
            {
                var response = _productService.RemoveProduct(new ContractRequest<GetProductRequest> { Data = new GetProductRequest { Id = id } });

                if (!response.IsValid)
                {

                    foreach (var error in response.ErrorMessages)
                    {
                        result.ErrorMessage += error;
                        result.ErrorMessage += Environment.NewLine;
                    }
                }


                return Json(result);
             
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Deleting product");
                result.ErrorMessage = ex.Message;
            }
            result.IsValid = false;
            return Json(result);
        }

    }
}