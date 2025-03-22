using FluentValidation;
using PaparaBootcamp.Week4.Features.GetById;

namespace PaparaBootcamp.Week4.Features.GetById
{
	public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
	{
		public GetByIdBookQueryValidator()
		{
			RuleFor(query => query.BookId).GreaterThan(0);
		}
	}
}
