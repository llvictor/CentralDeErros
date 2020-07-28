using CentralDeErros.Datas.Contexto;
using CentralDeErros.Domain.Entities;
using CentralDeErros.Domain.Enum;
using CentralDeErros.Domain.Interfaces.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Environment = CentralDeErros.Domain.Enum.Environment;

namespace CentralDeErros.Datas.Repository
{
    public class RepositoryLog : BaseRepository<Log>, IRepositoryLog
    {

        public RepositoryLog(Context context)
            : base(context)
        {
        }

        public bool ArchiveLog(int id)
        {
            var log = _context.Log.Find(id);

            if (log != null)
            {
                log.Archived = true;
            }

            _context.Update(log);
            _context.SaveChanges();
            return true;
            
        }

        public IEnumerable<Log> getLogsFiltered(Environment environment, OrderBy orderBy, SearchBy searchBy, string search)
        {
            var content = _context.Log.Where(x => x.Environment.Equals(environment));

            switch(searchBy)
            {
                case SearchBy.Description:
                    content = content.Where(x => x.Description.Contains(search));
                    break;
                case SearchBy.Level:
                    content = content.Where(x => x.Level.Equals(search));
                    break;
                case SearchBy.Origin:
                    content = content.Where(x => x.Origin.Equals(search));
                    break;

            }

            switch (orderBy)
            {
                case OrderBy.Frequency:
                    content = content.OrderBy(x => x.Frequency);
                    break;
                case OrderBy.Level:
                    content = content.OrderBy(x => x.Level);
                    break;
            }

            return content.ToList();
        }

    }
}
