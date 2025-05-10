using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Topic.DTOLayer.Dtos.SubscriberDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mapping
{
    public class SubscriberMapping : Profile
    {
        public SubscriberMapping()
        {
            CreateMap<Subscriber, CreateSubscriberDto>().ReverseMap();
           

        }

    }
}
