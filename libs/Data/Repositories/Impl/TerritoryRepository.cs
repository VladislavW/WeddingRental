using Data.Persistence;
using Entities;

namespace Data.Repositories.Impl
{
    public class TerritoryRepository : Repository<Territory>, ITerritoryRepository
    {
        public TerritoryRepository(WeddingRentalDbContext context) : base(context)
        {
        }
    }
}