using FluentValidation;
using MovieApp.Core.DTO;

namespace MovieApp.Core.Validators
{
    public class RestrictionValidator: AbstractValidator<RestrictionDto>
    {
        public RestrictionValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(r => r.Link)
                .NotEmpty()
                .Length(1, 50)
                .Matches("^[a-zA-Z0-9]*$");
        }
    }
}