using FluentValidation;
using PaparaBootcamp.Week3._1.Features.Create;

namespace PaparaBootcamp.Week3._2.Features.Create
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
