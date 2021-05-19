using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayTask.Data.Entities
{
    public class BaseAuditClass
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
