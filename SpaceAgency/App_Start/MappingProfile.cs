using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SpaceAgency.Dtos;
using SpaceAgency.Models;

namespace SpaceAgency.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Mission, MissionDto>();
            CreateMap<MissionDto, Mission>().ForMember(m => m.Id, opt => opt.Ignore()); 

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>().ForMember(p => p.Id, opt => opt.Ignore()); 
        }
    }
}