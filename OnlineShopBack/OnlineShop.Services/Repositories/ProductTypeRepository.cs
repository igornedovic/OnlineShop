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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly OnlineShopContext context;

        public ProductTypeRepository(OnlineShopContext context)
        {
            this.context = context;
        }

        public List<ProductType> GetAll()
        {
            throw new NotImplementedException();
        }
        public ProductType Get()
        {
            throw new NotImplementedException();
        }
    }
}
