# PaparaBootcamp

WEEK 1
---------------
Project Overview🔎
-------------
This project provides a simple API for managing accounts, supporting basic CRUD operations. The API allows users to perform the following actions:

☑️Create, Read, Update, and Delete (CRUD) accounts.

☑️Partial Update to modify the account balance.

☑️List accounts filtered by the owner's name and sorted by balance.

☑️It also includes basic error handling middleware to manage unexpected errors gracefully.

Features🔑
-------------
☑️Account: Represents an account with properties such as account number, owner name, balance, and account type.

☑️AccountsController: Provides endpoints to manage accounts, including:

•Get all accounts.

•Get a specific account by ID or account number.

•Create, update, and delete accounts.

•Partial update to modify the balance.

•List accounts with filtering and sorting options.

☑️Error Handling: A middleware to catch unhandled exceptions and return an appropriate error response.

Technologies🖥️
-------------
.NET 6 or later

ASP.NET Core Web API

API Endpoints🎯
-------------
1. Get All Accounts📌

Endpoint: GET /api/accounts/GetAll

Retrieves all accounts.

Response: A list of all accounts in the system.

2. Get Account by ID📌

Endpoint: GET /api/accounts/GetById/{id}

Retrieves a single account by its ID.

Parameters:

•id: The ID of the account.

Response: The account details, or a 404 error if not found.

3. Create Account📌

Endpoint: POST /api/accounts

Creates a new account.

Request Body:
```json
{
  "AccountNumber": "1234567890",
  "OwnerName": "John Doe",
  "Balance": 5000.00,
  "AccountType": "Checking"
}
```
Response: The newly created account.

4. Update Account📌

Endpoint: PUT /api/accounts/{id}

Updates an existing account.

Request Body:
```json
{
  "AccountNumber": "1234567890",
  "OwnerName": "Jane Doe",
  "Balance": 6000.00,
  "AccountType": "Savings"
}
```
Parameters:

•id: The ID of the account to update.

Response: The updated account.

5. Partial Update Account (Balance)📌

Endpoint: PATCH /api/accounts/{accountNumber}

Partially updates an account (only the balance in this case).

Request Body:
```json
{
  "Balance": 7000.00
}
```
Parameters:

•accountNumber: The account number of the account to update.

Response: The updated account.

6. Delete Account📌

Endpoint: DELETE /api/accounts/{id}

Deletes an account by its ID.

Parameters:

•id: The ID of the account to delete.

Response: No Content if successful, or a 404 error if not found.

7. List Accounts📌

Endpoint: GET /api/accounts/list

Lists accounts with optional filtering and sorting.

Query Parameters:

•name: Filters accounts by the owner's name.

•sortBy: Sorts the accounts (options: balance, balance_desc).

Response: A list of accounts matching the provided filters.

Error Handling⚙️
-------------
If an unexpected error occurs during any of the API requests, the ErrorHandlerMiddleware catches the exception and returns a 500 response with a JSON message.

WEEK 2
---------------------
🤖Fake User Authentication API
----------------------------
This project is a simple .NET API with a fake authentication system, custom authorization attribute, and global exception middleware. The API allows managing accounts and ensures that only authorized users can access certain endpoints.

✨Features
-----------------
• Fake user authentication using predefined tokens

• Custom authorization attribute to secure endpoints

• Global exception middleware for error handling

• CRUD operations for managing accounts

🖥️Technologies Used
-----------------
• .NET 8 Web API

• C#

• ASP.NET Core Middleware

🚩API Endpoints
-----------------
Authentication

The API uses a fake authentication service where users are identified by static tokens.

🔍Valid Tokens:

• Admin: admin-token

• User: user-token

📍Account Management
-----------------
![Ekran görüntüsü 2025-03-17 211101](https://github.com/user-attachments/assets/45b68971-5818-43a4-8b6e-b3a1844ad0f9)

🎯Code Overview
-----------------
⚙️Fake Authentication Service

![Ekran görüntüsü 2025-03-17 211405](https://github.com/user-attachments/assets/b23882e2-eab7-4600-90d5-458d62465f76)

📚Custom Authorization Attribute

![Ekran görüntüsü 2025-03-17 211302](https://github.com/user-attachments/assets/551de5ed-8768-4f5b-b8fe-5f610db5af01)

🛠️Global Exception Middleware and Global Logging

![Ekran görüntüsü 2025-03-17 211457](https://github.com/user-attachments/assets/4a8a4de6-77dc-4ff8-857d-7f97f123d69e)

![Ekran görüntüsü 2025-03-17 211503](https://github.com/user-attachments/assets/b7a1046e-36d4-40df-ac31-26e2467f552b)

Example Output
-----------------
✅Swagger

![Ekran görüntüsü 2025-03-17 205549](https://github.com/user-attachments/assets/c238db46-fce3-4736-a463-e1e7336c824f)

🚀Postman

GetAll

![Ekran görüntüsü 2025-03-17 205401](https://github.com/user-attachments/assets/48ee5af0-ab75-42ab-a027-a22c833a1d8e)

Post

![Ekran görüntüsü 2025-03-17 205527](https://github.com/user-attachments/assets/5b748d1c-3341-4f4f-9a99-e3cc6b1f80f6)

WEEK 3-1
--------------------

Project Screenshots

📍GetAllBooks

![Ekran görüntüsü 2025-03-20 153945](https://github.com/user-attachments/assets/b4ffaecd-6036-4068-9bb2-8d32f1951c50)

📍GetByIdBook

![Ekran görüntüsü 2025-03-20 153938](https://github.com/user-attachments/assets/20793fb5-fb63-40b2-b426-1e0dc62db146)

📍Post

![Ekran görüntüsü 2025-03-20 153844](https://github.com/user-attachments/assets/e6c3a228-54c3-448f-ae4a-144328d416f2)

📍Put (changed Title, GenreId and PageCount)

![Ekran görüntüsü 2025-03-20 153910](https://github.com/user-attachments/assets/197ac7b4-ba95-444e-8491-ca513b0a8a87)

📍Delete

![Ekran görüntüsü 2025-03-20 153928](https://github.com/user-attachments/assets/5ed09b43-3f21-4bcf-99f3-38bd7c54a96c)

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
