using PaparaBootcamp.Week4.Context;

namespace PaparaBootcamp.Week4.Features.Genre.Command.Delete
{
	public class DeleteGenreCommand
	{
		public int GenreId { get; set; }
		private readonly BookStoreDbContext _dbContext;

		public DeleteGenreCommand(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle()
		{
			var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);

			if (genre is null)
			{
				throw new InvalidOperationException("Genre is not avaible");
			}

			_dbContext.Genres.Remove(genre);
			_dbContext.SaveChanges();
		}
	}
}
