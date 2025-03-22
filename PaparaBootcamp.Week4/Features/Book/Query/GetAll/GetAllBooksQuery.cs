using PaparaBootcamp.Week4.Common;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto;
using PaparaBootcamp.Week4.Entity;
using System.Linq;

namespace PaparaBootcamp.Week4.Features.GetAll
{
	public class GetAllBooksQuery
	{
		private readonly BookStoreDbContext _dbContext;

		public GetAllBooksQuery(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// Method to retrieve all books from the database
		public List<GetAllBooksDto> Handle()
		{
			// Retrieve all books from the database and order them by ID
			var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();

			// List to store DTOs of retrieved books
			List<GetAllBooksDto> getAllBooksDtos = new List<GetAllBooksDto>();

			// Convert each Book entity into GetAllBooksDto and add to the list
			foreach (var book in bookList)
			{
				getAllBooksDtos.Add(new GetAllBooksDto()
				{
					Title = book.Title,
					Genre = ((GenreEnum)book.GenreId).ToString(), // Convert GenreId to Enum and then to string
					PublishDate = book.PublishDate,
					PageCount = book.PageCount
				});
			}

			return getAllBooksDtos;
		}
	}
}
