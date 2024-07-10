using GraphQL.Dto;
using GraphQL.Models;
using AutoMapper;

namespace GraphQL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
        }
    }
}
