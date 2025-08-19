using System;
using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;

namespace ApiProjeKampi.WebApi.Mapping;

public class GeneralMapping:Profile // autoMapper Profile class
{
    public GeneralMapping()
    {
        CreateMap<Feature,ResultFeatureDto>().ReverseMap();
        CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature,GetByIdFeatureDto>().ReverseMap();
        CreateMap<Feature,CreateFeatureDto>().ReverseMap();

        CreateMap<Message,ResultMessageDto>().ReverseMap();
        CreateMap<Message,UpdateMessageDto>().ReverseMap();
        CreateMap<Message,GetByIdMessageDto>().ReverseMap();
        CreateMap<Message,CreateMessageDto>().ReverseMap();
    }
}
