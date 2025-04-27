using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Entities;

namespace Ecommerce__Project.Api.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Image, ImageDto>();
            CreateMap<Product,GetAllProductDto>
                ().ForMember(p=>p.CategoryName,
                m=>m.MapFrom(src=>src.Category.Name));
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(pDto => pDto.Images, options => options.Ignore())
                .ReverseMap();
            CreateMap<UpdateProductDto, Product>()
                .ForMember(pDto => pDto.Images, options => options.Ignore())
                .ReverseMap();

        }
    }
}
