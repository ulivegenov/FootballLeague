namespace FootballLeague.Services.Data
{
    using System.Linq;

    using FootballLeague.Data.Models;
    using FootballLeague.Data.Repositories;
    using FootballLeague.Services.Mapping;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using FootballLeague.Services.Data.Contracts;

    public class TeamsService : BaseService<Team, int>, ITeamsService
    {
        private readonly BaseEntityRepository<Team, int> teamsRepository;

        public TeamsService(BaseEntityRepository<Team, int> teamsRepository)
            : base(teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public override async Task<T> GetByIdAsync<T>(int id)
        {
            var team = await this.teamsRepository.GetAll()
                                                  .Where(t => t.Id.Equals(id))
                                                  .Select(t => new Team
                                                  {
                                                      Id = t.Id,
                                                      Name = t.Name,
                                                      GoalsFor = t.GoalsFor,
                                                      GoalsAgainst = t.GoalsAgainst,
                                                      Wins = t.Wins,
                                                      Draws = t.Draws,
                                                      Losts = t.Losts,
                                                      Points = t.Points,
                                                      HomeGames = t.HomeGames.Select(hm => new Game { Id = hm.Id }).ToList(),
                                                      AwayGames = t.AwayGames.Select(hm => new Game { Id = hm.Id }).ToList(),
                                                  })
                                                  .To<T>()
                                                  .FirstOrDefaultAsync();

            return team;
        }

        public override async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var teams = await this.teamsRepository.GetAll()
                                                  .Select(t => new Team
                                                  {
                                                      Id = t.Id,
                                                      Name = t.Name,
                                                      GoalsFor = t.GoalsFor,
                                                      GoalsAgainst = t.GoalsAgainst,
                                                      Wins = t.Wins,
                                                      Draws = t.Draws,
                                                      Losts = t.Losts,
                                                      Points = t.Points,
                                                      HomeGames = t.HomeGames.Select(hm => new Game { Id = hm.Id }).ToList(),
                                                      AwayGames = t.AwayGames.Select(hm => new Game { Id = hm.Id }).ToList(),
                                                  })
                                                  .To<T>()
                                                  .ToListAsync();

            return teams;
        }

        public async Task<IEnumerable<T>> GetRankTable<T>()
        {
            var teams = await this.teamsRepository.GetAll()
                                                  .Select(t => new Team
                                                  {
                                                      Id = t.Id,
                                                      Name = t.Name,
                                                      GoalsFor = t.GoalsFor,
                                                      GoalsAgainst = t.GoalsAgainst,
                                                      Wins = t.Wins,
                                                      Draws = t.Draws,
                                                      Losts = t.Losts,
                                                      Points = t.Points,
                                                      HomeGames = t.HomeGames.Select(hm => new Game { Id = hm.Id }).ToList(),
                                                      AwayGames = t.AwayGames.Select(hm => new Game { Id = hm.Id }).ToList(),
                                                  })
                                                  .OrderByDescending(t => t.Points)
                                                  .ThenByDescending(t => (t.GoalsFor - t.GoalsAgainst))
                                                  .To<T>()
                                                  .ToListAsync();

            return teams;
        }
    }
}
