using FluentValidation;

namespace PaparaBootcamp.Week4.Features.Delete
{
	public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
	{
		public DeleteBookCommandValidator()
		{
			RuleFor(command => command.BookId).GreaterThan(0);

		}
	}
}
