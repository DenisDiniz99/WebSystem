using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            var productViewModel = await GetByIdAsync(id);

            return (productViewModel == null) ? NotFound() : View(productViewModel);
        }


        public async Task<IActionResult> Create()
        {
            var supplierViewModel = await GetSuppliers();
            var categoryViewModel = await GetCategories();

            var productViewModel = new ProductViewModel();
            productViewModel.Suppliers = supplierViewModel;
            productViewModel.Categories = categoryViewModel;

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel.Suppliers = await GetSuppliers();
            productViewModel.Categories = await GetCategories();

            if (!ModelState.IsValid) 
                return View(productViewModel);

            var imgPrefix = Guid.NewGuid() + "_";

            if(!await UploadImage(productViewModel.ImageUpload, imgPrefix))
                return View(productViewModel);

            productViewModel.Image = imgPrefix + productViewModel.ImageUpload.FileName;

            await _productService.ServiceSaveAsync(productViewModel.Name, productViewModel.Description, productViewModel.Price, productViewModel.Image, productViewModel.CategoryId, productViewModel.SupplierId);

            return HasNotification() ? View(productViewModel) : RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(Guid id)
        {
            var productViewModel = await GetByIdAsync(id);

            if (productViewModel == null)
                return NotFound();

            productViewModel.Suppliers = await GetSuppliers();
            productViewModel.Categories = await GetCategories();

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) 
                return NotFound();

            var productUpdate = await GetByIdAsync(productViewModel.Id);

            productViewModel.Supplier = productUpdate.Supplier;
            productViewModel.Category = productUpdate.Category;
            productViewModel.Image = productUpdate.Image;

            if (!ModelState.IsValid) 
                return View(productViewModel);

            if(productViewModel.ImageUpload != null)
            {
                var imgPrefix = Guid.NewGuid() + "_";

                if (!await UploadImage(productViewModel.ImageUpload, imgPrefix))
                {
                    return View(productViewModel);
                }

                productViewModel.Image = imgPrefix + productViewModel.ImageUpload.FileName;
            }

            await _productService.ServiceUpdateAsync(productViewModel.Id, productViewModel.Name, productViewModel.Description, productViewModel.Price, productViewModel.Image, productViewModel.CategoryId, productViewModel.SupplierId);

            return HasNotification() ? View(productViewModel) : RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var productViewModel = await GetByIdAsync(id);

            return (productViewModel == null) ? NotFound() : View(productViewModel);
        }

        [HttpPost, ActionName("delete")]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            await _productService.ServiceDeleteAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Activate(Guid id)
        {
            var productViewModel = await GetByIdAsync(id);

            return (productViewModel == null) ? NotFound() : View(productViewModel);
        }

        [HttpPost, ActionName("activate")]
        public async Task<IActionResult> ConfirmActivate(Guid id)
        {
            await _productService.ServiceActivateAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Deactivate(Guid id)
        {
            var productViewModel = await GetByIdAsync(id);

            return (productViewModel == null) ? NotFound() : View(productViewModel);
        }

        [HttpPost, ActionName("deactivate")]
        public async Task<IActionResult> ConfirmDeactivate(Guid id)
        {
            await _productService.ServiceDeactivateAsync(id);
            return RedirectToAction("Index");
        }




        #region Private_Methods

        //Updload de Imagem do Produto
        private async Task<bool> UploadImage(IFormFile file, string prefix)
        {
            if (file.Length <= 0)
                return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", prefix + file.FileName);

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

        private async Task<ProductViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetByIdAsync(id));
        }

        private async Task<IEnumerable<SupplierViewModel>> GetSuppliers()
        {
            return _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAllAsync());
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAllAsync());
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
