using AutoMapper;
using WebAppPharmacy.Areas.Products.Models;
using WebAppPharmacy.Models;

namespace WebAppPharmacy.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.ProductCode ?? "-"));
        }
    }
}
