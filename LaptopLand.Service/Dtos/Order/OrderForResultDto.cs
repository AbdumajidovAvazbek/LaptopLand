using LaptopLand.Service.Dtos.OrderProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Dtos.Order
{
    public class OrderForResultDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public IEnumerable<OrderProductForResultDto> OrderProducts { get; set; }

    }
}
