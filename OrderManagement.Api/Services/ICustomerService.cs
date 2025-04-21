using OrderManagement.Api.Models;

namespace OrderManagement.Api.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(Guid id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(Guid id, Customer customer);
        Task<bool> DeleteAsync(Guid id);
    }
}
