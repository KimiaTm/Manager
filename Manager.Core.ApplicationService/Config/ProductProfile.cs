using AutoMapper;
using Manager.Core.Domain.DTOs;
using Manager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Core.ApplicationService.Config
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductDTO>();
            CreateMap<ProductDTO, Products>();
        }
    }
}
