using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Persistence;
using Data.Views;
using Entities;

namespace Data.Repositories
{
    public interface ITerritoryRepository: IRepository<Territory>
    {
        Task<List<TerritoryView>> GetAllAsync();
    }
}