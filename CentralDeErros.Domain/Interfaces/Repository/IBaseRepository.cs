using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        T GetById(int id);
        void Delete(int id);
        List<T> List();
    }
}
