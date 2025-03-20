using PaparaBootcamp.Week3._1.Common;
using PaparaBootcamp.Week3._1.Context;
using PaparaBootcamp.Week3._1.Dto;
using PaparaBootcamp.Week3._1.Entity;
using System.Linq;

namespace PaparaBootcamp.Week3._1.Features.GetAll
{
	public class GetAllBooksQuery
	{
		private readonly BookDbContext _dbContext;

		public GetAllBooksQuery(BookDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<GetAllBooksDto> Handle()
		{
			var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
			List<GetAllBooksDto> getAllBooksDtos = new List<GetAllBooksDto>();
			foreach (var book in bookList)
			{
				getAllBooksDtos.Add(new GetAllBooksDto()
				{
					Title = book.Title,
					Genre = ((GenreEnum)book.GenreId).ToString(),
					PublishDate = book.PublishDate,
					PageCount = book.PageCount
				});
			}
			return getAllBooksDtos;
		}
	}
}
