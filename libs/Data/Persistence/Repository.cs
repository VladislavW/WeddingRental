using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;

namespace Data.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly WeddingRentalDbContext _context;
        
        public Repository(WeddingRentalDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Source => _context.Set<TEntity>();
        
        public async Task<TEntity> FindAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}