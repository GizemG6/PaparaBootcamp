using AutoMapper;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Author;

namespace PaparaBootcamp.Week4.Features.Author.Query.GetById
{
	public class GetAuthorDetailQuery
	{
		public int AuthorId { get; set; }
		readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public AuthorDetailDto Handle()
		{
			var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);

			if (author is null)
				throw new InvalidOperationException("ID is not correct!");

			AuthorDetailDto authorDetailDto = _mapper.Map<AuthorDetailDto>(author);


			return authorDetailDto;
		}
	}
}
