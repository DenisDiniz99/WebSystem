using FluentValidation.Results;

namespace WebSystem.Mvc.Core.Interfaces
{
    public interface INotifier
    {
        void Execute(string message);
        void Execute(ValidationResult validationResult);
    }
}
