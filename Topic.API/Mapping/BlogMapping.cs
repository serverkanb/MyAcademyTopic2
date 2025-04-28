using AutoMapper;
using Topic.DTOLayer.Dtos.BlogDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mapping
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<CreateBlogDto,Blog>().ReverseMap();
            CreateMap<UpdateBlogDto,Blog>().ReverseMap();
            CreateMap<ResultBlogDto,Blog>().ReverseMap();
        }

    }
}
