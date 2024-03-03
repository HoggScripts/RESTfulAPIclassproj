using System.Text.Json.Serialization;

namespace eCommerceRESTful.Models;

public class Product
{
    public int ProductId { get; set; } // PK
    public string ProductName { get; set; }
    public double Price { get; set; }
    
    [JsonIgnore]
    public ICollection<OrderItem>? OrderItems { get; set; }
}