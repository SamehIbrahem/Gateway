using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayTask.Service.Dtos;
using GatewayTask.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GatewayTask.Web.Controllers
{
    [Route("api/Gateway/{gatewayId}/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService deviceService;
        public DevicesController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<DeviceDto> GetDevice(int gatewayId, int id)
        {
            return deviceService.GetDevice(id, gatewayId);
        }

        [HttpGet]
        [Route("")]
        public Task<List<DeviceDto>> GetAsync()
        {
            return deviceService.GetAsync();
        }

        [HttpPost]
        public Task<DeviceDto> CreateDevice(int gatewayId, CreateDeviceDto dto)
        {
            return deviceService.CreateDevice(dto, gatewayId);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<DeviceDto> DeleteDevice(int id)
        {
            return deviceService.DeleteDevice(id);
        }
    }
}