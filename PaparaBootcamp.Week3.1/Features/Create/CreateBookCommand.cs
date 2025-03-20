using PaparaBootcamp.Week3._1.Context;
using PaparaBootcamp.Week3._1.Dto;
using PaparaBootcamp.Week3._1.Entity;

namespace PaparaBootcamp.Week3._1.Features.Create
{
	public class CreateBookCommand
	{
		public CreateBookDto createBookDto { get; set; }
		private readonly BookDbContext dbContext;
		public CreateBookCommand(BookDbContext _dbContext)
		{
			dbContext = _dbContext;
		}

		public void Handle()
		{
			var book = dbContext.Books.SingleOrDefault(x => x.Title == createBookDto.Title);

			if (book is not null)
			{
				throw new InvalidOperationException("The book already exists");
			}
			book = new Book();
			book.Title = createBookDto.Title;
			book.PublishDate = createBookDto.PublishDate;
			book.PageCount = createBookDto.PageCount;
			book.GenreId = createBookDto.GenreId;

			dbContext.Books.Add(book);
			dbContext.SaveChanges();
		}
	}
}
