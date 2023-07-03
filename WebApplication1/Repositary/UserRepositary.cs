using Microsoft.EntityFrameworkCore;

using System.Runtime.CompilerServices;

using WebApplication1.DBContexts;
using WebApplication1.Models;

namespace WebApplication1.Repositary
{
    public class UserRepositary : IUserRepositary
    {
        private readonly UserContext _userContext;

        public UserRepositary(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync().ConfigureAwait(false);
            return user;
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userContext.Users.FindAsync(userId).ConfigureAwait(false);
            if (user != null)
            {
               _userContext.Users.Remove(user);
                await _userContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userContext.Users.ToListAsync().ConfigureAwait(false);
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userContext.Users.FindAsync(userId).ConfigureAwait(false);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
           _userContext.Entry(user).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();
            return user;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _userContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
