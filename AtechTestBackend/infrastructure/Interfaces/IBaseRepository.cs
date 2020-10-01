using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechTestBackend.infrastructure.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Dispose();
    }
}
