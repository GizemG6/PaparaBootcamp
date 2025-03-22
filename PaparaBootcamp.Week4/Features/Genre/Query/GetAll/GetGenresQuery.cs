using AutoMapper;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Genre;

namespace PaparaBootcamp.Week4.Features.Genre.Query.GetAll
{
	public class GetGenresQuery
	{
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetGenresQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public List<GenresDto> Handle()
		{
			var genreList = _dbContext.Genres.Where(g => g.IsActive == true).OrderBy(g => g.Id).ToList();
			List<GenresDto> genresDtos = _mapper.Map<List<GenresDto>>(genreList);

			return genresDtos;
		}
	}
}
