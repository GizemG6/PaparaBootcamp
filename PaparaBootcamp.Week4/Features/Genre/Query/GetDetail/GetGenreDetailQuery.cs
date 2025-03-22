using AutoMapper;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Genre;

namespace PaparaBootcamp.Week4.Features.Genre.Query.GetDetail
{
	public class GetGenreDetailQuery
	{
		public GenreDetailDto genreDetailDto { get; set; }
		public int GenreId { get; set; }
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetGenreDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public GenreDetailDto Handle()
		{
			var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);

			if (genre is null)
			{
				throw new InvalidOperationException("Genre is not avaible");
			}

			GenreDetailDto genreDetailDto = _mapper.Map<GenreDetailDto>(genre);

			return genreDetailDto;
		}
	}
}
