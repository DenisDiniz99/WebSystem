using WebSystem.Mvc.Core.Notifications;

namespace WebSystem.Mvc.Core.Interfaces
{
    public interface IHandleNotification
    {
        bool HasNotification();
        void AddNotifications(Notification notification);
        List<Notification> GetNotifications();
    }
}
