using AutoMapper;
using GatewayTask.Data.Entities;
using GatewayTask.Repo.Data;
using GatewayTask.Service.Dtos;
using GatewayTask.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTask.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepository<Device> deviceRepository;
        private readonly IRepository<Gateway> gatewayRepository;
        private readonly IMapper mapper;
        public DeviceService(IRepository<Device> deviceRepository, IRepository<Gateway> gatewayRepository, IMapper mapper)
        {
            this.deviceRepository = deviceRepository;
            this.mapper = mapper;
            this.gatewayRepository = gatewayRepository;
        }

        public async Task<List<DeviceDto>> GetAsync()
        {
            return mapper.Map<List<DeviceDto>>(await deviceRepository.GetAll());
        }

        public async Task<DeviceDto> GetDevice(int id)
        {
            return mapper.Map<DeviceDto>(await deviceRepository.Get(id));
        }

        public Task<DeviceDto> GetDevice(int id, int gatewayId)
        {
            var entity = deviceRepository.AsQueryable().FirstOrDefault(e => e.GatewayId == gatewayId && e.Id == id);
            return Task.FromResult(mapper.Map<DeviceDto>(entity));
        }

        public async Task<DeviceDto> CreateDevice(CreateDeviceDto dto, int gatewayId)
        {
            var entity = mapper.Map<Device>(dto);
            var gateway = await gatewayRepository.Get(gatewayId, e => e.Devices);
            if (gateway.Devices.Count >= 10)
                throw new InvalidOperationException("Gateway already have the max device count.");

            entity.GatewayId = gatewayId;
            entity.Created = DateTime.Now;
            return mapper.Map<DeviceDto>(await deviceRepository.Insert(entity));
        }

        public async Task<DeviceDto> DeleteDevice(int id)
        {
            var entity = await deviceRepository.Get(id);
            return mapper.Map<DeviceDto>(await deviceRepository.Delete(entity));
        }
    }
}
