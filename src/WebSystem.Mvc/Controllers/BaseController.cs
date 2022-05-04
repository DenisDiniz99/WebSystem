using Microsoft.AspNetCore.Mvc;
using WebSystem.Mvc.Core.Interfaces;

namespace WebSystem.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IHandleNotification _handleNotification;

        protected BaseController(IHandleNotification handleNotification)
        {
            _handleNotification = handleNotification;
        }

        protected void AddErrorsModelState(string message)
        {
            ModelState.AddModelError(string.Empty, message);
        }
    }
}
