using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork uow;

        public ProductService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public List<Product> GetAllProducts()
        {
            return uow.ProductRepository.GetAll();
        }

        public Product GetProduct()
        {
            return uow.ProductRepository.Get();
        }
    }
}
