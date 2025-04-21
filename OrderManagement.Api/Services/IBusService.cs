using OrderManagement.Api.Models;
using System.Threading.Tasks;

namespace OrderManagement.Api.Services
{
    public interface IBusService
    {
        Task SendMessageAsync(Order order);
    }
}
