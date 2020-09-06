namespace FootballLeague.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballLeague.Common;
    using FootballLeague.Data.Models;
    using FootballLeague.Data.Repositories;
    using FootballLeague.Services.Data.Contracts;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Contracts;

    using Microsoft.EntityFrameworkCore;

    public class BaseService<TEntity, TKey> : IBaseService<TKey>
        where TEntity : BaseDeletableEntity<TKey>
    {
        private readonly BaseEntityRepository<TEntity, TKey> baseEntityRepository;

        public BaseService(BaseEntityRepository<TEntity, TKey> baseEntityRepository)
        {
            this.baseEntityRepository = baseEntityRepository;
        }

        public virtual async Task<int> CreateAsync(IServiceInputModel servicesInputViewModel)
        {
            var entity = servicesInputViewModel.To<TEntity>();

            await this.baseEntityRepository.AddAsync(entity);
            var result = await this.baseEntityRepository.SaveChangesAsync();

            return result;
        }

        public virtual async Task<int> DeleteByIdAsync(TKey id)
        {
            var entity = await this.baseEntityRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException(string.Format(GlobalConstants.InvalidTEntityIdErrorMessage, nameof(TEntity), id));
            }

            await this.baseEntityRepository.DeleteAsync(entity);
            var result = await this.baseEntityRepository.SaveChangesAsync();

            return result;
        }

        public async Task<int> EditAsync(IServiceDetailsModel<TKey> serviceDetailsModel)
        {
            var entity = serviceDetailsModel.To<TEntity>();

            await this.baseEntityRepository.UpdateAsync(entity);
            var result = await this.baseEntityRepository.SaveChangesAsync();

            return result;
        }

        public virtual async Task<IEnumerable<IServiceDetailsModel<TKey>>> GetAllAsync()
        {
            var entities = await this.baseEntityRepository.GetAll()
                                                          .To<IServiceDetailsModel<TKey>>()
                                                          .ToListAsync();

            return entities;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var entities = await this.baseEntityRepository.GetAll()
                                                          .To<T>()
                                                          .ToListAsync();

            return entities;
        }

        public virtual async Task<T> GetByIdAsync<T>(TKey id)
        {
            var entity = await this.baseEntityRepository.GetAll()
                                                        .Where(e => id.Equals(e.Id))
                                                        .FirstOrDefaultAsync();

            var entityServiceModel = entity.To<T>();

            return entityServiceModel;
        }
    }
}
