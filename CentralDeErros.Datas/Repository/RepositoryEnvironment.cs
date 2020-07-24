using CentralDeErros.Datas.Contexto;
using CentralDeErros.Domain.Entities;
using CentralDeErros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Datas.Repository
{
    public class RepositoryEnvironment : BaseRepository<Domain.Entities.Environment>, IRepositoryEnvironment
    {
        public RepositoryEnvironment(Context context)
            : base(context)
        {

        }
    }
}
