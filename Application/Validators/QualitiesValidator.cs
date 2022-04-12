using FluentValidation;
using MovieApp.Application.DTO;

namespace MovieApp.Application.Validators
{
    public class QualitiesValidator: AbstractValidator<QualityDto>
    {
        public QualitiesValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .Length(2, 10)
                .Matches("^[a-zA-Z0-9]*$");
        }
    }
}