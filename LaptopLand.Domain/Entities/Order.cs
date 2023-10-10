using LaptopLand.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Domain.Entities
{
    public class Order : Audiotable
    {
        public long CustomerId {  get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}
