using Checkout.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
namespace CalebAPI.Controllers
{
    namespace CalebAPI.Controllers
    {

        [ApiController]
        [Route("[controller]")]

        public class ProductsController : ControllerBase
        {
            private readonly ILogger<ProductsController> _logger;
            private readonly IProductsService _productsService;

            public ProductsController(ILogger<ProductsController> logger, IProductsService ProductsService)
            {
                _productsService = ProductsService;
                _logger = logger;
            }

            

            [HttpGet]
            public ActionResult<List<Product>> GetAllProducts()
            {
                var allProducts = _productsService.GetProducts().ToList();
                return Ok(allProducts);
            }
         }
    }
}