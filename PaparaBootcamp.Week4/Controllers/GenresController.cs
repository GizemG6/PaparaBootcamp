using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Genre;
using PaparaBootcamp.Week4.Features.Genre.Command.Create;
using PaparaBootcamp.Week4.Features.Genre.Command.Delete;
using PaparaBootcamp.Week4.Features.Genre.Command.Update;
using PaparaBootcamp.Week4.Features.Genre.Query.GetAll;
using PaparaBootcamp.Week4.Features.Genre.Query.GetDetail;

namespace PaparaBootcamp.Week4.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenresController : ControllerBase
	{
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public GenresController(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetGenres()
		{
			GetGenresQuery query = new GetGenresQuery(_dbContext, _mapper);
			return Ok(query.Handle());
		}

		[HttpGet("{id}")]
		public IActionResult GetGenreById(int id)
		{
			GetGenreDetailQuery query = new GetGenreDetailQuery(_dbContext, _mapper);
			query.GenreId = id;

			GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
			validator.ValidateAndThrow(query);

			return Ok(query.Handle());
		}

		[HttpPost]
		public IActionResult AddGenre([FromBody]CreateGenreDto newGenre)
		{
			CreateGenreCommand command = new CreateGenreCommand(_dbContext, _mapper);
			command.createGenreDto = newGenre;

			CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();

			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateGenre(int id, [FromBody]UpdateGenreDto updatedGenre)
		{
			UpdateGenreCommand command = new UpdateGenreCommand(_dbContext, _mapper);

			command.GenreId = id;
			command.updateGenreDto = updatedGenre;

			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult RemoveGenre(int id)
		{
			DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);

			command.GenreId = id;
			command.Handle();

			return Ok();
		}
	}
}
