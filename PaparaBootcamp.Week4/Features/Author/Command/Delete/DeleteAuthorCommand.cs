using PaparaBootcamp.Week4.Context;

namespace PaparaBootcamp.Week4.Features.Author.Command.Delete
{
	public class DeleteAuthorCommand
	{
		public int AuthorId { get; set; }
		readonly BookStoreDbContext _dbContext;

		public DeleteAuthorCommand(BookStoreDbContext dbContext, int itemId)
		{
			_dbContext = dbContext;
		}

		public void Handle()
		{
			var author = _dbContext.Authors.SingleOrDefault(s => s.Id == AuthorId);
			if (author is null)
			{
				throw new InvalidOperationException("The author is not available");
			}

			var authorBooksCheck = (from ab in _dbContext.Books.Where(w => w.AuthorId == author.Id)
				from b in _dbContext.Books.Where(w => w.Id == ab.Id) select b).ToList();

			_dbContext.Remove(author);
			_dbContext.SaveChanges();
		}
	}
}
