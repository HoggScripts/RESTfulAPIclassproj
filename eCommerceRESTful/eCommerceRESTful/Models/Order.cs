using System.Text.Json.Serialization;

namespace eCommerceRESTful.Models;

public class Order
{
    public int OrderId { get; set; } // PK
    public int CustomerId { get; set; } // FK
    public double TotalAmount { get; set; }
    
    [JsonIgnore]
    public Customer? Customer { get; set; }
    
    [JsonIgnore]
    public ICollection<OrderItem>? OrderItems { get; set; }
}