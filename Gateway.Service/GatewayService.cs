using AutoMapper;
using GatewayTask.Data.Entities;
using GatewayTask.Repo.Data;
using GatewayTask.Service.Dtos;
using GatewayTask.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTask.Service
{
    public class GatewayService : IGatewayService
    {
        private readonly IRepository<Gateway> gatewayRepository;
        private readonly IMapper mapper;

        public GatewayService(IRepository<Gateway> gatewayRepository, IMapper mapper)
        {
            this.gatewayRepository = gatewayRepository;
            this.mapper = mapper;
        }

        public async Task<List<GatewayDto>> GetAsync()
        {
            return mapper.Map<List<GatewayDto>>(await gatewayRepository.GetAll(e=>e.Devices));

        }

        public async Task<GatewayDto> GetGateway(int id)
        {
            return mapper.Map<GatewayDto>(await gatewayRepository.Get(id));
        }
    }
}
