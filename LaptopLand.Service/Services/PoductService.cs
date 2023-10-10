using AutoMapper;
using LaptopLand.Data.IRepositories;
using LaptopLand.Data.Repositories;
using LaptopLand.Domain.Entities;
using LaptopLand.Service.Dtos.Category;
using LaptopLand.Service.Dtos.Customer;
using LaptopLand.Service.Dtos.Product;
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
    public class PoductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Product> productRepository = new Repository<Product>();
        private readonly IRepository<Category> categoryRepository = new Repository<Category>();
        public async Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
        {
            var product = productRepository.SelectAll().
                FirstOrDefault(p => p.Name == dto.Name);
            if (product is not null)
                throw new CustomException(409, "Product is already exist");
            var category = categoryRepository.SelecttByIdAsync(dto.CategoryId);
            if (category is null)
                throw new CustomException(404, "Category is not found");

            var mappedProduct = mapper.Map<Product>(dto);

            await this.productRepository.InsertAsync(mappedProduct);

            return this.mapper.Map<ProductForResultDto>(mappedProduct);
        }

        public IQueryable<ProductForResultDto> GetAllAsync()
        {
            var product = this.productRepository.SelectAll().
                Include(p => p.Category);

            return (IQueryable<ProductForResultDto>)
                this.mapper.Map<IQueryable<CategoryForResultDto>>(product);
        }

        public async Task<ProductForResultDto> GetByIdAsync(long id)
        {
            var product = await productRepository.SelecttByIdAsync(id);
            if (product is null)
                throw new CustomException(404, "Product is not found");
            return this.mapper.Map<ProductForResultDto>(product);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var product = this.productRepository.SelecttByIdAsync(id);
            if (product is null)
                throw new CustomException(404, "Product is not found");
            await productRepository.DeleteAsync(id);
            return true;
        }

        public async Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto)
        {
            var product = await this.productRepository.SelecttByIdAsync(dto.Id);
            if (product is null)
                throw new CustomException(404, "Product is not found");
            var category = categoryRepository.SelecttByIdAsync(dto.CategoryId);
            if (category is null)
                throw new CustomException(404, "Category is not found");

            var mappedProduct = this.mapper.Map<Product>(dto);

            await productRepository.UpdateAsync(mappedProduct);

            return this.mapper.Map<ProductForResultDto>(mappedProduct);
        }
    }
}
