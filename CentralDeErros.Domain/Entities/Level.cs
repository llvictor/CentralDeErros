using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Domain.Entities
{
    public class Level : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}
