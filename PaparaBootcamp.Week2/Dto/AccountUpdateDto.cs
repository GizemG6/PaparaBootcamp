using System.ComponentModel.DataAnnotations;

namespace PaparaBootcamp.Week2.Dto
{
	public class AccountUpdateDto
	{
		[Required]
		public decimal Balance { get; set; }
	}
}
