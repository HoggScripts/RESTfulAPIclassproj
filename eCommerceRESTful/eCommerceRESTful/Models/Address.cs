using System.Text.Json.Serialization;

namespace eCommerceRESTful.Models;

public class Address
{
    public int AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    
    public int CustomerId { get; set; }
    [JsonIgnore]
    public Customer? Customer { get; set; }
}