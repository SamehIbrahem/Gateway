using GatewayTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTask.Service.Interfaces
{
    public interface IGatewayService
    {
        Task<Gateway> GetGateway(int id);
        Task<List<Gateway>> GetAsync();
    }
}
