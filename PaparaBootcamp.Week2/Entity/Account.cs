using System.ComponentModel.DataAnnotations;

namespace PaparaBootcamp.Week2.Entity
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
}
