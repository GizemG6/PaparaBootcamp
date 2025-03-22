using AutoMapper;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Genre;

namespace PaparaBootcamp.Week4.Features.Genre.Command.Update
{
	public class UpdateGenreCommand
	{
		public int GenreId { get; set; }
		public UpdateGenreDto updateGenreDto { get; set; }
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public UpdateGenreCommand(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void Handle()
		{
			var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);

			if (genre is null)
			{
				throw new InvalidOperationException("Id could not found!");
			}
			if (_dbContext.Genres.Any(genre => genre.Name.ToLower() == updateGenreDto.Name.ToLower() && genre.Id == GenreId))
			{
				throw new InvalidOperationException("Genre name or id is already existing.");
			}

			_mapper.Map(updateGenreDto, genre);

			_dbContext.SaveChanges();
		}
	}
}
