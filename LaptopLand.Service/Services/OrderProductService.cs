using AutoMapper;
using LaptopLand.Domain.Entities;
using LaptopLand.Data.Repositories;
using LaptopLand.Data.IRepositories;
using LaptopLand.Service.Dtos.Order;
using LaptopLand.Service.Interfaces;
using LaptopLand.Service.Dtos.OrderProduct;
using LaptopLand.Service.Dtos.Customer;
using LaptopLand.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using LaptopLand.Service.Dtos.Category;

namespace LaptopLand.Service.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IMapper mapper;
        private readonly IRepository<OrderProduct> orderProductRepository = new Repository<OrderProduct>();
        public async Task<OrderProductForResultDto> CreateAsync(OrderProductForCreationDto dto)
        {
            if (dto is null)
                throw new CustomException(409, "OrderProduct is already exist");

            var mapperOrPr = mapper.Map<OrderProduct>(dto);

            await this.orderProductRepository.InsertAsync(mapperOrPr);

            return this.mapper.Map<OrderProductForResultDto>(mapperOrPr);
        }

        public  IQueryable<OrderProductForResultDto> GetAllAsync()
        {
            var orderProduct = orderProductRepository.SelectAll();

            return (IQueryable<OrderProductForResultDto>)
                this.mapper.Map<IQueryable<OrderForResultDto>>(orderProduct).ToList();
        }

        public async Task<OrderProductForResultDto> GetByIdAsync(long id)
        {
            var orderProduct = await orderProductRepository.SelecttByIdAsync(id);
            if (orderProduct is null)
                throw new CustomException(404, "OrderProduct is not found");
            return this.mapper.Map<OrderProductForResultDto>(orderProduct);
        }
        public async Task<bool> RemoveAsync(long id)
        {
            var orderProduct = this.orderProductRepository.SelecttByIdAsync(id);
            if (orderProduct is null)
                throw new CustomException(404, "OrderProduct is not found");
            await orderProductRepository.DeleteAsync(id);
            return true;
        }
    }
}
