using AutoMapper;
using PaparaBootcamp.Week4.Context;
using PaparaBootcamp.Week4.Dto.Author;
using PaparaBootcamp.Week4.Entity;

namespace PaparaBootcamp.Week4.Features.Author.Command.Update
{
	public class UpdateAuthorCommand
	{
		public UpdateAuthorDto updateAuthorDto { get; set; }
		private readonly IMapper _mapper;
		public int AuthorId { get; set; }
		readonly BookStoreDbContext _dbContext;

		public UpdateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void Handle()
		{
			var author = _dbContext.Authors.SingleOrDefault(s => s.Id == AuthorId);

			if (author is null)
			{
				throw new InvalidOperationException("Author is available.");
			}

			author.FirstName = updateAuthorDto.FirstName;
			author.LastName = updateAuthorDto.LastName;
			author.DateOfBirth = updateAuthorDto.DateOfBirth;

			_dbContext.Authors.Update(author);

			if (updateAuthorDto.Books?.Count() > 0 && updateAuthorDto.Books != null)
			{
				var booksToBeAdded = new List<Book>();
				foreach (var item in updateAuthorDto.Books)
				{
					try
					{
						var bookCheck = _dbContext.Books.FirstOrDefault(
							s => s.Title.ToLower() == item.Title.ToLower() || s.Id == item.Id
						);
						if (bookCheck != null)
						{
							booksToBeAdded.Add(bookCheck);
						}
						else
						{
							bookCheck = _mapper.Map<Book>(item);
							booksToBeAdded.Add(bookCheck);
						}
					}
					catch (Exception ex)
					{
						throw new Exception();
					}
				}
			}
			var isAdded = _dbContext.SaveChanges();
		}
	}
}
