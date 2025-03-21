﻿using PaparaBootcamp.Week4.Context;

namespace PaparaBootcamp.Week4.Features.Delete
{
	public class DeleteBookCommand
	{
		private readonly BookStoreDbContext _dbContext;
		public int BookId { get; set; }

		public DeleteBookCommand(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void Handle()
		{
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
			if (book is null)
			{
				throw new InvalidOperationException("The book is not available");
			}
			_dbContext.Books.Remove(book);
		}
	}
}
