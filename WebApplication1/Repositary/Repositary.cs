using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

using System.Runtime.CompilerServices;

using WebApplication1.DBContexts;
using WebApplication1.Entity;

namespace WebApplication1.Repositary
{
    public class Repositary<TEntity> : IRepositary<TEntity> where TEntity : class
    {
        private readonly UserContext _userContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repositary(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task DeleteAsync(TEntity entity, int id)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entity = await _dbSet.ToListAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task GetByIdAsync(int userId)
        {
            await _dbSet.FindAsync(userId).ConfigureAwait(false);
        }

        public async Task UpdateAsync(TEntity entity,int id)
        {

        }
        public async Task<int> SaveChangesAsync()
        {
            return await _userContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
