using System.Text.Json.Serialization;

namespace eCommerceRESTful.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public double TotalAmount { get; set; }
    
    [JsonIgnore]
    public ICollection<OrderItem>? OrderItems { get; set; }
}