using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api
{
    public class Token
    {
        public string Secret { get; set; }
        public int Expiration { get; set; }
        public string Emitter { get; set; }
        public string ValidAt { get; set; }
    }
}
