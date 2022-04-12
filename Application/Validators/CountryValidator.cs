using FluentValidation;
using MovieApp.Application.Entities;

namespace MovieApp.Application.Validators
{
    public class CountryValidator: AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .Length(2, 25);

            RuleFor(r => r.Link)
                .NotEmpty()
                .Length(2, 25)
                .Matches("^[a-zA-Z0-9]*$");
        }
    }
}