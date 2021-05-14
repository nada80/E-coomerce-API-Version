using APi_version.DTO;
using APi_version.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APi_version.Mapper
{
    public class Mapperconfig
    {

        public static IMapper mapper { get; set; }

        static Mapperconfig()
        {
            var config = new MapperConfiguration(
          cfg =>
          {
              cfg.CreateMap<Product, ProductDto>().ReverseMap();
              cfg.CreateMap<Category, CategoryDto>().ReverseMap();
              cfg.CreateMap<ApplicationUser, UserDto>().ReverseMap();
              cfg.CreateMap<CartItem, CartItemDto>().ReverseMap();


          });

            mapper = config.CreateMapper();
        }


    }
}
