using ERPSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ErpContext _context;

        public AccountsController(ErpContext context)
        {
            _context = context;
        }
        // GET: api/<AccountsController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _context.Accounts.ToList();
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.AccountId == id);
            return Ok(account);
        }

        // POST api/<AccountsController>
        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            _context.Accounts.Add(account);
            return Ok();
        }

        // PUT api/accounts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Account updatedAccount)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }
            account.AccountName = updatedAccount.AccountName;
            return NoContent();
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
