using FluentValidation;

namespace PaparaBootcamp.Week4.Features.Author.Command.Delete
{
	public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
	{
		public DeleteAuthorCommandValidator()
		{
			RuleFor(command => command.AuthorId).GreaterThan(0);
		}
	}
}
