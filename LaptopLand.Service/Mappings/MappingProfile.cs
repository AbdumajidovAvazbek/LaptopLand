using AutoMapper;
using LaptopLand.Domain.Entities;
using LaptopLand.Service.Dtos.Category;
using LaptopLand.Service.Dtos.Customer;
using LaptopLand.Service.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopLand.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryForResultDto>().ReverseMap();
                cfg.CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
                cfg.CreateMap<Category, CategoryForCreationDto>().ReverseMap();
                cfg.CreateMap<Product, ProductForResultDto>().ReverseMap();
                cfg.CreateMap<Product, ProductForUpdateDto>().ReverseMap();
                cfg.CreateMap<Product, ProductForCreationDto>().ReverseMap();
                cfg.CreateMap<Customer, CustomerForResultDto>().ReverseMap();
                cfg.CreateMap<Customer, CustomerForUpdateDto>().ReverseMap();
                cfg.CreateMap<Customer, CustomerForCreationDto>().ReverseMap();
            });
            return config.CreateMapper();
        }
    }
}
