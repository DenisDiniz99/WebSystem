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
                                    IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAllAsync()));
        }

        [HttpGet]
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
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _categoryService.ServiceSaveAsync(category.Name);

            return Ok();
        }
    }
}