using FluentValidation;

namespace PaparaBootcamp.Week3._2.Features.Delete
{
	public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
	{
		public DeleteBookCommandValidator()
		{
			RuleFor(command => command.BookId).GreaterThan(0);

		}
	}
}
