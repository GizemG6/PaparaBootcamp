using AutoMapper;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto;

namespace PaparaBootcamp.Week4.Features.GetById
{
	public class GetByIdBookQuery
	{
		private readonly BookStoreDbContext _dbContext;

		private readonly IMapper _mapper;

		// Property to store the requested book's ID
		public int BookId { get; set; }
		public GetByIdBookQuery(BookStoreDbContext dbContext, IMapper mapper)
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
