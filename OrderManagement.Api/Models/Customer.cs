namespace OrderManagement.Api.Models
{
public class Customer
{
    public Guid Id { get; set; }  // ALTERADO de int para Guid
    public string Name { get; set; } = default!;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
}