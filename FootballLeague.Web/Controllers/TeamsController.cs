namespace FootballLeague.Web.Controllers
{
    using FootballLeague.Data.Models;
    using FootballLeague.Services.Data;
    using FootballLeague.Services.Models.Teams;
    using FootballLeague.Web.ViewModels.Teams;

    public class TeamsController : BaseEntityController<Team, int, TeamWebInputModel, TeamServiceInputModel,
                                                        TeamServiceDetailsModel, TeamWebAllModel, TeamWebDetailsModel>
    {
        private readonly BaseService<Team, int> teamsService;

        public TeamsController(BaseService<Team, int> teamsService)
            : base(teamsService)
        {
            this.teamsService = teamsService;
        }
    }
}
