namespace FootballLeague.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballLeague.Data.Repositories.Contracts;

    public abstract class BaseEntityRepository<TEntity, TKey> : IBaseEntityRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly FootballLeagueDbContext footballLeagueDbContext;

        public BaseEntityRepository(FootballLeagueDbContext footballLeagueDbContext)
        {
            this.footballLeagueDbContext = footballLeagueDbContext;
        }

        public abstract Task<TEntity> AddAsync(TEntity entity);

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var result = await this.GetEntityFromDbAsync(entity);

            if (result != null)
            {
                this.MarkEntityAsDeleted(result, entity);

                await this.footballLeagueDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public abstract IQueryable<TEntity> GetAll();

        public async Task<TEntity> GetByIdAsync(TKey entityId)
            => await this.GetEntityFromDbAsync(entityId);

        public abstract Task<TEntity> HardDelete(TKey entityId);

        public Task<int> SaveChangesAsync() 
            => this.footballLeagueDbContext.SaveChangesAsync();

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = await this.GetEntityFromDbAsync(entity);

            if (result != null)
            {
                this.MapModelToDbEntity(result, entity);

                await this.footballLeagueDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        protected abstract Task<TEntity> GetEntityFromDbAsync(TEntity entity);

        protected abstract Task<TEntity> GetEntityFromDbAsync(TKey entityId);

        protected abstract void MapModelToDbEntity(TEntity dbEntity, TEntity entity);

        protected abstract void MarkEntityAsDeleted(TEntity dbEntity, TEntity entity);
    }
}
