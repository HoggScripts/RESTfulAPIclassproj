namespace eCommerceRESTful.Models.Customer;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
}