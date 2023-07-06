using WebApplication1.Entity;

namespace WebApplication1.Repositary
{
    public interface IRepositary<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity,int id);
        Task DeleteAsync(TEntity entity,int id);

        Task<int> SaveChangesAsync();
    }
}
