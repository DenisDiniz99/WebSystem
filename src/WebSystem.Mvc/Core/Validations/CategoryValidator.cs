using FluentValidation;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Core.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Informe um nome para a categoria.")
                .Length(2, 100)
                .WithMessage("A categoria deve conter entre 2 e 100 caracteres.");
        }
    }
}
