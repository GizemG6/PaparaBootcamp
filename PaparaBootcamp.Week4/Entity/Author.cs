﻿namespace PaparaBootcamp.Week4.Entity
{
	public class Author
	{
		public int Id { get; set; }
		public string FirstName { get; set; } 
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }

		public ICollection<Book> Books { get; set; }
	}
}
