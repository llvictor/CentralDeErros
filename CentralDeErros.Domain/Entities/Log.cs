using CentralDeErros.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Text;
using Environment = CentralDeErros.Domain.Enum.Environment;

namespace CentralDeErros.Domain.Entities
{
    public class Log : EntityBase
    {
        public string Description { get; set; } 
        public string Details { get; set; }
        public string Origin { get; set; }
        public int UserId { get; set; }
        public int Frequency { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public bool Archived {get; set;}
        public Environment Environment { get; set; }

    }
}
