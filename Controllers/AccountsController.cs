using ERPSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPSystem.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize]
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
		public IActionResult Post([FromBody] AccountDto account)
		{
			Account newAccount = new Account()
			{
				AccountName = account.AccountName
			};
			_context.Accounts.Add(newAccount);
			_context.SaveChanges();
			return Ok();
		}

		// PUT api/accounts/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] AccountDto updatedAccount)
		{
			var account = _context.Accounts.FirstOrDefault(a => a.AccountId == id);
			if (account == null)
			{
				return NotFound();
			}
			try
			{
				account.AccountName = updatedAccount.AccountName;
				_context.Update(account);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				return BadRequest("An error occurred while updating the account.");
			}
			
			return Ok(account);
		}

		// DELETE api/<AccountsController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (_context.Accounts == null)
			{
				return NotFound();
			}
			var account = _context.Accounts.FirstOrDefault(_ => _.AccountId == id);
			if (account == null)
			{
				return NotFound();
			}
			_context.Accounts.Remove(account);
			_context.SaveChanges();
			return Ok();
		}
	}
}
