using GatewayTask.Data.Entities;
using GatewayTask.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTask.Service.Interfaces
{
    public interface IGatewayService
    {
        Task<GatewayDto> GetGateway(int id);
        Task<List<GatewayDto>> GetAsync();
        Task<GatewayDto> CreateGateway(CreateGatewayDto dto);
    }
}
