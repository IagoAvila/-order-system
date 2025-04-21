namespace OrderManagement.Api.Models
{
  public class Product
{
   
public Guid Id { get; set; }  // Alterando de Guid para int
    public string Name { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}

}
