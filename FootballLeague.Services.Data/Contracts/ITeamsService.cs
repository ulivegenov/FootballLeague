namespace FootballLeague.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeamsService
    {
        Task<IEnumerable<T>> GetRankTable<T>();
    }
}
