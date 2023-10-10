using LaptopLand.Service.Dtos.Order;
using LaptopLand.Service.Dtos.OrderProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Interfaces
{
    public interface IOrderProductService
    {
        public Task<bool> RemoveAsync(long id);
        public IQueryable<OrderProductForResultDto> GetAllAsync();
        public Task<OrderProductForResultDto> GetByIdAsync(long id);
        public Task<OrderProductForResultDto> CreateAsync(OrderProductForCreationDto dto);
    }
}
