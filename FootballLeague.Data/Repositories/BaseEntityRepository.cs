namespace FootballLeague.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FootballLeague.Data.Repositories.Contracts;

    public abstract class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity>
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
                this.MapModelToDbEntity(result, entity);

                await this.footballLeagueDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public abstract Task<IEnumerable<TEntity>> GetAllAsync();

        public async Task<TEntity> GetByIdAsync(int entityId)
            => await this.GetEntityFromDbAsync(entityId);

        public abstract Task<TEntity> HardDelete(int entityId);

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

        protected abstract Task<TEntity> GetEntityFromDbAsync(int entityId);

        protected abstract void MapModelToDbEntity(TEntity dbEntity, TEntity entity);
    }
}
