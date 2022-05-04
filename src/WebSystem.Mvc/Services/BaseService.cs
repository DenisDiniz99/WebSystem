using FluentValidation.Results;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Notifications;

namespace WebSystem.Mvc.Services
{
    public abstract class BaseService
    {
        private readonly IHandleNotification _handle;

        public BaseService(IHandleNotification handle)
        {
            _handle = handle;
        }

        public void Execute(string message)
        {
            _handle.AddNotifications(new Notification(message));
        }

        public void Execute(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Execute(error.ErrorMessage);
            }
        }
    }
}
