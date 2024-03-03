using System.Text.Json.Serialization;

namespace eCommerceRESTful.Models;

public class OrderItem
{
    public int OrderItemId { get; set; } // PK
    public int Quantity { get; set; }
    
    public int OrderId { get; set; } // FK
    [JsonIgnore]
    public Order? Order { get; set; }
    
    public int ProductId { get; set; } // FK
    [JsonIgnore]
    public Product? Product { get; set; }
}