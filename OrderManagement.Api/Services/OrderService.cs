using Microsoft.EntityFrameworkCore;
using OrderManagement.Api.Data;
using OrderManagement.Api.Models;
using OrderManagement.Api.Services;

namespace OrderManagement.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceBusSenderService _bus;

        public OrderService(ApplicationDbContext context, ServiceBusSenderService bus)
        {
            _context = context;
            _bus = bus;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order?> CreateAsync(Order order)
        {
            var customerExists = await _context.Customers.AnyAsync(c => c.Id == order.CustomerId);
            if (!customerExists)
                return null;

            var productIds = order.OrderProducts.Select(op => op.ProductId).ToList();
            var validProducts = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            if (validProducts.Count != productIds.Count)
                return null;

            order.CreatedAt = DateTime.UtcNow;
            order.Status = "Pendente";

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            await _bus.SendMessageAsync(order); // Envia o pedido para o Azure Service Bus 🚀

            return order;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
