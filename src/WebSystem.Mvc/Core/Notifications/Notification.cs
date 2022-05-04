using WebSystem.Mvc.Core.Interfaces;

namespace WebSystem.Mvc.Core.Notifications
{
    public class Notification : INotification
    {
        public string Message { get; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
