using CentralDeErros.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Text;

namespace CentralDeErros.Domain.Entities
{
    public class Error : EntityBase
    {
        public string Description { get; set; } // Microservice error
        public string Details { get; set; } // A reboot is necessary before package KB4565483 can be changed to the Installed state.
        public string Origin { get; set; } // 192.168.7.124 / Servicing
        public int User { get; set; }
        public Level Level {get; set;} // ERROR
        public int EventId { get; set; }
        public int EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
