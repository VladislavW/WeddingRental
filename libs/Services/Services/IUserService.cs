using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Views;
using Entities.Identity;
using Services.Descriptors;

namespace Services.Services
{
    public interface IUserService
    {
        Task<int> GetUserCountAsync();
        Task CreateAdministratorAsync(AdminDescriptor descriptor);

        Task<List<TerritoryView>> GetTerritoriesAsync();
        Task UpdateTerritoryAsync(User user, int? territoryId);
        Task<string> GetCountryNameByAsync(int userId);
    }
}