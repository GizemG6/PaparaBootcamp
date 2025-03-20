using PaparaBootcamp.Week3._1.Common;
using PaparaBootcamp.Week3._1.Context;
using PaparaBootcamp.Week3._1.Dto;

namespace PaparaBootcamp.Week3._1.Features.GetById
{
	public class GetByIdBookQuery
	{
		private readonly BookDbContext _dbContext;
		public int BookId { get; set; }
		public GetByIdBookQuery(BookDbContext dbContext, int bookId)
		{
			_dbContext = dbContext;
			BookId = bookId;
		}

		public GetByIdBookDto Handle()
		{
			var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
			GetByIdBookDto Model = new GetByIdBookDto();

			Model.Title = book.Title;
			Model.PageCount = book.PageCount;
			Model.PublishDate = book.PublishDate;
			Model.Genre = ((GenreEnum)book.GenreId).ToString();

			return Model;
		}
	}
}
