using LaptopLand.Service.Dtos.Customer;
using LaptopLand.Service.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> RemoveAsync(long id);
        public IQueryable<OrderForResultDto> GetAllAsync();
        public Task<OrderForResultDto> GetByIdAsync(long id);
        public Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto);
    }
}
