using CentralDeErros.Datas.Contexto;
using CentralDeErros.Domain.Entities;
using CentralDeErros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Datas.Repository
{
    public class RepositoryLog : BaseRepository<Log>, IRepositoryLog
    {
        public RepositoryLog(Context context)
            : base(context)
        {

        }
    }
}
