namespace PaparaBootcamp.Week4.Dto
{
	public class GetAllBooksDto
	{
		public string Title { get; set; }
		public int PageCount { get; set; }
		public DateTime PublishDate { get; set; }
		public string Genre { get; set; }
	}
}
