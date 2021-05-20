using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Service.Dtos
{
    public class CreateDeviceDto
    {
        public long UID { get; set; }
        public string Vendor { get; set; }
        public bool Status { get; set; }
    }
}
