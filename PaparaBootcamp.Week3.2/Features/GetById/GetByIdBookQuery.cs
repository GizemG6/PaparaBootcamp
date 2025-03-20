using AutoMapper;
using PaparaBootcamp.Week3._1.Common;
using PaparaBootcamp.Week3._1.Context;
using PaparaBootcamp.Week3._1.Dto;

namespace PaparaBootcamp.Week3._1.Features.GetById
{
	public class GetByIdBookQuery
	{
		private readonly BookDbContext _dbContext;

		private readonly IMapper _mapper;

		// Property to store the requested book's ID
		public int BookId { get; set; }
		public GetByIdBookQuery(BookDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		// Method to retrieve a book by its ID
		public GetByIdBookDto Handle()
		{
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
			if (book is null)
			{
				throw new InvalidOperationException("Kitap mevcut değil");
			}
			var model = _mapper.Map<GetByIdBookDto>(book);
			return model;
		}
	}
}
