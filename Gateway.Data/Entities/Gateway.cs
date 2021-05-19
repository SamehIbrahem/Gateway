using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Data.Entities
{
    public class Gateway : BaseAuditClass
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4Address { get; set; }

        public ICollection<Device> Devices { get; set; }
    }
}
