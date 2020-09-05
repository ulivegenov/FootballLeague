namespace FootballLeague.Services.Data
{
    using FootballLeague.Data.Models;
    using FootballLeague.Data.Repositories.Contracts;

    public class GamesService : BaseService<Game, int>
    {
        private readonly IBaseEntityRepository<Game, int> gamesRepository;

        public GamesService(IBaseEntityRepository<Game, int> gamesRepository)
            : base(gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }
    }
}
