using CentralDeErros.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Environment = CentralDeErros.Domain.Enum.Environment;

namespace CentralDeErros.Api.DTO
{
    public class LogFilterDTO
    {
        public Environment environment;
        public OrderBy orderBy;
        public SearchBy searchBy;
        public string search;
    }
}
