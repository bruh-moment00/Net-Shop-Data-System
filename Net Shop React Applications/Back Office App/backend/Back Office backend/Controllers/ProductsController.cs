using Back_Office_backend.Context;
using Back_Office_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Office_backend.Paging;
using Back_Office_backend.Models.QueryModels;

namespace Back_Office_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NetStoreDBContext _context;

        public ProductsController(NetStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<PaginationModel<ProductGetManyResponse>> GetProducts(string search, int pageNumber = 1, int pageSize = 10) 
        {
            if (search != null)
            {
                var query = from product in _context.Products
                            join brand in _context.Brands on product.BrandId equals brand.Id
                            join category in _context.Categories on product.CategoryId equals category.Id
                            where product.Name.Contains(search) || brand.Brand1.Contains(search)
                            select new ProductGetManyResponse
                            {
                                Id = product.Id,
                                Category = category.Name,
                                Brand = brand.Brand1,
                                Name = product.Name,
                                Price = product.Price,
                                Image = product.ImagePath
                            };

                return PaginationModel<ProductGetManyResponse>.GetPagedModel(query, pageNumber, pageSize);
            }
            else
            {
                var query = from product in _context.Products
                            join brand in _context.Brands on product.BrandId equals brand.Id
                            join category in _context.Categories on product.CategoryId equals category.Id
                            select new ProductGetManyResponse
                            {
                                Id = product.Id,
                                Category = category.Name,
                                Brand = brand.Brand1,
                                Name = product.Name,
                                Price = product.Price,
                                Image = product.ImagePath
                            };

                return PaginationModel<ProductGetManyResponse>.GetPagedModel(query, pageNumber, pageSize); 
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetSingleResponse>> GetProduct(int id)
        {
            var product = await _context.Products.Select(p => new ProductGetSingleResponse
            {
                Id = p.Id,
                Category = p.Category,
                Brand = p.Brand,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Specs = p.SpecsString,
                Image = p.ImagePath
            }).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
