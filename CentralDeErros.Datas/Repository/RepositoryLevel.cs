using CentralDeErros.Datas.Contexto;
using CentralDeErros.Domain.Entities;
using CentralDeErros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Datas.Repository
{
    public class RepositoryLevel : BaseRepository<Domain.Entities.Level>, IRepositoryLevel
    {
        public RepositoryLevel(Context context)
            : base(context)
        {

        }
    }
}
