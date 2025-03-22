using FluentValidation;

namespace PaparaBootcamp.Week4.Features.Author.Query.GetById
{
	public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
	{
		public GetAuthorDetailQueryValidator()
		{
			RuleFor(command => command.AuthorId).NotNull().GreaterThan(0);
		}
	}
}
