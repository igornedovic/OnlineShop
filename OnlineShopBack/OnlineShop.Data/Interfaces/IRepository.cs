using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public T Get();
    }
}
