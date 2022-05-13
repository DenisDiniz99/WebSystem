using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.ViewModels;

namespace WebSystem.Mvc.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, 
                                    ICategoryService categoryService,
                                    IMapper mapper,
                                    IHandleNotification handleNotification) : base(handleNotification)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAllAsync()));
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var categoryViewModel = await GetByIdAsync(id);

            return(categoryViewModel == null) ? NotFound() : View(categoryViewModel);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
                return View(categoryViewModel);

            await _categoryService.ServiceSaveAsync(categoryViewModel.Name);

            return HasNotification() ? View(categoryViewModel) : RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(Guid id)
        {
            var categoryViewModel = await GetByIdAsync(id);

            return (categoryViewModel == null) ? NotFound() : View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(categoryViewModel);

            await _categoryService.ServiceUpdateAsync(id, categoryViewModel.Name);

            return HasNotification() ? View(categoryViewModel) : RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var categoryViewModel = await GetByIdAsync(id);

            return (categoryViewModel == null) ? NotFound() : View(categoryViewModel);
        }

        [HttpPost, ActionName("delete")]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            await _categoryService.ServiceDeleteAsync(id);
            return RedirectToAction("Index");
        }




        #region Private_Methods

        private async Task<CategoryViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CategoryViewModel>(await _categoryRepository.GetByIdAsync(id));
        }

        private bool HasNotification()
        {
            if (_handleNotification.HasNotification())
            {
                var notifications = _handleNotification.GetNotifications();
                foreach (var notification in notifications)
                {
                    AddErrorsModelState(notification.Message);
                }
                return true;
            }

            return false;
        }

        #endregion
    }
}