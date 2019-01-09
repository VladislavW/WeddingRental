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
        
        public async Task<int[]> GetUserIdsAsync()
        {
            return await _context.Set<User>()
                .Select(item => item.Id)
                .ToArrayAsync();
        }
    }
}