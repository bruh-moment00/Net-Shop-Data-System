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
    public class StockController : ControllerBase
    {
        private readonly NetStoreDBContext _context;

        public StockController(NetStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Stocks
        [HttpGet]
        public ActionResult<PaginationModel<StockGetManyResponse>> GetStockList(string search, int pageNumber = 1, int pageSize = 10)
        {
            if (search != null)
            {
                var query = from unit in _context.StockList
                            join product in _context.Products on unit.ProductId equals product.Id
                            join status in _context.StockStatuses on unit.StatusId equals status.Id
                            where product.Name.Contains(search) || product.Brand.Brand1.Contains(search) || unit.OrderId.ToString().Contains(search)
                            select new StockGetManyResponse
                            {
                                Id = unit.Id,
                                ProductName = product.Name,
                                Status = status.Name,
                                ReceiptDate = unit.ReceiptDate,
                                SellDate = unit.SellDate,
                                OrderId = unit.OrderId
                            };
                return PaginationModel<StockGetManyResponse>.GetPagedModel(query, pageNumber, pageSize);
            }
            else
            {
                var query = from unit in _context.StockList
                            join product in _context.Products on unit.ProductId equals product.Id
                            join status in _context.StockStatuses on unit.StatusId equals status.Id
                            select new StockGetManyResponse
                            {
                                Id = unit.Id,
                                ProductName = product.Name,
                                Status = status.Name,
                                ReceiptDate = unit.ReceiptDate,
                                SellDate = unit.SellDate,
                                OrderId = unit.OrderId
                            };
                return PaginationModel<StockGetManyResponse>.GetPagedModel(query, pageNumber, pageSize);
            }
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockGetSingleResponse>> GetStock(int id)
        {
            var stock = await _context.StockList.Select(s => new StockGetSingleResponse
            { 
                Id = s.Id,
                Product = s.Product,
                Status = s.Status,
                ReceiptDate = s.ReceiptDate,
                SellDate = s.SellDate,
                Order = s.Order
            }).Where(s => s.Id == id).FirstOrDefaultAsync();

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
            _context.StockList.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.Id }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _context.StockList.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.StockList.Remove(stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockExists(int id)
        {
            return _context.StockList.Any(e => e.Id == id);
        }
    }
}
