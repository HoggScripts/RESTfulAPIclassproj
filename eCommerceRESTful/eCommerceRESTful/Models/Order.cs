using System.Text.Json.Serialization;

namespace eCommerceRESTful.Models;

public class Order
{
    public int OrderId { get; set; } // PK
    public int CustomerId { get; set; } // FK
    
    [JsonIgnore]
    public Customer? Customer { get; set; }
    
    [JsonIgnore]
    public ICollection<OrderItem>? OrderItems { get; set; }

    public double TotalAmount
    {
        get
        {
            if (OrderItems == null)
            {
                return 0;
            }

            double total = 0;
            foreach (var item in OrderItems)
            {
                total += item.Quantity * item.Product.Price;
            }

            return total;
        }
    }
}