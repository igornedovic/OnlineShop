using OnlineShop.Data;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopContext context;

        public ProductRepository(OnlineShopContext context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Product1"
                },
                new Product()
                {
                    Name = "Product2"
                }
            };
        }
        public Product Get()
        {
            return new Product() { Name = "One Product", Price = 120.55 };
        }
    }
}
