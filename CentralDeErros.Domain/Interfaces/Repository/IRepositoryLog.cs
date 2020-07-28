using CentralDeErros.Domain.Entities;
using CentralDeErros.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Environment = CentralDeErros.Domain.Enum.Environment;

namespace CentralDeErros.Domain.Interfaces.Repository
{
    public interface IRepositoryLog : IBaseRepository<Log>
    {
        IEnumerable<Log> getLogsFiltered(Environment environment, OrderBy orderBy, SearchBy searchBy, string search);
        bool ArchiveLog(int id);
    }
}
