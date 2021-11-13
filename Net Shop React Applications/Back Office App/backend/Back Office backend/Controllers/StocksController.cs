using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_Office_backend.Context;
using Back_Office_backend.Models;

namespace Back_Office_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly NetStoreDBContext _context;

        public StocksController(NetStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetStockList(string search, int pageNumber = 1, int pageSize = 10)
        {
            if(search != null)
            {
                return await (from unit in _context.Stocks
                              join product in _context.Products on unit.ProductId equals product.Id
                              join status in _context.StockStatuses on unit.StatusId equals status.Id
                              join order in _context.StockStatuses on unit.OrderId equals order.Id
                              where product.Name.Contains(search) || product.Brand.Brand1.Contains(search) || unit.OrderId.ToString().Contains(search)
                              select new 
                              {
                                  ID = unit.Id,
                                  ProductName = product.Name,
                                  Status = status.Name,
                                  unit.ReceiptDate,
                                  unit.SellDate,
                                  OrderId = order.Id
                              }).ReturnPaginatedResult(pageNumber, pageSize).ToListAsync();
            }

            return await (from unit in _context.Stocks
                          join product in _context.Products on unit.ProductId equals product.Id
                          join status in _context.StockStatuses on unit.StatusId equals status.Id
                          join order in _context.StockStatuses on unit.OrderId equals order.Id
                          select new
                          {
                              ID = unit.Id,
                              ProductName = product.Name,
                              Status = status.Name,
                              unit.ReceiptDate,
                              unit.SellDate,
                              OrderId = order.Id
                          }).ReturnPaginatedResult(pageNumber, pageSize).ToListAsync();
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetStock(int id)
        {
            var stock = await _context.Stocks.Select(s => new 
            { 
                ID = s.Id,
                Product = s.Product,
                Status = s.Status,
                s.ReceiptDate,
                s.SellDate,
                Order = s.Order
            }).Where(s => s.ID == id).FirstOrDefaultAsync();

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.Id)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.Id }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockExists(int id)
        {
            return _context.Stocks.Any(e => e.Id == id);
        }
    }
}
