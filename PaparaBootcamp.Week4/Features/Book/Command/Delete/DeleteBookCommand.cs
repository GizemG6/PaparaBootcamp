using PaparaBootcamp.Week3._1.Context;

namespace PaparaBootcamp.Week3._2.Features.Delete
{
	public class DeleteBookCommand
	{
		private readonly BookDbContext _dbContext;
		public int BookId { get; set; }

		public DeleteBookCommand(BookDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void Handle()
		{
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == bookId);
			if (book is null)
			{
				throw new InvalidOperationException("The book is not available");
			}
			_dbContext.Books.Remove(book);
		}
	}
}
