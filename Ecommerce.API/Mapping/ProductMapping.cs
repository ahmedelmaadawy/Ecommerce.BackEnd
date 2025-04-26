using AutoMapper;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities.Product;

namespace Ecommerce.API.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>().ForMember(x => x.CategoryName,
                op => op.MapFrom(src => src.Category.Name)).ReverseMap();

            CreateMap<Photo, PhotoDTO>().ReverseMap();
        }
    }
}
