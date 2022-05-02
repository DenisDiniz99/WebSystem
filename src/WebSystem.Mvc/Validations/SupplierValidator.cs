using FluentValidation;
using WebSystem.Mvc.Enums;
using WebSystem.Mvc.Models;
using WebSystem.Mvc.Validations.Document;

namespace WebSystem.Mvc.Validations
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Informe o nome do fornecedor.")
                .Length(2, 100)
                .WithMessage("O nome do fornecedor deve conter entre 0 e 100 caracteres");

            RuleFor(s => s.CorporateName)
                .Length(2, 100)
                .WithMessage("A Razão Social deve conter entre 2 e 100 caracteres.");

            RuleFor(s => s.Description)
                .NotEmpty()
                .WithMessage("Informe uma descrição para o fornecedor.")
                .Length(2, 255)
                .WithMessage("A descrição do fornecedor deve conter entre 2 e 255 caracteres.");

            RuleFor(s => s.Phone)
                .NotEmpty()
                .WithMessage("Informe um número de telefone para o fornecedor.");

            RuleFor(s => s.Contact)
                .Length(2, 50)
                .WithMessage("O nome de contato do forncedor deve conter entre 2 e 50 caracteres.");

            When(s => s.Document.Type == EDocumentType.Cpf, () =>
            {
                RuleFor(s => CpfValidator.IsCpf(s.Document.Number))
                    .Equal(true)
                    .WithMessage("O documento informado é inválido.");
            });

            When(s => s.Document.Type == EDocumentType.Cnpj, () =>
            {
                RuleFor(s => CnpjValidator.IsCnpj(s.Document.Number))
                    .Equal(true)
                    .WithMessage("O documento informado é inválido.");
            });

            RuleFor(s => s.Email)
                .SetValidator(new EmailAddressValidator());

            RuleFor(s => s.Address)
                .SetValidator(new AddressValidator());
                
        }
    }
}
