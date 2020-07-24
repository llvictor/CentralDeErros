using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Domain.Entities
{
    public class Environment : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Error> Errors { get; set; }
    }
}
