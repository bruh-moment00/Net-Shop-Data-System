using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_Office_backend.Context;
using Back_Office_backend.Models;
using Back_Office_backend.Models.QueryModels;
using Back_Office_backend.Paging;

namespace Back_Office_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly NetStoreDBContext _context;

        public OrdersController(NetStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<PaginationModel<OrderGetManyResponse>> GetOrders(string search, int pageNumber = 1, int pageSize = 10)
        {
            if(search != null)
            {
                var query = from order in _context.Orders
                            join client in _context.UsersClients on order.ClientId equals client.Id
                            join status in _context.OrdersStatuses on order.Status equals status.Id
                            join manager in _context.UsersEmployees on order.ManagerId equals manager.Id
                            where order.Id.ToString().Contains(search) || status.Name.Contains(search) || manager.Id.ToString().Contains(search)
                            select new OrderGetManyResponse
                            {
                                Id = order.Id,
                                ClientFullName = client.LastName + " " + client.FirstName + " " + client.SecondName,
                                Status = status.Name,
                                UpdateDate = order.UpdateDate,
                                Cost = order.Cost,
                                ManagerId = manager.Id
                            };
                return PaginationModel<OrderGetManyResponse>.GetPagedModel(query, pageNumber, pageSize);
            }
            else
            {
                var query = from order in _context.Orders
                            join client in _context.UsersClients on order.ClientId equals client.Id
                            join status in _context.OrdersStatuses on order.Status equals status.Id
                            join manager in _context.UsersEmployees on order.ManagerId equals manager.Id
                            select new OrderGetManyResponse
                            {
                                Id = order.Id,
                                ClientFullName = client.LastName + " " + client.FirstName + " " + client.SecondName,
                                Status = status.Name,
                                UpdateDate = order.UpdateDate,
                                Cost = order.Cost,
                                ManagerId = manager.Id
                            };
                return PaginationModel<OrderGetManyResponse>.GetPagedModel(query, pageNumber, pageSize);
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGetSingleResponse>> GetOrder(int id)
        {
            var order = await _context.Orders.Select(o => new OrderGetSingleResponse
            {
                Id = o.Id,
                Client = o.Client,
                Status = o.StatusNavigation,
                UpdateDate = o.UpdateDate,
                Cost = o.Cost,
                Manager = o.Manager,
            }).Where(o => o.Id == id).FirstOrDefaultAsync();

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
            if (id != order.Id)
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
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
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
