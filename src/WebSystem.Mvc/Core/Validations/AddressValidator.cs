using FluentValidation;
using WebSystem.Mvc.Core.ValuesObject;

namespace WebSystem.Mvc.Core.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street)
                .MaximumLength(100)
                .WithMessage("O nome da rua conter até 100 caracteres.");

            RuleFor(a => a.Number)
                .MaximumLength(10)
                .WithMessage("O número do endereço deve conter até 10 caracteres.");

            RuleFor(a => a.Neighborhood)
                .MaximumLength(100)
                .WithMessage("O nome do bairro deve conter até 100 caracteres.");

            RuleFor(a => a.State)
                .Length(2)
                .WithMessage("A sigla do estado deve conter 2 caracteres.");

            RuleFor(a => a.City)
                .MaximumLength(100)
                .WithMessage("O nome da cidade deve conter até 100 caracteres.");

            RuleFor(a => a.ZipCode)
                .Length(8)
                .WithMessage("O CEP deve conter 8 caracteres.");
        }
    }
}
