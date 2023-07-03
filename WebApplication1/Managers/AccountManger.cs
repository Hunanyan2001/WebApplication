using WebApplication1.Models;

namespace WebApplication1.Managers
{
    public class AccountManger : IAccountManger
    {
        public Task ChangePasswordAsync(string userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginUserAsync(LoginUserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<User> RegisterUserAsync(RegisterUserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
