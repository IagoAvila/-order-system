using OrderManagement.Api.Models;

namespace OrderManagement.Api.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(Guid id, Product product);
        Task<bool> DeleteAsync(Guid id);
    }
}
