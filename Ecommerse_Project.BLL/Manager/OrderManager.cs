using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Interfaces;
using Ecommerse_Project.DAL.Models.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public class OrderManager : IOrderManager
    {
        private readonly ApplicationContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderManager(ApplicationContext context, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<OrderResultDto> CreateOrderAsync(CreateOrderDto orderDto, string buyerEmail, string userId)
        {
            var cart = await _unitOfWork.CustomerCart.GetCartAsync(userId);
            var cartItems = cart.cartItems;
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var cartItem in cartItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductId);
                OrderItem item = new OrderItem()
                {
                    ProductId = product.Id,
                    ProductMainImage = cartItem.ImageUrl,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = cartItem.Quantity,
                };
                orderItems.Add(item);
            }
            var deliveryMethod = await _context.DeliveryMethods.FirstOrDefaultAsync(d => orderDto.DeliveryMethodId == d.Id);
            var orderprice = cart.TotalPrice;
            var order = new Order()
            {
                BuyerEmail = buyerEmail,
                OrderItems = orderItems,
                DeliveryMethod = deliveryMethod,
                OrderPrice = orderprice,
                ShippingAddress = new ShippingAddress
                {
                    FirstName = orderDto.ShippingAddress.FirstName,
                    LastName = orderDto.ShippingAddress.LastName,
                    Governorate = orderDto.ShippingAddress.Governorate,
                    City = orderDto.ShippingAddress.City,
                    Street = orderDto.ShippingAddress.Street

                }

            };

            order.TotalPrice=order.GetTotalPrice();
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveAll();
            var orderResult=_mapper.Map<OrderResultDto>(order);
            return orderResult;

        }

        public async Task<IReadOnlyList<OrderResultDto>> GetAllOrdersAsync()
        {
            var orders=await _unitOfWork.Orders.GetAllAsync(o=>o.DeliveryMethod,o=>o.ShippingAddress,o=>o.OrderItems);
            if(orders==null)
            {
                throw new Exception("No orders found yet.");
            }
            var ordersResult=_mapper.Map<IReadOnlyList<OrderResultDto>>(orders);
            return ordersResult;
        }

        public async Task<List<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _context.DeliveryMethods.ToListAsync();
        }

        public async Task<Order> GetOrderById(int orderId, string buyerEmail)
        {
            var order=await _unitOfWork.Orders.GetByIdAsync(orderId);
            if(order == null)
            {   
                throw new Exception("Order not found");
            }
            return order;
        }

        public async Task<IReadOnlyList<OrderResultDto>> GetOrdersByUserEmailAsync(string email)
        {
            var orders=await _unitOfWork.Orders.GetOrdersByUserEmailAsync(email);
            if(orders == null)
            {
                throw new Exception("No orders for this account");
            }
            var orderResult=_mapper.Map<IReadOnlyList<OrderResultDto>>(orders);
            return orderResult;
        }
    }
}
