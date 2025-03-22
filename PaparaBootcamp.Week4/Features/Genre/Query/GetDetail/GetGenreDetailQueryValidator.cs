using FluentValidation;

namespace PaparaBootcamp.Week4.Features.Genre.Query.GetDetail
{
	public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
	{
		public GetGenreDetailQueryValidator()
		{
			RuleFor(command => command.GenreId).GreaterThan(0).NotEmpty();
		}
	}
}
