using AutoMapper;
using Topic.DTOLayer.Dtos.ContactDto;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();
        }
    }
}
