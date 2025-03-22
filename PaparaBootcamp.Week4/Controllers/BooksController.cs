using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto;
using PaparaBootcamp.Week4.Features.Create;
using PaparaBootcamp.Week4.Features.Delete;
using PaparaBootcamp.Week4.Features.GetAll;
using PaparaBootcamp.Week4.Features.GetById;
using PaparaBootcamp.Week4.Features.Update;

namespace PaparaBootcamp.Week4.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		// Constructor to initialize the database context
		public BooksController(BookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/books
		// Retrieves all books from the database
		[HttpGet]
		public IActionResult GetBooks()
		{
			GetAllBooksQuery query = new GetAllBooksQuery(_context);
			var result = query.Handle();
			return Ok(result);
		}

		// GET: api/books/{id}
		// Retrieves a specific book by its ID
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			GetByIdBookQuery query = new GetByIdBookQuery(_context, _mapper);
			query.BookId = id;
			try
			{
				GetByIdBookQueryValidator validator = new GetByIdBookQueryValidator();
				validator.ValidateAndThrow(query);
				var result = query.Handle();
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// POST: api/books
		// Adds a new book to the database
		[HttpPost]
		public IActionResult AddBook([FromBody] CreateBookDto model)
		{
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			try
			{
				command.createBookDto = model;
				CreateBookCommandValidator validator = new CreateBookCommandValidator();
				validator.ValidateAndThrow(command);
				command.Handle();

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}

		// PUT: api/books/{id}
		// Updates an existing book by its ID
		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, [FromBody] UpdateBookDto updatedBook)
		{
			UpdateBookCommand command = new UpdateBookCommand(_context);
			try
			{
				command.BookId = id;
				command.updateBookDto = updatedBook;
				UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
				validator.ValidateAndThrow(command);
				command.Handle(id);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}

		// DELETE: api/books/{id}
		// Deletes a book by its ID
		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id)
		{
			DeleteBookCommand command = new DeleteBookCommand(_context);
			try
			{
				command.BookId = id;
				DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
				validator.ValidateAndThrow(command);
				command.Handle();

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}
	}
}
