using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Dtos.OrderProduct
{
    public class OrderProductForResultDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
    }
}
