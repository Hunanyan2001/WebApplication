using Microsoft.EntityFrameworkCore;

using WebApplication1.DBContexts;
using WebApplication1.Models;

namespace WebApplication1.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly UserContext _userContext;

        public AccountManager(UserContext userContext)
        {
            _userContext = userContext; 
        }
        public async Task ChangePasswordAsync(string userId, string newPassword)
        {
            User user = await _userContext.Users.FindAsync(userId).ConfigureAwait(false);
            if (user == null)
            {
                // Handle user not found scenario
            }

            user.Password = newPassword;

            await _userContext.SaveChangesAsync();
        }

        public async Task<User> LoginUserAsync(LoginUserModel user)
        {
            User loggedInUser = await _userContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password).ConfigureAwait(false);

            return loggedInUser;
        }

        public async Task<User> RegisterUserAsync(RegisterUserModel user)
        {
            User newUser = new User
            {
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
            };

            // Add the new user to the user context
            _userContext.Users.Add(newUser);

            await _userContext.SaveChangesAsync();

            return newUser;
        }
    }
}
