namespace FootballLeague.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using FootballLeague.Services.Data.Contracts;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Teams;
    using FootballLeague.Web.ViewModels.Errors;
    using FootballLeague.Web.ViewModels.Teams;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeamsService teamsService;

        public HomeController(
                              ILogger<HomeController> logger,
                              ITeamsService teamsService)
        {
            _logger = logger;
            this.teamsService = teamsService;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await this.teamsService.GetRankTable<TeamServiceDetailsModel>();
            var viewModel = new TeamWebAllModel();

            this.AddEntitiesToViewModel(viewModel, teams);

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void AddEntitiesToViewModel(TeamWebAllModel viewModel, IEnumerable<TeamServiceDetailsModel> entities)
        {
            foreach (var entity in entities)
            {
                viewModel.Entities.Add(entity.To<TeamWebDetailsModel>());
            }
        }
    }
}

