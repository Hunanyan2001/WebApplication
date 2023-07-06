using WebApplication1.Entity;
using WebApplication1.Models;

namespace WebApplication1.Managers
{
    public interface IAccountManager
    {
        Task<User> RegisterUserAsync(RegisterUserModel user);
        Task<User> LoginUserAsync(LoginUserModel user);
        Task ChangePasswordAsync(int userId, string newPassword);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
    }
}
