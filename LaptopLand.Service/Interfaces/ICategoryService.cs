using LaptopLand.Service.Dtos.Category;

namespace LaptopLand.Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<bool> RemoveAsync(long id);
        public IQueryable<CategoryForResultDto> GetAllAsync();
        public Task<CategoryForResultDto> GetByIdAsync(long id);
        public Task<CategoryForResultDto> UpdateAsync(CategoryForUpdateDto dto);
        public Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto);
    }
}
