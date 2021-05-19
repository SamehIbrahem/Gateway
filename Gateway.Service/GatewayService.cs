using GatewayTask.Data.Entities;
using GatewayTask.Repo.Data;
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

        public GatewayService(IRepository<Gateway> gatewayRepository)
        {
            this.gatewayRepository = gatewayRepository;
        }

        public async Task<List<Gateway>> GetAsync()
        {
            return await gatewayRepository.GetAll();

        }

        public async Task<Gateway> GetGateway(int id)
        {
            return await gatewayRepository.Get(id);
        }
    }
}
