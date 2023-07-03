using WebApplication1.Models;

namespace WebApplication1.Repositary
{
    public interface IUserRepositary
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string userId);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(string userId);

        Task<int> SaveChangesAsync();
    }
}
