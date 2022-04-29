using FluentValidation;
using WebSystem.Mvc.ValuesObject;

namespace WebSystem.Mvc.Validations.Document
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
