Week 3-2
--------------------

🚀Assignment Week 3-1 has been modified

🎯Added Fluent Validation and AutoMapper

✨Changes

📌CreateBookCommand

➡️Before

```csharp
public class CreateBookCommand
	{
		public CreateBookDto createBookDto { get; set; } // DTO (Data Transfer Object) that contains book details
		private readonly BookDbContext dbContext;
		public CreateBookCommand(BookDbContext _dbContext)
		{
			dbContext = _dbContext;
		}

		public void Handle()
		{
			// Check if a book with the same title already exists
			var book = dbContext.Books.SingleOrDefault(x => x.Title == createBookDto.Title);

			if (book is not null)
			{
				throw new InvalidOperationException("The book already exists"); // Throw an error if the book exists
			}
			book = new Book();
			book.Title = createBookDto.Title;
			book.PublishDate = createBookDto.PublishDate;
			book.PageCount = createBookDto.PageCount;
			book.GenreId = createBookDto.GenreId;

			dbContext.Books.Add(book);
			dbContext.SaveChanges();
		}
	}
```

✅After

```csharp
public class CreateBookCommand
	{
		public CreateBookDto createBookDto { get; set; } // DTO (Data Transfer Object) that contains book details
		private readonly BookDbContext dbContext;
		private readonly IMapper _mapper;
		public CreateBookCommand(BookDbContext _dbContext, IMapper mapper)
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
```

📌GetByIdBookQuery

➡️Before

```csharp
public class GetByIdBookQuery
	{
		private readonly BookDbContext _dbContext;

		// Property to store the requested book's ID
		public int BookId { get; set; }
		public GetByIdBookQuery(BookDbContext dbContext, int bookId)
		{
			_dbContext = dbContext;
			BookId = bookId;
		}

		// Method to retrieve a book by its ID
		public GetByIdBookDto Handle()
		{
			// Fetch the book with the given ID from the database
			var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();

			// Create a DTO object to store the retrieved book details
			GetByIdBookDto Model = new GetByIdBookDto();

			// Map the book entity's properties to the DTO
			Model.Title = book.Title;
			Model.PageCount = book.PageCount;
			Model.PublishDate = book.PublishDate;
			Model.Genre = ((GenreEnum)book.GenreId).ToString(); // Convert GenreId to Enum and then to string

			return Model;
		}
	}
```

✅After

```csharp
public class GetByIdBookQuery
	{
		private readonly BookDbContext _dbContext;

		private readonly IMapper _mapper;

		// Property to store the requested book's ID
		public int BookId { get; set; }
		public GetByIdBookQuery(BookDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		// Method to retrieve a book by its ID
		public GetByIdBookDto Handle()
		{
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
			if (book is null)
			{
				throw new InvalidOperationException("Kitap mevcut değil");
			}
			var model = _mapper.Map<GetByIdBookDto>(book);
			return model;
		}
	}
```

📌BooksController

➡️Before

```csharp
[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly BookDbContext _context;

		// Constructor to initialize the database context
		public BooksController(BookDbContext context)
		{
			_context = context;
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
			GetByIdBookQuery query = new GetByIdBookQuery(_context, id);
			var result = query.Handle();
			return Ok(result);
		}

		// POST: api/books
		// Adds a new book to the database
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

		// PUT: api/books/{id}
		// Updates an existing book by its ID
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

		// DELETE: api/books/{id}
		// Deletes a book by its ID
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
```

✅After

```csharp
[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly BookDbContext _context;
		private readonly IMapper _mapper;

		// Constructor to initialize the database context
		public BooksController(BookDbContext context, IMapper mapper)
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
		public IActionResult AddBook([FromBody]CreateBookDto model)
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
		public IActionResult UpdateBook(int id, [FromBody]UpdateBookDto updatedBook)
		{
			UpdateBookCommand command = new UpdateBookCommand(_context);
			try
			{
				command.BookId = id;
				command.Model = updatedBook;
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
```

⭐Newly added

📌CreateBookCommandValidator

```csharp
public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
	{
		public CreateBookCommandValidator()
		{
			RuleFor(command => command.createBookDto.GenreId).GreaterThan(0);
			RuleFor(command => command.createBookDto.PageCount).GreaterThan(0);
			RuleFor(command => command.createBookDto.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
			RuleFor(command => command.createBookDto.Title).NotEmpty().MinimumLength(2);
		}
	}
```

📌DeleteBookCommandValidator

```csharp
public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
	{
		public DeleteBookCommandValidator()
		{
			RuleFor(command => command.BookId).GreaterThan(0);

		}
	}
```

📌GetByIdBookQueryValidator

```csharp
public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
	{
		public GetByIdBookQueryValidator()
		{
			RuleFor(query => query.BookId).GreaterThan(0);
		}
	}
```

📌UpdateBookCommandValidator

```csharp
public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
	{
		public UpdateBookCommandValidator()
		{
			RuleFor(command => command.BookId).GreaterThan(0);
			RuleFor(command => command.Model.GenreId).GreaterThan(0);
			RuleFor(command => command.Model.PageCount).GreaterThan(0);
			RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
			RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);

		}
	}
```
