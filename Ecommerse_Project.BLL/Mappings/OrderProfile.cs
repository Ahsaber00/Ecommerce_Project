using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Models.Order;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Mappings
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResultDto>()
                .ForMember(oDto => oDto.DeliveryMethod,
            opt => opt.MapFrom(o => o.DeliveryMethod.Name))
                .ForMember(oDto => oDto.DeliveryPrice,
                opt => opt.MapFrom(o => o.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>();
                
             
        }
    }
}
