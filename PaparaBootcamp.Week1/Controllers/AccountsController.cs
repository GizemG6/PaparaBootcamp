using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PaparaBootcamp.Week1.Controllers
{
	public class Account
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[RegularExpression(@"^\d{10,15}$", ErrorMessage = "Account Number must be between 10 and 15 digits")]
		public string AccountNumber { get; set; } 

		[Required]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 10 characters")]
		public string OwnerName { get; set; } // Account holder name

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive value")]
		public decimal Balance { get; set; } // Account balance

		[Required]
		public string AccountType { get; set; } = "Checking"; // Account type (Checking, Savings)
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Account creation date
	}

	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private static List<Account> accounts = new List<Account>
		{
			new Account { Id = 1, AccountNumber = "1234567890", OwnerName = "Gizem Güneş", Balance = 1500.50m, AccountType = "Checking" },
			new Account { Id = 2, AccountNumber = "1234567891", OwnerName = "Lorem Ipsum", Balance = 32000.70m, AccountType = "Savings" },
			new Account { Id = 3, AccountNumber = "1234567892", OwnerName = "Name Surname", Balance = 7800.20m, AccountType = "Checking" },
			new Account { Id = 4, AccountNumber = "1234567893", OwnerName = "Gizem Güneş", Balance = 99300.40m, AccountType = "Savings" },
		};

		public class AccountUpdateDTO // To update the balance in the patch
		{
			[Required]
			public decimal Balance { get; set; }
		}

		// Get all accounts
		[HttpGet("GetAll")]
		public IActionResult Get()
		{
			return Ok(accounts);
		}

		// Get account by id
		[HttpGet("GetById/{id}")]
		public IActionResult GetById([FromRoute] int id)
		{
			var account = accounts.FirstOrDefault(a => a.Id == id);
			if (account == null)
				return NotFound(new { message = "Account not found" });

			return Ok(account);
		}

		[HttpPost("Post")]
		public IActionResult Post([FromBody]Account account)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			account.Id = accounts.Count > 0 ? accounts.Max(a => a.Id) + 1 : 1;
			accounts.Add(account);
			return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
		}

		[HttpPut("{id}")]
		public IActionResult Put([FromRoute]int id, [FromBody] Account updatedAccount)
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
		public IActionResult PartialUpdate(string accountNumber, [FromBody]AccountUpdateDTO updates)
		{
			var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
			if (account == null)
				return NotFound(new { message = "Account not found" });
			
			if (updates.Balance != 0) 
				account.Balance = updates.Balance;

			return Ok(account);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete([FromRoute] int id)
		{
			var account = accounts.FirstOrDefault(a => a.Id == id);
			if (account == null)
				return NotFound(new { message = "Account not found" });

			accounts.Remove(account);
			return NoContent();
		}

		[HttpGet("list")]
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
