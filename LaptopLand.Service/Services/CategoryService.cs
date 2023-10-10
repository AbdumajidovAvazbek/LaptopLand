using LaptopLand.Data.IRepositories;
using LaptopLand.Service.Dtos.Category;
using LaptopLand.Service.Interfaces;
using LaptopLand.Data.IRepositories;
using LaptopLand.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaptopLand.Domain.Entities;
using LaptopLand.Service.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace LaptopLand.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Category> categoryRepository = new Repository<Category>();
        public async Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto)
        {
            var category = categoryRepository.SelectAll().
                FirstOrDefault(c => c.Name == dto.Name);
            if (category is not null)
                throw new CustomException(409, "Category is already exist");
            var mappedCategory = mapper.Map<Category>(dto);

            await this.categoryRepository.InsertAsync(mappedCategory);

            var result = this.mapper.Map<CategoryForResultDto>(mappedCategory);
            return result;
        }

        public  IQueryable<CategoryForResultDto> GetAllAsync()
        {
            var category = this.categoryRepository.SelectAll().
                Include(c => c.Products).ToListAsync();

           return this.mapper.Map<IQueryable<CategoryForResultDto>>(category);
        }

        public async Task<CategoryForResultDto> GetByIdAsync(long id)
        {
            var category = await categoryRepository.SelecttByIdAsync(id);
            if(category is null)
                throw new CustomException(404,"Category is not found");
            return this.mapper.Map<CategoryForResultDto>(category);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var category = this.categoryRepository.SelecttByIdAsync(id);
            if (category is null)
                throw new CustomException(404, "Category is not found");
            await categoryRepository.DeleteAsync(id);
            return true;
        }

        public async Task<CategoryForResultDto> UpdateAsync(CategoryForUpdateDto dto)
        {
            var category = await this.categoryRepository.SelecttByIdAsync(dto.Id);
            if (category is null)
                throw new CustomException(404, "Category is not found");

            var mappedCategory = this.mapper.Map<Category>(dto);

            await categoryRepository.UpdateAsync(mappedCategory);

            return this.mapper.Map<CategoryForResultDto>(mappedCategory);  
        }
    }
}
