using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayTask.Data.Entities;
using GatewayTask.Service.Dtos;
using GatewayTask.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GatewayTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewaysController : ControllerBase, IGatewayService
    {
        private readonly IGatewayService gatewayService;

        public GatewaysController(IGatewayService gatewayService)
        {
            this.gatewayService = gatewayService;
        }

        [HttpGet]
        [Route("")]
        public Task<List<GatewayDto>> GetAsync()
        {
            return gatewayService.GetAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<GatewayDto> GetGateway(int id)
        {
            return gatewayService.GetGateway(id);
        }
    }
}