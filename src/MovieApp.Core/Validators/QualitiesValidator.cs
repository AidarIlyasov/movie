using FluentValidation;
using MovieApp.Core.DTO;

namespace MovieApp.Core.Validators
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