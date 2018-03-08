using AutoMapper;
using NorthWind.Model;

namespace NorthWindWebAPI.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region Product Mappings
            CreateMap<Product, ProductsListVM>().ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                    .ForMember(d => d.SupplierName, opt => opt.MapFrom(src => src.Supplier.CompanyName));

            CreateMap<Category, SelectListVM>().ForMember(d => d.Value, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(d => d.ID, opt => opt.MapFrom(src => src.CategoryID));

            CreateMap<Supplier, SelectListVM>().ForMember(d => d.Value, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(d => d.ID, opt => opt.MapFrom(src => src.SupplierID));

            CreateMap<Product, AddEditProductVM>();
            #endregion


            #region Order Mappings

            CreateMap<Order, OrderListVM>().ForMember(d => d.CustomerName, opt => opt.MapFrom(src => src.Customer.CompanyName))
                .ForMember(d => d.ShipVia, opt => opt.MapFrom(src => src.Shipper.CompanyName))
                //.ForMember(d => d.OrderDetails, opt => opt.MapFrom(src => src.Order_Details))
                //.ForMember(d => d.ShippingAddr, opt => opt.MapFrom(src => src.ShipName + "|" + src.ShipAddress + "|" + src.ShipCity + "|" + src.ShipCountry))
                .ForMember(d => d.EmployeeName, opt => opt.MapFrom(src => src.Employee.FirstName + " " + src.Employee.LastName));

            CreateMap<Order_Detail, OrderItems>().ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));

            #endregion

        }
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }
    }
}