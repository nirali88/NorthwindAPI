using AutoMapper;
using NorthWind.Model;

namespace NorthWindWebAPI.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<Product, ProductsListVM>().ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
            //        .ForMember(d => d.SupplierName, opt => opt.MapFrom(src => src.Supplier.CompanyName));

            //CreateMap<Category, SelectListVM>().ForMember(d => d.Value, opt => opt.MapFrom(src => src.CategoryName))
            //    .ForMember(d => d.ID, opt => opt.MapFrom(src => src.CategoryID));

            //CreateMap<Supplier, SelectListVM>().ForMember(d => d.Value, opt => opt.MapFrom(src => src.CompanyName))
            //    .ForMember(d => d.ID, opt => opt.MapFrom(src => src.SupplierID));

            CreateMap<AddEditProductVM, Product>();
        }
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappingProfile";
            }
        }
    }
}