using WebApplication1.Models;

namespace WebApplication1.Managers
{
    public interface IAccountManger
    {
        Task<User> RegisterUserAsync(RegisterUserModel user);
        Task<User> LoginUserAsync(LoginUserModel user);
        Task ChangePasswordAsync(string userId, string newPassword);
    }
}
