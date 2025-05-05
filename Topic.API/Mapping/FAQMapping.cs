using AutoMapper;
using Topic.DTOLayer.Dtos.BlogDtos;
using Topic.DTOLayer.Dtos.FAQ;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mapping
{
    public class FAQMapping : Profile
    {
        public FAQMapping()
        {
            CreateMap<ResultFAQDto, FAQ>().ReverseMap();
            CreateMap<CreateFAQDto, FAQ>().ReverseMap();
            CreateMap<UpdateFAQDto, FAQ>().ReverseMap();
        }
    }
}
