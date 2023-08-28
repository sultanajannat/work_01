using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using work_01.Server;
using work_01.Shared.DTO;
using work_01.Shared.Models;

namespace work_01.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public OrdersController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            return await _context.Orders.ToListAsync();
        }
        [HttpGet("DTO")]
        public async Task<ActionResult<IEnumerable<OrderViewDTO>>> GetOrderDTOs()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return await _context.Orders.Include(o=>o.Customer).Include(o=>o.OrderItems).ThenInclude(oi=>oi.Product).Select(o=>new OrderViewDTO
            {
                OrderID= o.OrderID,
                OrderDate= o.OrderDate,
                CustomerName=o.Customer.CustomerName,
                DeliveryDate= o.OrderDate,
                Status=o.Status,
                ItemCount=o.OrderItems.Count(),
                OrderValue=o.OrderItems.Sum(x=>x.Product.Price*x.Quantity)
            }).ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
		[HttpPut("DTO/{id}")]
		public async Task<IActionResult> PutOrderWithOrderItem(int id, OrderEditDTO order)
		{
			if (id != order.OrderID)
			{
				return BadRequest();
			}
			var existing = await _context.Orders.Include(x => x.OrderItems).FirstAsync(o => o.OrderID == id);
			_context.OrderItems.RemoveRange(existing.OrderItems);
			existing.OrderID = order.OrderID;
			existing.OrderDate = order.OrderDate;
			existing.DeliveryDate = order.DeliveryDate;
			existing.CustomerID = order.CustomerID;
			existing.Status = order.Status;
			foreach (var item in order.OrderItems)
			{
				_context.OrderItems.Add(new OrderItem { OrderID = order.OrderID, ProductID = item.ProductID, Quantity = item.Quantity });
			}


			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{

				throw new Exception(ex.InnerException?.Message);

			}

			return NoContent();
		}

		// POST: api/Orders
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost("DTO")]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO dto)
        {
          if (_context.Orders == null)
          {
              return Problem("Entity set 'ProductDbContext.Orders'  is null.");
          }
            var order = new Order
            {
                CustomerID=dto.CustomerID,
                OrderDate=dto.OrderDate,
                DeliveryDate=dto.DeliveryDate,
                Status=dto.Status,
            };
            foreach (var oi in dto.OrderItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductID=oi.ProductID,
                    Quantity=oi.Quantity,
                });
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
