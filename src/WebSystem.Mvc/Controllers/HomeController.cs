using Microsoft.AspNetCore.Mvc;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.ViewModels;

namespace WebSystem.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHandleNotification handleNotification) : base(handleNotification)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("error/{statusCode:length(3,3)}")]
        public IActionResult Error(int statusCode)
        {
            var errorViewModel = new ErrorViewModel();

            switch (statusCode)
            {
                case 500:
                    errorViewModel.StatusCode = statusCode;
                    errorViewModel.Title = "Internal Server Error";
                    errorViewModel.Message = "Desculpe, mas ocorreu um erro. Tente novamente mais tarde. Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                case 404:
                    errorViewModel.StatusCode = statusCode;
                    errorViewModel.Title = "Not Found";
                    errorViewModel.Message = "Desculpe, mas a página não pode ser encontrada! Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                case 400:
                    errorViewModel.StatusCode = statusCode;
                    errorViewModel.Title = "Bad Request";
                    errorViewModel.Message = "Desculpe, mas ocorreu um erro durante a requisição. Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                default:
                    errorViewModel.StatusCode = statusCode;
                    errorViewModel.Title = "Internal Server Error";
                    errorViewModel.Message = "Desculpe, mas ocorreu um erro. Tente novamente mais tarde. Em caso de dúvidas entre em contato com o suporte!";
                    break;
            }
            return View(errorViewModel);
        }
    }
}