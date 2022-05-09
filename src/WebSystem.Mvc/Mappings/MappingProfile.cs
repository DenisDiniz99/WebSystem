using AutoMapper;
using WebSystem.Mvc.Core.Models;
using WebSystem.Mvc.Core.ValuesObject;
using WebSystem.Mvc.ViewModels;

namespace WebSystem.Mvc.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Email, EmailViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Document, DocumentViewModel>().ReverseMap();
        }
    }
}
