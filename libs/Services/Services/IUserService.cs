using System.Threading.Tasks;
using Services.Descriptors;

namespace Services.Services
{
    public interface IUserService
    {
        Task<int> GetUserCountAsync();
        Task CreateAdministratorAsync(AdminDescriptor descriptor);
    }
}