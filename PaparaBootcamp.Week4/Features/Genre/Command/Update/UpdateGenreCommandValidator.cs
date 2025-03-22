using FluentValidation;

namespace PaparaBootcamp.Week4.Features.Genre.Command.Update
{
	public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
	{
		public UpdateGenreCommandValidator()
		{
			RuleFor(command => command.GenreId).NotNull().GreaterThan(0);
			RuleFor(command => command.updateGenreDto.Name).NotNull().MinimumLength(3);
		}
	}
}
