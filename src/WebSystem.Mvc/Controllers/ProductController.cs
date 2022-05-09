using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.ViewModels;

namespace WebSystem.Mvc.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository,
                                    ICategoryRepository categoryRepository,
                                    ISupplierRepository supplierRepository,
                                    IProductService productService,
                                    IMapper mapper,
                                    IHandleNotification handleNotification) : base(handleNotification)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAllAsync()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productViewModel = _mapper.Map<ProductViewModel>(await _productRepository.GetByIdAsync(id));

            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var supplierViewModel = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAllAsync());
            var categoryViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAllAsync());

            var productViewModel = new ProductViewModel();
            productViewModel.Suppliers = supplierViewModel;
            productViewModel.Categories = categoryViewModel;

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            var supplierViewModel = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAllAsync());
            var categoryViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAllAsync());

            productViewModel.Suppliers = supplierViewModel;
            productViewModel.Categories = categoryViewModel;

            if (!ModelState.IsValid)
                return View(productViewModel);

            var imgPrefix = Guid.NewGuid() + "_";
            if(!await UploadImage(productViewModel.ImageUpload, imgPrefix))
            {
                return View(productViewModel);
            }

            productViewModel.Image = $"{imgPrefix} {productViewModel.ImageUpload.FileName}";

            await _productService.ServiceSaveAsync(productViewModel.Name,
                                                    productViewModel.Description,
                                                    productViewModel.Price,
                                                    productViewModel.Image,
                                                    productViewModel.CategoryId,
                                                    productViewModel.SupplierId);

            if (_handleNotification.HasNotification())
            {
                var notifications = _handleNotification.GetNotifications();
                foreach (var notification in notifications)
                {
                    AddErrorsModelState(notification.Message);
                }
                return View(productViewModel);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var productViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetByIdAsync(id));

            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(productViewModel);

            if(productViewModel.ImageUpload != null)
            {
                var imgPrefix = Guid.NewGuid() + "_";
                if(! await UploadImage(productViewModel.ImageUpload, imgPrefix))
                {
                    return View(productViewModel);
                }

                productViewModel.Image = $"{imgPrefix} {productViewModel.ImageUpload.FileName}";
            }

            await _productService.ServiceUpdateAsync(productViewModel.Id, productViewModel.Name, productViewModel.Description, productViewModel.Price, productViewModel.Image, productViewModel.CategoryId, productViewModel.SupplierId);

            if (_handleNotification.HasNotification())
            {
                var notifications = _handleNotification.GetNotifications();
                foreach(var notification in notifications)
                {
                    AddErrorsModelState(notification.Message);
                }
                return View(productViewModel);
            }

            return RedirectToAction("Index");
        }



        //Updload de Imagem do Produto
        private async Task<bool> UploadImage(IFormFile file, string prefix)
        {
            if (file.Length <= 0)
                return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", prefix + file.Name);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome.");
                return false;
            }

            using(var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }

       
    }
}
