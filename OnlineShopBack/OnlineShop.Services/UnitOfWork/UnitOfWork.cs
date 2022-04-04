using OnlineShop.Data;
using OnlineShop.Data.Interfaces;
using OnlineShop.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopContext context;

        public UnitOfWork(OnlineShopContext context)
        {
            this.context = context;
            ProductRepository = new ProductRepository(context);
            ProductTypeRepository = new ProductTypeRepository(context);
        }
        public IProductRepository ProductRepository { get; set; }
        public IProductTypeRepository ProductTypeRepository { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
