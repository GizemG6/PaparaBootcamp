using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcamp.Week3._1.Context;
using PaparaBootcamp.Week3._1.Dto;
using PaparaBootcamp.Week3._1.Features.Create;
using PaparaBootcamp.Week3._1.Features.GetAll;
using PaparaBootcamp.Week3._1.Features.GetById;
using PaparaBootcamp.Week3._1.Features.Update;

namespace PaparaBootcamp.Week3._1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly BookDbContext _context;

		public BooksController(BookDbContext context)
		{
			_context = context;
		}

		//Http requestleri yakalayacak metotlar

		[HttpGet]
		public IActionResult GetBooks()
		{
			GetAllBooksQuery query = new GetAllBooksQuery(_context);
			var result = query.Handle();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			GetByIdBookQuery query = new GetByIdBookQuery(_context, id);
			var result = query.Handle();
			return Ok(result);
		}

		[HttpPost]
		public IActionResult AddBook([FromBody]CreateBookDto model)
		{
			CreateBookCommand command = new CreateBookCommand(_context);
			try
			{
				command.createBookDto = model;
				command.Handle();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, [FromBody]UpdateBookDto updatedBook)
		{
			UpdateBookCommand command = new UpdateBookCommand(_context);
			try
			{
				command.Model = updatedBook;
				command.Handle(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id)
		{
			var book = _context.Books.SingleOrDefault(x => x.Id == id);
			if (book is null)
			{
				return BadRequest();
			}
			_context.Books.Remove(book);
			_context.SaveChanges();
			return Ok();
		}
	}
}
