using Microsoft.EntityFrameworkCore;
using PaparaBootcamp.Week4.Entity;

namespace PaparaBootcamp.Week4.Context
{
	public class BookStoreDbContext : DbContext
	{
		public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>()
				.HasOne(b => b.Author)
				.WithMany(a => a.Books)
				.HasForeignKey(b => b.AuthorId)
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(modelBuilder);
		}
	}
}
