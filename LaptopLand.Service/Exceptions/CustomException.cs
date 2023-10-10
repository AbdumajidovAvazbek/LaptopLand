using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Exceptions
{
    public class CustomException : Exception 
    {
        public int statusCode {  get; set; }
        public CustomException(int code,string message) : base (message) 
        {
            statusCode = code;
        }
    }
}
