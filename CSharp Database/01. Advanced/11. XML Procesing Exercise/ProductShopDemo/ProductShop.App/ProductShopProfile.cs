using AutoMapper;
using ProductShop.App.Dto;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.App
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
