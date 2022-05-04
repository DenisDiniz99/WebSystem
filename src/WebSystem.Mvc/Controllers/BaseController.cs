using Microsoft.AspNetCore.Mvc;

namespace WebSystem.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void AddErrorsModelState(string message)
        {
            ModelState.AddModelError(string.Empty, message);
        }
    }
}
