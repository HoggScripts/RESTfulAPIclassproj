using System.Text.Json.Serialization;

namespace eCommerceRESTful.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    public string Password { get; set; }
}