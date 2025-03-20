namespace PaparaBootcamp.Week3._1.Dto
{
	public class CreateBookDto
	{
		public string Title { get; set; }
		public int GenreId { get; set; }
		public int PageCount { get; set; }
		public DateTime PublishDate { get; set; }
	}
}
