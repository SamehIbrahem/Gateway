using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Service.Dtos
{
    public class GatewayDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4Address { get; set; }

        public ICollection<DeviceDto> Devices { get; set; }
    }
}
