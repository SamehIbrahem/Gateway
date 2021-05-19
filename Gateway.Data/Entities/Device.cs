using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Data.Entities
{
    public class Device : BaseAuditClass
    {
        public long UID { get; set; }
        public string Vendor { get; set; }
        public bool Status { get; set; }
    }
}
