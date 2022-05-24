using Microsoft.AspNetCore.Mvc;
using WebSystem.Mvc.Core.Interfaces;

namespace WebSystem.Mvc.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly IHandleNotification _handleNotification;

        public SummaryViewComponent(IHandleNotification handleNotification)
        {
            _handleNotification = handleNotification;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_handleNotification.GetNotifications());
            notifications.ForEach(notification => ViewData.ModelState.AddModelError(string.Empty, notification.Message));
            return View();
        }
    }
}
