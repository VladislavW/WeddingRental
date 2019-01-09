using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;

namespace Data.Persistence
{
    internal interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Source { get; }
        
        Task<TEntity> FindAsync(int id);

        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}