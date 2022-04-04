using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET api/product
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return productService.GetAllProducts();
        }

        // GET api/product/{id}
        [HttpGet("{id}")]
        public Product GetOne(int id)
        {
            return productService.GetProduct();
        }
    }
}
