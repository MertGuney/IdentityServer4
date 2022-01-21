using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UdemyIdentityServer.FirstApi.Models;

namespace UdemyIdentityServer.FirstApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "ReadProduct")]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>() {
                new Product { Id = 1, Name = "Kalem0", Price = 1000, Stock = 500 },
                new Product { Id = 2, Name = "Kalem1", Price = 1020, Stock = 500 },
                new Product { Id = 3, Name = "Kalem2", Price = 1030, Stock = 500 },
                new Product { Id = 4, Name = "Kalem3", Price = 1054, Stock = 500 },
                new Product { Id = 5, Name = "Kalem4", Price = 1050, Stock = 500 },
                new Product { Id = 6, Name = "Kalem5", Price = 1006, Stock = 500 }

            };
            return Ok(productList);
        }
        // startup icerisinde tanımladıgımız policy adına duruma gore 
        [Authorize(Policy = "UpdateOrCreate")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"Id {id} olan ürün güncellenmistir.");
        }
        [Authorize(Policy = "UpdateOrCreate")]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }

    }
}
