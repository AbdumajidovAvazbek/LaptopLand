using AutoMapper;
using LaptopLand.Data.IRepositories;
using LaptopLand.Data.Repositories;
using LaptopLand.Domain.Entities;
using LaptopLand.Service.Dtos.Order;
using LaptopLand.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaptopLand.Service.Dtos.Order;
using LaptopLand.Service.Exceptions;

namespace LaptopLand.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Order> orderRepository = new Repository<Order>();
        private readonly ICustomerService customerService = new CustomerService();
       
        public async Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto)
        {
            var mapperOrder = this.mapper.Map<Order>(dto);

            var order = orderRepository.InsertAsync(mapperOrder);

            return this.mapper.Map<OrderForResultDto>(order);    
        }
        public  IQueryable<OrderForResultDto> GetAllAsync()
        {
            var users =  orderRepository.SelectAll();
            if (users is null)
                throw new CustomException(400,"Order null");
            return (IQueryable<OrderForResultDto>)mapper.Map<OrderForResultDto>(users);
        }

        public async Task<OrderForResultDto> GetByIdAsync(long id)
        {
            var order = orderRepository.SelecttByIdAsync(id);
            if(order is null)
                throw new CustomException(404, "Order is not found");
            return mapper.Map<OrderForResultDto>(order); 
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var order = orderRepository.SelecttByIdAsync(id);
            if(order is null)
                throw new CustomException(404, "Order is not found");
            return await orderRepository.DeleteAsync(id);
        }
    }
}
