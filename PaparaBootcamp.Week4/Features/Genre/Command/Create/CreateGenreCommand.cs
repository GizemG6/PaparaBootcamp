using AutoMapper;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Genre;

namespace PaparaBootcamp.Week4.Features.Genre.Command.Create
{
	public class CreateGenreCommand
	{
		public CreateGenreDto createGenreDto { get; set; }
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public CreateGenreCommand(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void Handle()
		{
			var genre = _dbContext.Genres.SingleOrDefault(s => s.Name == createGenreDto.Name);
			if (genre is not null)
			{
				throw new InvalidOperationException("Genre available");
			}

			genre = _mapper.Map<Entity.Genre>(createGenreDto);

			_dbContext.Genres.Add(genre);
			_dbContext.SaveChanges();
		}
	}
}
