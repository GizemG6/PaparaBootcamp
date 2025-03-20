using PaparaBootcamp.Week3._1.Common;
using System.ComponentModel.DataAnnotations;

namespace PaparaBootcamp.Week3._1.Entity
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public int GenreId { get; set; }
		public int PageCount { get; set; }
		public DateTime PublishDate { get; set; }
	}
}
