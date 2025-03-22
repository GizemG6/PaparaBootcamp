using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto;
using PaparaBootcamp.Week4.Entity;

namespace PaparaBootcamp.Week4.Features.Create
{
	public class CreateBookCommand
	{
		public CreateBookDto createBookDto { get; set; } // DTO (Data Transfer Object) that contains book details
		private readonly BookStoreDbContext dbContext;
		private readonly IMapper _mapper;
		public CreateBookCommand(BookStoreDbContext _dbContext, IMapper mapper)
		{
			dbContext = _dbContext;
			_mapper = mapper;
		}

		public void Handle()
		{
			var book = dbContext.Books.SingleOrDefault(x => x.Title == createBookDto.Title);
			if (book is not null)
			{
				throw new InvalidOperationException("Book available");
			}
			book = _mapper.Map<Book>(createBookDto);
			dbContext.Books.Add(book);
			dbContext.SaveChanges();
		}
	}
}
