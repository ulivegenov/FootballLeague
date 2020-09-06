namespace FootballLeague.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using FootballLeague.Data.Models;
    using FootballLeague.Services.Data;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Games;
    using FootballLeague.Services.Models.Teams;
    using FootballLeague.Web.ViewModels.Games;
    using FootballLeague.Web.ViewModels.Teams;

    using Microsoft.AspNetCore.Mvc;

    public class GamesController : BaseEntityController<Game, int, GameWebInputModel, GameServiceInputModel,
                                                        GameServiceDetailsModel, GameWebAllModel, GameWebDetailsModel>
    {
        private readonly BaseService<Game, int> gamesService;
        private readonly BaseService<Team, int> teamsService;

        public GamesController(
                               BaseService<Game, int> gamesService,
                               BaseService<Team, int> teamsService)
            : base(gamesService)
        {
            this.gamesService = gamesService;
            this.teamsService = teamsService;
        }

        public override async Task<IActionResult> Create()
        {
            var inputModel = new GameWebInputModel();
            await this.AddTeamsToInputModel(inputModel);

            return this.View(inputModel);
        }

        [HttpPost]
        public override async Task<IActionResult> Create(GameWebInputModel gameWebInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                await this.AddTeamsToInputModel(gameWebInputModel);
                return this.View(gameWebInputModel);
            }

            var gameServiceModel = gameWebInputModel.To<GameServiceInputModel>();

            await this.gamesService.CreateAsync(gameServiceModel);

            return this.Redirect("/Games/All");
        }

        public override async Task<IActionResult> Edit(GameWebDetailsModel gameEditModel)
        {
            if (!this.ModelState.IsValid)
            {
                var entity = await this.gamesService.GetByIdAsync<GameServiceDetailsModel>(gameEditModel.Id);
                var viewModel = entity.To<GameWebDetailsModel>();

                return this.View(viewModel);
            }

            var serviceEntity = gameEditModel.To<GameServiceDetailsModel>();

            await this.gamesService.EditAsync(serviceEntity);

            return this.Redirect($"/Games/Details/{serviceEntity.Id}");
        }

        private async Task AddTeamsToInputModel(GameWebInputModel gameWebInputModel)
        {
            var teams = await this.teamsService.GetAllAsync<TeamServiceDetailsModel>();

            gameWebInputModel.Teams = teams.Select(t => t.To<TeamWebDetailsModel>()).ToList();
        }
    }
}
