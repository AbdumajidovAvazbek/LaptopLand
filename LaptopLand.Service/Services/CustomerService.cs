using AutoMapper;
using LaptopLand.Data.IRepositories;
using LaptopLand.Data.Repositories;
using LaptopLand.Domain.Entities;
using LaptopLand.Service.Dtos.Category;
using LaptopLand.Service.Dtos.Customer;
using LaptopLand.Service.Exceptions;
using LaptopLand.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Customer> customerRepository = new Repository<Customer>();
        public async Task<CustomerForResultDto> CreateAsync(CustomerForCreationDto dto)
        {
            var customer = customerRepository.SelectAll().
                FirstOrDefault(c => c.Email == dto.Email);
            if (customer is not null)
                throw new CustomException(409, "Customer is already exist");

            var mappedCustomer = mapper.Map<Customer>(dto);

            await this.customerRepository.InsertAsync(mappedCustomer);

            return this.mapper.Map<CustomerForResultDto>(mappedCustomer);
        }

        public  IQueryable<CustomerForResultDto> GetAllAsync()
        {
            var category = this.customerRepository.SelectAll().
               Include(c => c.orderProducts).
               ThenInclude(o => o.Product);

            return (IQueryable<CustomerForResultDto>)
                this.mapper.Map<IQueryable<CategoryForResultDto>>(category);
        }

        public async Task<CustomerForResultDto> GetByIdAsync(long id)
        {
            var customer = await customerRepository.SelecttByIdAsync(id);
            if (customer is null)
                throw new CustomException(404, "Customer is not found");
            return this.mapper.Map<CustomerForResultDto>(customer);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var customer = this.customerRepository.SelecttByIdAsync(id);
            if (customer is null)
                throw new CustomException(404, "Category is not found");
            await customerRepository.DeleteAsync(id);
            return true;
        }

        public async Task<CustomerForResultDto> UpdateAsync(CustomerForUpdateDto dto)
        {
            var customer = await this.customerRepository.SelecttByIdAsync(dto.Id);
            if (customer is null)
                throw new CustomException(404, "Customer is not found");

            var mappedCustomer = this.mapper.Map<Customer>(dto);

            await customerRepository.UpdateAsync(mappedCustomer);

            return this.mapper.Map<CustomerForResultDto>(mappedCustomer);
        }
    }
}
