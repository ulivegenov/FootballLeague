namespace FootballLeague.Services.Data
{
    using FootballLeague.Data.Models;
    using FootballLeague.Data.Repositories;

    public class TeamsService : BaseService<Team, int>
    {
        private readonly BaseEntityRepository<Team, int> teamsRepository;

        public TeamsService(BaseEntityRepository<Team, int> teamsRepository)
            : base(teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }
    }
}
