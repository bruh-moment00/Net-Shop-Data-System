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
    public class UsersEmployeesController : ControllerBase
    {
        private readonly NetStoreDBContext _context;

        public UsersEmployeesController(NetStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/UsersEmployees
        [HttpGet]
        public ActionResult<PaginationModel<EmployeeGetManyResponse>> GetUsersEmployees(string search, int pageNumber = 1, int pageSize = 10)
        {
            if(search != null)
            {
                var query = from employee in _context.UsersEmployees
                            join role in _context.Roles on employee.Role equals role.Id
                            where employee.LastName.Contains(search) || employee.FirstName.Contains(search) || employee.SecondName.Contains(search) || employee.Phone.Contains(search)
                            select new EmployeeGetManyResponse
                            {
                                Id = employee.Id,
                                FullName = employee.LastName + " " + employee.FirstName + " " + employee.SecondName,
                                Phone = employee.Phone,
                                Role = role.Name
                            };
                return PaginationModel<EmployeeGetManyResponse>.GetPagedModel(query, pageNumber, pageSize);
            }
            else
            {
                var query = from employee in _context.UsersEmployees
                            join role in _context.Roles on employee.Role equals role.Id
                            select new EmployeeGetManyResponse
                            {
                                Id = employee.Id,
                                FullName = employee.LastName + " " + employee.FirstName + " " + employee.SecondName,
                                Phone = employee.Phone,
                                Role = role.Name
                            };
                return PaginationModel<EmployeeGetManyResponse>.GetPagedModel(query, pageNumber, pageSize);
            }
        }

        // GET: api/UsersEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeGetSingleResponse>> GetUsersEmployee(int id)
        {
            var usersEmployee = await _context.UsersEmployees.Select(e => new EmployeeGetSingleResponse
            {
                Id = e.Id,
                FirstName = e.FirstName,
                SecondName = e.SecondName,
                LastName = e.LastName,
                Phone = e.Phone,
                Role = e.RoleNavigation
            }).FirstOrDefaultAsync();

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
