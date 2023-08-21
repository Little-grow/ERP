using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace ERPSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly ErpContext _context;

        public EmployeesController(ErpContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            return Ok(_context.Employees.ToList());
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] EmployeeDto updatedEmployee)
        {
            var employee = _context.Employees.FirstOrDefault(a => a.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            try
            {
                //_context.Entry(employee).State = EntityState.Modified;
                employee.Name = updatedEmployee.Name;
                employee.NationalId = updatedEmployee.NationalId;
                employee.DateOfBirth = updatedEmployee.DateOfBirth;
                employee.AccountId = updatedEmployee.AccountId;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("An error occured while updating the employee.");
            }

            return Ok();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDto NewEmployee)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set is null.");
            }
            var employee = new Employee()
            {
                Name = NewEmployee.Name,
                NationalId = NewEmployee.NationalId,
                DateOfBirth = NewEmployee.DateOfBirth,
                AccountId = NewEmployee.AccountId
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
