
using System;

namespace OrderManagement.Api.Models
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
