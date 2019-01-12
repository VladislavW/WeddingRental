using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Persistence;
using Entities.Identity;

namespace Data.Repositories
{
    public interface IUserRepository
    {
        Task<int> GetUserCountAsync();
        Task<string> GetCountryNameByAsync(int userId);
    }
}