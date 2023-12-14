using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile() 
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }        
    }
}
