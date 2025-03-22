WEEK 4🚀
----------------------------------
Project Overview✨
----------------
This project aims to enhance the book management system by adding an Author controller and ensuring proper entity relationships and validation mechanisms.

Features⭐
----------------
📚Book Management

✔️Add a book

✔️Update book details

✔️Delete a book

✔️List all books

✔️Get details of a specific book

✍Author Management

✔️Add an author

✔️Update author details

✔️Delete an author (Only if no published books are associated)

✔️List all authors

✔️Get details of a specific author

Entity Relationships
----------------
✔️A book can have only one author.

✔️An author cannot be deleted if they have a published book. The book must be deleted first.

DTO & AutoMapper💡
----------------
✔️Create models and DTOs for the Author entity.

✔️Ensure that controller methods do not use entities directly as input or output.

✔️Use AutoMapper for mapping entity models.

Validation🛠️
----------------
✔️Implement FluentValidation for the Author services.

✔️Define validation rules appropriately.

✔️Ensure meaningful error messages are thrown from services.

Technologies Used
----------------
🔺 .NET 8

🔺 Entity Framework Core

🔺 AutoMapper

🔺 FluentValidation

Setup & Run Instructions⚙️
----------------
🔴Clone the repository.

🔴Restore dependencies using dotnet restore.

🔴Apply database migrations using dotnet ef database update.

🔴Run the application with dotnet run.

🔴Use Swagger or Postman to test API endpoints.
