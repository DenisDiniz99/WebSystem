using FluentValidation;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Core.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Informe um nome para o produto.")
                .Length(2, 100)
                .WithMessage("O nome do produto deve conter entre 2 e 100 caracteres.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Informe uma descrição para o produto.")
                .Length(2, 255)
                .WithMessage("A descirção do produto deve conter entre 2 e 255 caracteres.");

            RuleFor(p => p.Price)
                .NotNull()
                .WithMessage("Informe um preço para o produto.");

            RuleFor(p => p.Category)
                .SetValidator(new CategoryValidator());
        }
    }
}
