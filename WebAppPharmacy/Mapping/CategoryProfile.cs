using AutoMapper;
using WebAppPharmacy.Models;
using WebAppPharmacy.Areas.Categories.Models;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        // Mapping dari CategoryViewModel ke Category
        CreateMap<CategoryViewModel, Category>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        // Mapping dari Category ke CategoryViewModel (untuk edit dan list)
        CreateMap<Category, CategoryViewModel>();
    }
}
