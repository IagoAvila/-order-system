
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Api.Models
{
public class Order
{
    public Guid Id { get; set; }
    public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; } = default!;
    public DateTime CreatedAt { get; set; } // ✅ Adicione essa propriedade
    public string Status { get; set; } = default!; // ✅ E essa também

    public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
}