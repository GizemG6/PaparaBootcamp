using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto;

namespace PaparaBootcamp.Week4.Features.Update
{
	public class UpdateBookCommand
	{
		// Property to store the book details to be updated
		public UpdateBookDto updateBookDto { get; set; }

		// Database context to interact with the database
		private readonly BookStoreDbContext _dbContext;

		public int BookId { get; set; }
		public UpdateBookCommand(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// Method to handle the update operation for a book
		public void Handle(int id)
		{
			// Retrieve the book by its ID from the database
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);

			// If the book is not found, throw an exception
			if (book is null)
			{
				throw new InvalidOperationException("Book not found");
			}

			// Update the book's properties only if the new value is not the default value
			book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
			book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
			book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
			book.Title = Model.Title != default ? Model.Title : book.Title;

			_dbContext.SaveChanges();
		}
	}
}
