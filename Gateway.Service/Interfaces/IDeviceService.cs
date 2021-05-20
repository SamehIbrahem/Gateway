using GatewayTask.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTask.Service.Interfaces
{
    public interface IDeviceService
    {
        Task<DeviceDto> GetDevice(int id);
        Task<List<DeviceDto>> GetAsync();
        Task<DeviceDto> CreateDevice(CreateDeviceDto dto, int gatewayId);
        Task<DeviceDto> DeleteDevice(int id);
        Task<DeviceDto> GetDevice(int id, int gatewayId);
    }
}
