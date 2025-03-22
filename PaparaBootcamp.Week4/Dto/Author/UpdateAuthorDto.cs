namespace PaparaBootcamp.Week4.Dto.Author
{
	public class UpdateAuthorDto
	{
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public DateTime DateOfBirth { get; set; }
		public List<AddBookToAuthorDto>? Books { get; set; }
	}
}
