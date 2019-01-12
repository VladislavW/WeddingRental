using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly WeddingRentalDbContext _context;

        public UserRepository(IUnitOfWork uow, WeddingRentalDbContext context)
        {
            _uow = uow;
            _context = context;
        }
        
        public async Task<int> GetUserCountAsync()
        {
            return await _context.Set<User>()
                .Select(item => item.Id)
                .CountAsync();
        }

        public async Task<string> GetCountryNameByAsync(int userId)
        {
            return await _context.Set<User>()
                .Where(item => item.Id == userId)
                .Join(
                    _uow.TerritoryRepository.Source,	 
                    e => e.TerritoryId, 		  
                    o => o.Id, 		  
                    (e, o) => o.CountryName)
                .FirstOrDefaultAsync();
        }
    }
}