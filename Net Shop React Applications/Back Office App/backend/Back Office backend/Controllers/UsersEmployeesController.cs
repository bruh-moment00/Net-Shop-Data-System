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
    public class UsersEmployeesController : ControllerBase
    {
        private readonly NetStoreDBContext _context;

        public UsersEmployeesController(NetStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/UsersEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersEmployee>>> GetUsersEmployees()
        {
            return await _context.UsersEmployees.ToListAsync();
        }

        // GET: api/UsersEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersEmployee>> GetUsersEmployee(int id)
        {
            var usersEmployee = await _context.UsersEmployees.FindAsync(id);

            if (usersEmployee == null)
            {
                return NotFound();
            }

            return usersEmployee;
        }

        // PUT: api/UsersEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersEmployee(int id, UsersEmployee usersEmployee)
        {
            if (id != usersEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersEmployeeExists(id))
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

        // POST: api/UsersEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersEmployee>> PostUsersEmployee(UsersEmployee usersEmployee)
        {
            _context.UsersEmployees.Add(usersEmployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersEmployeeExists(usersEmployee.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsersEmployee", new { id = usersEmployee.Id }, usersEmployee);
        }

        // DELETE: api/UsersEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersEmployee(int id)
        {
            var usersEmployee = await _context.UsersEmployees.FindAsync(id);
            if (usersEmployee == null)
            {
                return NotFound();
            }

            _context.UsersEmployees.Remove(usersEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersEmployeeExists(int id)
        {
            return _context.UsersEmployees.Any(e => e.Id == id);
        }
    }
}
