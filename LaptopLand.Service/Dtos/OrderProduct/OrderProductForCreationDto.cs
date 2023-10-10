using LaptopLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Dtos.OrderProduct
{
    public class OrderProductForCreationDto
    {
        public long ProductId { get; set; }

        public long OrderId { get; set; }
    }
}
