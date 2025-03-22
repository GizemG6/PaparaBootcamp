using FluentValidation;
using PaparaBootcamp.Week3._1.Features.GetById;

namespace PaparaBootcamp.Week3._2.Features.GetById
{
	public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
	{
		public GetByIdBookQueryValidator()
		{
			RuleFor(query => query.BookId).GreaterThan(0);
		}
	}
}
