using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace eCommerceRESTful.Models;

public class eCommerceContext : IdentityDbContext<IdentityUser>
{
    public eCommerceContext(DbContextOptions<eCommerceContext> options)
        : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
}