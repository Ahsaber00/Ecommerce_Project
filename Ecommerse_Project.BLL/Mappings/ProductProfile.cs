using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Ecommerce__Project.Api.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            
            CreateMap<Image, ImageDto>().ForMember(dest=>dest.ImageUrl,opt=>opt.MapFrom(src=>src.Url));
            CreateMap<Product,GetAllProductDto>
                ().ForMember(p=>p.CategoryName,
                m=>m.MapFrom(src=>src.Category.Name));
            CreateMap<Product, ProductDetailsDto>().
                ForMember(dto => dto.Images, opt => opt.MapFrom(src => src.Images));
            CreateMap<CreateProductDto, Product>()
                .ForMember(pDto => pDto.Images, options => options.Ignore())
                .ForMember(p => p.CategoryId, options => options.MapFrom(src => src.SubCategoryId))
                .ReverseMap();
                
            CreateMap<UpdateProductDto, Product>()
                .ForMember(pDto => pDto.Images, options => options.Ignore())
                .ForMember(dest=>dest.CategoryId,opt=>opt.MapFrom(src=>src.SubCategoryId))
                .ReverseMap();

            CreateMap<Product, DashboardProductDto>().ForMember(pDto => pDto.CategoryName,
                opt => opt.MapFrom(p => p.Category.Name))
                .ForMember(pDto => pDto.AdminName,
                opt => opt.MapFrom(p => p.Admin.FirstName));


        }
    }
}
