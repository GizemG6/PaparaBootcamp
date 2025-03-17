using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcamp.Week2.Authorize;
using PaparaBootcamp.Week2.Dto;
using PaparaBootcamp.Week2.Entity;

namespace PaparaBootcamp.Week2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		// static list for account
		private static List<Account> accounts = new List<Account>
		{
			new Account { Id = 1, AccountNumber = "1234567890", OwnerName = "Gizem Güneş", Balance = 1500.50m, AccountType = "Checking" },
			new Account { Id = 2, AccountNumber = "1234567891", OwnerName = "Lorem Ipsum", Balance = 32000.70m, AccountType = "Savings" },
			new Account { Id = 3, AccountNumber = "1234567892", OwnerName = "Name Surname", Balance = 7800.20m, AccountType = "Checking" },
			new Account { Id = 4, AccountNumber = "1234567893", OwnerName = "Gizem Güneş", Balance = 99300.40m, AccountType = "Savings" },
		};

		// Get all accounts
		[HttpGet("GetAll")]
		[FakeAuthorize]
		public IActionResult Get()
		{
			return Ok(accounts);
		}

		// Get account by id
		[HttpGet("GetById/{id}")]
		[FakeAuthorize]
		public IActionResult GetById([FromRoute] int id)
		{
			var account = accounts.FirstOrDefault(a => a.Id == id);
			if (account == null)
				return NotFound(new { message = "Account not found" });

			return Ok(account);
		}

		[HttpPost("Post")]
		[FakeAuthorize]
		public IActionResult Post([FromBody] Account account)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			account.Id = accounts.Count > 0 ? accounts.Max(a => a.Id) + 1 : 1;
			accounts.Add(account);
			return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
		}

		[HttpPut("{id}")]
		[FakeAuthorize]
		public IActionResult Put([FromRoute] int id, [FromBody] Account updatedAccount)
		{
			var account = accounts.FirstOrDefault(a => a.Id == id);
			if (account == null)
				return NotFound(new { message = "Account not found" });

			account.AccountNumber = updatedAccount.AccountNumber;
			account.OwnerName = updatedAccount.OwnerName;
			account.Balance = updatedAccount.Balance;
			account.AccountType = updatedAccount.AccountType;

			return Ok(account);
		}

		[HttpPatch("{accountNumber}")]
		[FakeAuthorize]
		public IActionResult PartialUpdate(string accountNumber, [FromBody] AccountUpdateDto updates)
		{
			var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
			if (account == null)
				return NotFound(new { message = "Account not found" });

			if (updates.Balance != 0)
				account.Balance = updates.Balance;

			return Ok(account);
		}

		[HttpDelete("{id}")]
		[FakeAuthorize]
		public IActionResult Delete([FromRoute] int id)
		{
			var account = accounts.FirstOrDefault(a => a.Id == id);
			if (account == null)
				return NotFound(new { message = "Account not found" });

			accounts.Remove(account);
			return NoContent();
		}

		[HttpGet("list")]
		[FakeAuthorize]
		public IActionResult List([FromQuery] string name, [FromQuery] string sortBy)
		{
			// Start with the entire list of accounts as a queryable collection
			var result = accounts.AsQueryable();

			// Filter the accounts by 'name' if it's provided in the query string
			if (!string.IsNullOrEmpty(name))
				result = result.Where(a => a.OwnerName.Contains(name));

			// Apply sorting based on the 'sortBy' query parameter
			if (sortBy == "balance")
				result = result.OrderBy(a => a.Balance); // Sort by balance in ascending order
			else if (sortBy == "balance_desc")
				result = result.OrderByDescending(a => a.Balance); // Sort by balance in descending order

			return Ok(result.ToList());
		}
	}
}
