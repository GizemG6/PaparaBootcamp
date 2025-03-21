﻿using FluentValidation;
using PaparaBootcamp.Week3._1.Features.Update;

namespace PaparaBootcamp.Week3._2.Features.Update
{
	public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
	{
		public UpdateBookCommandValidator()
		{
			RuleFor(command => command.BookId).GreaterThan(0);
			RuleFor(command => command.Model.GenreId).GreaterThan(0);
			RuleFor(command => command.Model.PageCount).GreaterThan(0);
			RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
			RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);

		}
	}
}
