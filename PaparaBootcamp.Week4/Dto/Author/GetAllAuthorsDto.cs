namespace PaparaBootcamp.Week4.Dto.Author
{
	public class GetAllAuthorsDto
	{
		public int Id { get; set; }
		public string AuthorName { get; set; } = "";
		public string DateOfBirth { get; set; } = "";
		public List<AuthorsBooksDto>? Books { get; set; }
	}
}
