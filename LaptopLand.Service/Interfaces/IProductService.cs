using LaptopLand.Service.Dtos.Product;

namespace LaptopLand.Service.Interfaces
{
    public interface IProductService
    {
        public Task<bool> RemoveAsync(long id);
        public IQueryable<ProductForResultDto> GetAllAsync();
        public Task<ProductForResultDto> GetByIdAsync(long id);
        public Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto);
        public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
    }
}
