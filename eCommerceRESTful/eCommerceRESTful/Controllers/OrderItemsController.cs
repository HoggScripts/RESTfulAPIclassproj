using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerceRESTful.Models;
using Microsoft.Extensions.Logging;

namespace eCommerceRESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly eCommerceContext _context;
        private readonly ILogger<OrderItemsController> _logger;

        public OrderItemsController(eCommerceContext context, ILogger<OrderItemsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            _logger.LogInformation("Getting all order items");
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                _logger.LogWarning("Order item with id {OrderItemId} not found", id);
                return NotFound();
            }

            _logger.LogInformation("Order item with id {OrderItemId} retrieved successfully", id);
            return orderItem;
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.OrderItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Order item with id {OrderItemId} updated successfully", id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
                {
                    _logger.LogWarning("Order item with id {OrderItemId} not found", id);
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            // Retrieve the Order and Product from the database
            var order = await _context.Orders.FindAsync(orderItem.OrderId);
            var product = await _context.Products.FindAsync(orderItem.ProductId);

            // Log the Order and Product
            _logger.LogInformation("Order: {Order}", order);
            _logger.LogInformation("Product: {Product}", product);

            if (order == null || product == null)
            {
                // If the Order or Product does not exist, return a BadRequest
                return BadRequest("The Order or Product does not exist.");
            }

            // Initialize the OrderItems collections if they are null
            // This is necessary to avoid a NullReferenceException
            order.OrderItems = order.OrderItems ?? new List<OrderItem>();
            product.OrderItems = product.OrderItems ?? new List<OrderItem>();

            // Add the OrderItem to the OrderItems collection of the Order and Product
            order.OrderItems.Add(orderItem);
            product.OrderItems.Add(orderItem);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Order item with id {OrderItemId} created successfully", orderItem.OrderItemId);
            return CreatedAtAction("GetOrderItem", new { id = orderItem.OrderItemId }, orderItem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                _logger.LogWarning("Order item with id {OrderItemId} not found", id);
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Order item with id {OrderItemId} deleted successfully", id);
            return NoContent();
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.OrderItemId == id);
        }
    }
}