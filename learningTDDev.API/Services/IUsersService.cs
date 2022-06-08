using learningTDDev.API.Models;

namespace learningTDDev.API.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsers();
    }
}
