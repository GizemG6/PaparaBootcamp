using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PaparaBootcamp.Week4.Features.Author.Command.Update
{
	public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
	{
		public UpdateAuthorCommandValidator()
		{
			RuleFor(command => command.AuthorId).GreaterThan(0);
			RuleFor(command => command.updateAuthorDto.FirstName).NotEmpty().MinimumLength(2);
			RuleFor(command => command.updateAuthorDto.LastName).NotEmpty().MinimumLength(2);
			RuleFor(command => command.updateAuthorDto.DateOfBirth).NotEmpty().LessThan(DateTime.Now.AddYears(-15));
		}
	}
}
