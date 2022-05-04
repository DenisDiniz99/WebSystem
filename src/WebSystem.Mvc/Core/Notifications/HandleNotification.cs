using WebSystem.Mvc.Core.Interfaces;

namespace WebSystem.Mvc.Core.Notifications
{
    public class HandleNotification : IHandleNotification
    {
        private readonly List<Notification> Notifications;

        public HandleNotification()
        {
            Notifications = new List<Notification>();
        }

        public bool HasNotification()
        {
            return Notifications.Any();
        }

        public void AddNotifications(Notification notification)
        {
            Notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return Notifications;
        }
    }
}
