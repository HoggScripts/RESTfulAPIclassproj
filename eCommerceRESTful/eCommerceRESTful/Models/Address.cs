namespace eCommerceRESTful.Models.Customer;

public class Address
{
    public int AddressId { get; set; }
    public int CustomerId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
}