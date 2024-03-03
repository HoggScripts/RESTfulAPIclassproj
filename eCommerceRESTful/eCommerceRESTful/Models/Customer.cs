using System.Collections;
using System.Text.Json.Serialization;

namespace eCommerceRESTful.Models;

public class Customer
{
    public int CustomerId { get; set; } // PK
    public string Name { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    public string Password { get; set; }
    
    [JsonIgnore]
    public ICollection<Order> Orders { get; set; }
    
    [JsonIgnore]
    public ICollection<Address> Addresses { get; set; }
}