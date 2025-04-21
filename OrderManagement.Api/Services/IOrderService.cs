using OrderManagement.Api.Models;

namespace OrderManagement.Api.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task<Order?> CreateAsync(Order order);
        Task<bool> DeleteAsync(Guid id);
    }
}
