using FluentValidation;
using MovieApp.Application.DTO;

namespace MovieApp.Application.Validators
{
    public class CategoriesValidator: AbstractValidator<CategoryDto>
    {
        public CategoriesValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(r => r.Link)
                .NotEmpty()
                .Length(3, 50)
                .Matches("^[a-zA-Z0-9]*$");
        }
    }
}