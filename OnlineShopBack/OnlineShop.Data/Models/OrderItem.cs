
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
