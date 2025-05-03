using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Entities;

namespace Ecommerce__Project.Api.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto,Category>().ReverseMap();   
        }
    }
}
