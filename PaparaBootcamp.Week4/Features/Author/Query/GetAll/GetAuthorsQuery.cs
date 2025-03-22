using AutoMapper;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Author;

namespace PaparaBootcamp.Week4.Features.Author.Query.GetAll
{
	public class GetAuthorsQuery
	{
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public List<AuthorsBooksDto> Handle()
		{
			var authorList = _dbContext.Authors.OrderBy(a => a.Id).ToList();

			List<AuthorsBooksDto> viewModel = _mapper.Map<List<AuthorsBooksDto>>(authorList);

			return viewModel;
		}
	}
}
