using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcamp.Week4.Context;

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
	}
}
