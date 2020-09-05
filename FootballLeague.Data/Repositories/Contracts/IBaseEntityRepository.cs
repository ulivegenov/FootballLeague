namespace FootballLeague.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBaseEntityRepository<TEntity, TKey>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(TKey entityId);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<TEntity> HardDelete(TKey entityId);

        Task<int> SaveChangesAsync();
    }
}
