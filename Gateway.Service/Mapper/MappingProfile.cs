using AutoMapper;
using GatewayTask.Data.Entities;
using GatewayTask.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Service.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Gateway, GatewayDto>().ReverseMap();
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<CreateGatewayDto, Gateway>().ReverseMap();
            CreateMap<CreateDeviceDto, Device>().ReverseMap();
        }
    }
}
