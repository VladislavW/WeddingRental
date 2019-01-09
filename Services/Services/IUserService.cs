using System.Threading.Tasks;

namespace Services.Services
{
    public interface IUserService
    {
        Task<int[]> GetUserIdsAsync();
    }
}