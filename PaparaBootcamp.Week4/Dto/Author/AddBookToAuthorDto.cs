namespace PaparaBootcamp.Week4.Dto.Author
{
	public class AddBookToAuthorDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int GenreId { get; set; }
		public int PageCount { get; set; }
		public DateTime PublishDate { get; set; }
	}
}
