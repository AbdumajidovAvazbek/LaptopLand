using LaptopLand.Service.Dtos.Category;
using LaptopLand.Service.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Interfaces
{
    public interface ICustomerService
    {
        public Task<bool> RemoveAsync(long id);
        public IQueryable<CustomerForResultDto> GetAllAsync();
        public Task<CustomerForResultDto> GetByIdAsync(long id);
        public Task<CustomerForResultDto> UpdateAsync(CustomerForUpdateDto dto);
        public Task<CustomerForResultDto> CreateAsync(CustomerForCreationDto dto);
    }
}
