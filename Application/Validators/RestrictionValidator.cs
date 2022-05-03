using FluentValidation;
using MovieApp.Application.DTO;

namespace MovieApp.Application.Validators
{
    public class RestrictionValidator: AbstractValidator<RestrictionDto>
    {
        public RestrictionValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(r => r.Link)
                .NotEmpty();
        }
    }
}