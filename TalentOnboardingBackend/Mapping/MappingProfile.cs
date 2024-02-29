using AutoMapper;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Store, StoreViewModel>();
            CreateMap<Sale, SalesViewModel>()
                .ForMember(vm => vm.CustomerName, sale => sale.MapFrom(s =>  s.Customer.Name))
                .ForMember(vm => vm.ProductName,sale => sale.MapFrom(s => s.Product.Name))
                .ForMember(vm => vm.StoreName, sale => sale.MapFrom(s => s.Store.Name))
                .ForMember(vm => vm.DateSold, sale => sale.MapFrom(s => s.DateSold.ToString("dd MMMM yyyy")));
                        

        }
    }
}
