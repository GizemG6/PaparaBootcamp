using FluentValidation;
using PaparaBootcamp.Week4.Features.Command.Create;

namespace PaparaBootcamp.Week4.Features.Author.Command.Create
{
	public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
	{
		public CreateAuthorCommandValidator()
		{
			RuleFor(command => command._createAuthorDto.FirstName).NotEmpty().MinimumLength(2);
			RuleFor(command => command._createAuthorDto.LastName).NotEmpty().MinimumLength(2);
			RuleFor(command => command._createAuthorDto.DateOfBirth).NotEmpty().LessThan(DateTime.Now.AddYears(-15));
		}
	}
}
