using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Author;
using PaparaBootcamp.Week4.Entity;
using System;

namespace PaparaBootcamp.Week4.Features.Command.Create
{
	public class CreateAuthorCommand
	{
		public CreateAuthorDto _createAuthorDto { get; set; }
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void Handle()
		{
			var author = _dbContext.Authors.SingleOrDefault(s => s.FirstName == _createAuthorDto.FirstName && s.LastName == _createAuthorDto.LastName);
			if (author is not null)
			{
				throw new InvalidOperationException("Author available");
			}

			author = _mapper.Map<Entity.Author>(_createAuthorDto);
			_dbContext.Authors.Add(author);
			_dbContext.SaveChanges();
		}
	}
}
