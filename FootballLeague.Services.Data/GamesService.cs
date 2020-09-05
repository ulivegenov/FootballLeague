namespace FootballLeague.Services.Data
{
    using FootballLeague.Data.Models;
    using FootballLeague.Data.Repositories;

    public class GamesService : BaseService<Game, int>
    {
        private readonly BaseEntityRepository<Game, int> gamesRepository;

        public GamesService(BaseEntityRepository<Game, int> gamesRepository)
            : base(gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }
    }
}
