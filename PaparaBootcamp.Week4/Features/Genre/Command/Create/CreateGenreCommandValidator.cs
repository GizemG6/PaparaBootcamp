using FluentValidation;

namespace PaparaBootcamp.Week4.Features.Genre.Command.Create
{
	public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
	{
		public CreateGenreCommandValidator()
		{
			RuleFor(command => command.createGenreDto.Name).NotNull().MinimumLength(3);
		}
	}
}
