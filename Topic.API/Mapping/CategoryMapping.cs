using AutoMapper;
using Topic.DTOLayer.Dtos.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<ResultCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}
