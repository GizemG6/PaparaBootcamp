using PaparaBootcamp.Week3._1.Common;
using PaparaBootcamp.Week3._1.Context;
using PaparaBootcamp.Week3._1.Dto;

namespace PaparaBootcamp.Week3._1.Features.GetById
{
	public class GetByIdBookQuery
	{
		private readonly BookDbContext _dbContext;

		// Property to store the requested book's ID
		public int BookId { get; set; }
		public GetByIdBookQuery(BookDbContext dbContext, int bookId)
		{
			_dbContext = dbContext;
			BookId = bookId;
		}

		// Method to retrieve a book by its ID
		public GetByIdBookDto Handle()
		{
			// Fetch the book with the given ID from the database
			var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();

			// Create a DTO object to store the retrieved book details
			GetByIdBookDto Model = new GetByIdBookDto();

			// Map the book entity's properties to the DTO
			Model.Title = book.Title;
			Model.PageCount = book.PageCount;
			Model.PublishDate = book.PublishDate;
			Model.Genre = ((GenreEnum)book.GenreId).ToString(); // Convert GenreId to Enum and then to string

			return Model;
		}
	}
}
