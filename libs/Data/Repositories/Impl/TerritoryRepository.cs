using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Data.Views;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Impl
{
    public class TerritoryRepository : Repository<Territory>, ITerritoryRepository
    {
        public TerritoryRepository(WeddingRentalDbContext context) : base(context)
        {
        }

        public Task<List<TerritoryView>> GetAllAsync()
        {
            return Source.Select(item => new TerritoryView
            {
                Id = item.Id,
                Name = item.CountryName
            }).ToListAsync();
        }
    }
}