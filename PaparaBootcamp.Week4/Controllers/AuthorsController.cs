using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Author;
using PaparaBootcamp.Week4.Features.Author.Command.Create;
using PaparaBootcamp.Week4.Features.Author.Command.Delete;
using PaparaBootcamp.Week4.Features.Author.Command.Update;
using PaparaBootcamp.Week4.Features.Author.Query.GetAll;
using PaparaBootcamp.Week4.Features.Author.Query.GetById;
using PaparaBootcamp.Week4.Features.Command.Create;

namespace PaparaBootcamp.Week4.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public AuthorsController(BookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAuthors()
		{
			GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
			return Ok(query.Handle());
		}

		[HttpGet("{id}")]
		public IActionResult GetAuthorById(int id)
		{
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);

			GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
			validator.ValidateAndThrow(query);

			query.AuthorId = id;

			return Ok(query.Handle());
		}

		[HttpPost]
		public IActionResult CreateAuthor([FromBody]CreateAuthorDto newAuthor)
		{
			CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);

			command._createAuthorDto = newAuthor;

			CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();

			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateAuthor(int id, [FromBody]UpdateAuthorDto updatedAuthor)
		{
			UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);

			command.AuthorId = id;
			command.updateAuthorDto = updatedAuthor;

			UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteAuthor(int id)
		{
			DeleteAuthorCommand command = new DeleteAuthorCommand(_context);

			command.AuthorId = id;
			command.Handle();

			return Ok();
		}
	}
}
