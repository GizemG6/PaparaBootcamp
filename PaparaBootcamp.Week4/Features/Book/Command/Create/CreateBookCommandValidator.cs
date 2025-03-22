using FluentValidation;

namespace PaparaBootcamp.Week4.Features.Create
{
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
}
