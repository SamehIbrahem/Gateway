using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Service.Dtos
{
    public class CreateGatewayDto
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4Address { get; set; }
    }
}
