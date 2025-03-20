using PaparaBootcamp.Week3._1.Context;
using PaparaBootcamp.Week3._1.Dto;

namespace PaparaBootcamp.Week3._1.Features.Update
{
	public class UpdateBookCommand
	{
		public UpdateBookDto Model { get; set; }
		private readonly BookDbContext _dbContext;
		public UpdateBookCommand(BookDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle(int id)
		{
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
			if (book is null)
			{
				throw new InvalidOperationException("Book not found");
			}
			book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
			book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
			book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
			book.Title = Model.Title != default ? Model.Title : book.Title;

			_dbContext.SaveChanges();
		}
	}
}
