using FluentValidation;
using WebSystem.Mvc.Core.ValuesObject;

namespace WebSystem.Mvc.Core.Validations.Document
{
    public class EmailAddressValidator : AbstractValidator<Email>
    {
        public EmailAddressValidator()
        {
            RuleFor(e => e.EmailAddress)
                .NotEmpty()
                .WithMessage("Informe uma e-mail.");
        }
    }
}
