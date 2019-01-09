using System.Threading.Tasks;
using Data.Repositories;

namespace Services.Services.impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int[]> GetUserIdsAsync()
        {
            return await _userRepository.GetUserIdsAsync();
        }
    }
}