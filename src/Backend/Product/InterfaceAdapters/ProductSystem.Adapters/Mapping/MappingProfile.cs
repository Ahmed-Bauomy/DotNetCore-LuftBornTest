using AutoMapper;
using ProductSystem.Application.Features.Commands.CreateProduct;
using ProductSystem.Application.Features.Commands.UpdateProduct;
using ProductSystem.Application.Models;
using ProductSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Adapters.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}
