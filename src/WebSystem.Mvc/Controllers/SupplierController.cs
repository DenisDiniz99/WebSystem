using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.ValuesObject;
using WebSystem.Mvc.ViewModels;

namespace WebSystem.Mvc.Controllers
{
    public class SupplierController : BaseController
    {
        public readonly ISupplierRepository _supplierRepository;
        public readonly ISupplierService _supplierService;
        public readonly IMapper _mapper;

        public SupplierController(ISupplierRepository supplierRepository,
                                    ISupplierService supplierService,
                                    IMapper mapper,
                                    IHandleNotification handleNotification) : base(handleNotification)
        {
            _supplierRepository = supplierRepository;
            _supplierService = supplierService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAllAsync()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetByIdAsync(id);

            return (supplierViewModel == null) ? NotFound() : View(supplierViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
                return View(supplierViewModel);

            var email = _mapper.Map<Email>(supplierViewModel.Email);
            var document = _mapper.Map<Document>(supplierViewModel.Document);
            var address = _mapper.Map<Address>(supplierViewModel.Address);

            await _supplierService.ServiceSaveAsync(supplierViewModel.Name,
                                                    supplierViewModel.CorporateName,
                                                    supplierViewModel.Description,
                                                    supplierViewModel.Phone,
                                                    supplierViewModel.Contact,
                                                    email,
                                                    document,
                                                    address);
            
            return HasNotification() ? View(supplierViewModel) : RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(Guid id)
        {
            var supplierViewModel = await GetByIdAsync(id);

            return (supplierViewModel == null) ? NotFound() : View(supplierViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
                return NotFound();

            ModelState.Remove("Address");

            if(!ModelState.IsValid)
                return BadRequest();

            var email = _mapper.Map<Email>(supplierViewModel.Email);
            var document = _mapper.Map<Document>(supplierViewModel.Document);

            await _supplierService.ServiceUpdateAsync(supplierViewModel.Id, supplierViewModel.Name, supplierViewModel.CorporateName, supplierViewModel.Description, supplierViewModel.Phone, supplierViewModel.Contact, email, document);

            return HasNotification() ? View(supplierViewModel) : RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var supplierViewModel = await GetByIdAsync(id);

            return (supplierViewModel == null) ? NotFound() : View(supplierViewModel);
        }

        [HttpPost, ActionName("activate")]
        public async Task<IActionResult> ConfirmActivate(Guid id)
        {
            await _supplierService.ServiceActivateAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Deactivate(Guid id)
        {
            var supplierViewModel = await GetByIdAsync(id);

            return (supplierViewModel == null) ? NotFound() : View(supplierViewModel);
        }

        [HttpPost, ActionName("deactivate")]
        public async Task<IActionResult> ConfirmDeactivate(Guid id)
        {
            await _supplierService.ServiceDeactivateAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Address(Guid id)
        {
            var supplierViewModel = await GetByIdAsync(id);

            return (supplierViewModel == null) ? NotFound() : View(supplierViewModel);
        }

        [HttpPost, ActionName("address")]
        public async Task<IActionResult> UpdateAddress(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id) 
                return NotFound();

            ModelState.Remove("Name");
            ModelState.Remove("CorporateName");
            ModelState.Remove("Description");
            ModelState.Remove("Phone");
            ModelState.Remove("Contact");
            ModelState.Remove("Email");
            ModelState.Remove("Document");

            if (!ModelState.IsValid) return View(supplierViewModel);

            await _supplierService.ServiceUpdateAddressAsync(supplierViewModel.Id,supplierViewModel.Address.Street, supplierViewModel.Address.Number, supplierViewModel.Address.Neighborhood, supplierViewModel.Address.City, supplierViewModel.Address.State, supplierViewModel.Address.ZipCode);
            
            return HasNotification() ? View(supplierViewModel) : RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetByIdAsync(id);

            return (supplierViewModel == null) ? NotFound() : View(supplierViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            await _supplierService.ServiceDeleteAsync(id);
            return RedirectToAction("Index");
        }



        #region Private_Methods

        private async Task<SupplierViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetByIdAsync(id));
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
