namespace FootballLeague.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FootballLeague.Services.Models.Contracts;

    public interface IBaseService<TKey>
    {
        Task<int> CreateAsync(IServiceInputModel servicesInputViewModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(TKey id);

        Task<int> EditAsync(IServiceDetailsModel<TKey> serviceDetailsModel);

        Task<int> DeleteByIdAsync(TKey id);
    }
}
