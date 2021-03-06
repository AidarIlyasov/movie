using FluentValidation;
using MovieApp.Core.Entities;

namespace MovieApp.Core.Validators
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