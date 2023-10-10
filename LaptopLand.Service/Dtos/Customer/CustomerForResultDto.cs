using LaptopLand.Service.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Dtos.Customer
{
    public class CustomerForResultDto
    {
        public long Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<ProductForResultDto> Products { get; set; }

    }
}
