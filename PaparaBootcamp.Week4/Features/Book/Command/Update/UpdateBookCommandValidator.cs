using FluentValidation;
using PaparaBootcamp.Week4.Dto;
using PaparaBootcamp.Week4.Features.Update;

namespace PaparaBootcamp.Week4.Features.Update
{
	public class UpdateBookCommandValidator : AbstractValidator<UpdateBookDto>
	{
		public UpdateBookCommandValidator()
		{
			RuleFor(command => command.GenreId).GreaterThan(0);
			RuleFor(command => command.PageCount).GreaterThan(0);
			RuleFor(command => command.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
			RuleFor(command => command.Title).NotEmpty().MinimumLength(2);

		}
	}
}
