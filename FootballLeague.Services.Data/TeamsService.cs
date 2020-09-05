namespace FootballLeague.Services.Data
{
    using FootballLeague.Data.Models;
    using FootballLeague.Data.Repositories.Contracts;

    public class TeamsService : BaseService<Team, int>
    {
        private readonly IBaseEntityRepository<Team, int> teamsRepository;

        public TeamsService(IBaseEntityRepository<Team, int> teamsRepository)
            : base(teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }
    }
}
