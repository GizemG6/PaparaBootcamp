using Microsoft.EntityFrameworkCore;
using PaparaBootcamp.Week3._1.Entity;

namespace PaparaBootcamp.Week3._1.Context
{
	public class BookDbContext : DbContext
	{
		public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
		public DbSet<Book> Books { get; set; }
	}
}
