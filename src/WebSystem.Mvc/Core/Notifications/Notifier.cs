using FluentValidation.Results;
using WebSystem.Mvc.Core.Interfaces;

namespace WebSystem.Mvc.Core.Notifications
{
    public class Notifier : INotifier
    {
        private readonly IHandleNotification _handle;

        public Notifier(IHandleNotification handle)
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
