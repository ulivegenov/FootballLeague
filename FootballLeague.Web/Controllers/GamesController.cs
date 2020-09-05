namespace FootballLeague.Web.Controllers
{
    using FootballLeague.Data.Models;
    using FootballLeague.Services.Data;
    using FootballLeague.Services.Models.Games;
    using FootballLeague.Web.ViewModels.Games;

    public class GamesController : BaseEntityController<Game, int, GameWebInputModel, GameServiceInputModel,
                                                        GameServiceDetailsModel, GamesWebAllModel, GameWebDetailsModel>
    {
        private readonly BaseService<Game, int> gamesService;

        public GamesController(BaseService<Game, int> gamesService)
            : base(gamesService)
        {
            this.gamesService = gamesService;
        }
    }
}
