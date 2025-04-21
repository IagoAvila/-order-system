using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Api.Data;
using OrderManagement.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpGet("{id}")]
public async Task<ActionResult<Customer>> GetCustomer(Guid id) // alterado para Guid
{
    var customer = await _context.Customers.FindAsync(id);

    if (customer == null)
        return NotFound();

    return customer;
}

[HttpPut("{id}")]
public async Task<IActionResult> PutCustomer(Guid id, Customer customer) // alterado para Guid
{
    if (id != customer.Id)
        return BadRequest();

    _context.Entry(customer).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    return NoContent();
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteCustomer(Guid id) // alterado para Guid
{
    var customer = await _context.Customers.FindAsync(id);

    if (customer == null)
        return NotFound();

    _context.Customers.Remove(customer);
    await _context.SaveChangesAsync();

    return NoContent();
}

    }
}
