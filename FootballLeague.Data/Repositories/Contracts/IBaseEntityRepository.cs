namespace FootballLeague.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseEntityRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int entityId);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<TEntity> HardDelete(int entityId);
    }
}
