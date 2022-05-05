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
            var category = _mapper.Map<CategoryViewModel>(await _categoryRepository.GetByIdAsync(id));

            if (category == null)
                return NotFound();

            return View(category);
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

            if (_handleNotification.HasNotification())
            {
                var notifications = _handleNotification.GetNotifications();
                foreach (var notification in notifications)
                {
                    AddErrorsModelState(notification.Message);
                }

                return View(categoryViewModel);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            return View(_mapper.Map<CategoryViewModel>(await _categoryRepository.GetByIdAsync(id)));
        }


        [HttpPost]
        public async Task<IActionResult> Update(Guid id, CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(categoryViewModel);

            await _categoryService.ServiceUpdateAsync(id, categoryViewModel.Name);

            if (_handleNotification.HasNotification())
            {
                var notifications = _handleNotification.GetNotifications();
                foreach(var notification in notifications)
                {
                    AddErrorsModelState(notification.Message);
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(_mapper.Map<CategoryViewModel>(await _categoryRepository.GetByIdAsync(id)));
        }

        [HttpPost, ActionName("delete")]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            await _categoryService.ServiceDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}