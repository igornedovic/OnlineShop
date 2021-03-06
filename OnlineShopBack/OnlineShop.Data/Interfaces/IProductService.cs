using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProduct();
    }
}
