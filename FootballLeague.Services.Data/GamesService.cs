namespace FootballLeague.Services.Data
{
    using System;
    using System.Linq;
    
    using FootballLeague.Common;
    using FootballLeague.Data.Models;
    using FootballLeague.Data.Repositories;
    using FootballLeague.Services.Models.Contracts;
    using FootballLeague.Services.Mapping;
    using System.Threading.Tasks;
    
    using Microsoft.EntityFrameworkCore;

    public class GamesService : BaseService<Game, int>
    {
        private readonly BaseEntityRepository<Game, int> gamesRepository;
        private readonly BaseEntityRepository<Team, int> teamsRepository;

        public GamesService(
                            BaseEntityRepository<Game, int> gamesRepository,
                            BaseEntityRepository<Team, int> teamsRepository)
            : base(gamesRepository)
        {
            this.gamesRepository = gamesRepository;
            this.teamsRepository = teamsRepository;
        }

        public override async Task<int> CreateAsync(IServiceInputModel servicesInputViewModel)
        {
            var game = servicesInputViewModel.To<Game>();

            await this.gamesRepository.AddAsync(game);
            await this.UpdateTeamsData(game);

            var result = await this.gamesRepository.SaveChangesAsync();

            return result;
        }

        public override async Task<int> EditAsync(IServiceDetailsModel<int> serviceDetailsModel)
        {
            var gameFromD = await this.gamesRepository.GetByIdAsync(serviceDetailsModel.Id);
            await this.SubtractTeamsData(gameFromD);

            var game = serviceDetailsModel.To<Game>();

            await this.gamesRepository.UpdateAsync(game);
            var result = await this.gamesRepository.SaveChangesAsync();

            var updatedGame = await this.gamesRepository.GetByIdAsync(serviceDetailsModel.Id);
            await this.UpdateTeamsData(updatedGame);
            await this.gamesRepository.SaveChangesAsync();

            return result;
        }

        public override async Task<int> DeleteByIdAsync(int id)
        {
            var game = await this.gamesRepository.GetByIdAsync(id);

            if (game == null)
            {
                throw new ArgumentNullException(string.Format(GlobalConstants.InvalidTEntityIdErrorMessage, nameof(Game), id));
            }

            await this.SubtractTeamsData(game);
            await this.gamesRepository.DeleteAsync(game);
            
            var result = await this.gamesRepository.SaveChangesAsync();

            return result;
        }

        public override async Task<T> GetByIdAsync<T>(int id)
        {
            var game = await this.gamesRepository.GetAll()
                                                   .Where(e => id.Equals(e.Id))
                                                   .Select(g => new Game
                                                   {
                                                       Id = g.Id,
                                                       CreatedOn = g.CreatedOn,
                                                       HomeTeamId = g.HomeTeamId,
                                                       AwayTeamId = g.AwayTeamId,
                                                       HomeTeam = new Team 
                                                                  { 
                                                                    Name = g.HomeTeam.Name,
                                                                    GoalsFor = g.HomeTeam.GoalsFor,
                                                                    GoalsAgainst = g.HomeTeam.GoalsAgainst,
                                                                    Wins = g.HomeTeam.Wins,
                                                                    Draws = g.HomeTeam.Draws,
                                                                    Losts = g.HomeTeam.Losts,
                                                                    Points = g.HomeTeam.Points,
                                                                  },
                                                       AwayTeam = new Team 
                                                                  {
                                                                    Name = g.AwayTeam.Name,
                                                                    GoalsFor = g.AwayTeam.GoalsFor,
                                                                    GoalsAgainst = g.AwayTeam.GoalsAgainst,
                                                                    Wins = g.AwayTeam.Wins,
                                                                    Draws = g.AwayTeam.Draws,
                                                                    Losts = g.AwayTeam.Losts,
                                                                    Points = g.AwayTeam.Points,
                                                                   },
                                                       HomeTeamGoals = g.HomeTeamGoals,
                                                       AwayTeamGoals = g.AwayTeamGoals,
                                                   })
                                                   .To<T>()
                                                   .FirstOrDefaultAsync();

            return game;
        }

        private async Task UpdateTeamsData(Game game)
        {
            await this.teamsRepository.GetByIdAsync(game.HomeTeamId);
            await this.teamsRepository.GetByIdAsync(game.AwayTeamId);
            this.AddPointsToTeams(game, game.HomeTeam, game.AwayTeam);
            this.AddGoalsToTeams(game, game.HomeTeam, game.AwayTeam);
        }

        private async Task SubtractTeamsData(Game game)
        {
            await this.teamsRepository.GetByIdAsync(game.HomeTeamId);
            await this.teamsRepository.GetByIdAsync(game.AwayTeamId);
            this.SubtractPointsToTeams(game, game.HomeTeam, game.AwayTeam);
            this.SubtractGoalsToTeams(game, game.HomeTeam, game.AwayTeam);
        }

        private void AddPointsToTeams(Game game, Team homeTeam, Team awayTeam)
        {
            if (game.HomeTeamGoals > game.AwayTeamGoals)
            {
                homeTeam.Wins += 1;
                awayTeam.Losts += 1;
                homeTeam.Points += 3;
            }
            else if (game.HomeTeamGoals < game.AwayTeamGoals)
            {
                homeTeam.Losts += 1;
                awayTeam.Wins += 1;
                awayTeam.Points += 3;
            }
            else
            {
                homeTeam.Draws += 1;
                awayTeam.Draws += 1;
                homeTeam.Points += 1;
                awayTeam.Points += 1;
            }
        }

        private void AddGoalsToTeams(Game game, Team homeTeam, Team awayTeam)
        {
            homeTeam.GoalsFor += game.HomeTeamGoals;
            homeTeam.GoalsAgainst += game.AwayTeamGoals;
            awayTeam.GoalsFor += game.AwayTeamGoals;
            awayTeam.GoalsAgainst += game.HomeTeamGoals;
        }

        private void SubtractPointsToTeams(Game game, Team homeTeam, Team awayTeam)
        {
            if (game.HomeTeamGoals > game.AwayTeamGoals)
            {
                homeTeam.Wins -= 1;
                awayTeam.Losts -= 1;
                homeTeam.Points -= 3;
            }
            else if (game.HomeTeamGoals < game.AwayTeamGoals)
            {
                homeTeam.Losts -= 1;
                awayTeam.Wins -= 1;
                awayTeam.Points -= 3;
            }
            else
            {
                homeTeam.Draws -= 1;
                awayTeam.Draws -= 1;
                homeTeam.Points -= 1;
                awayTeam.Points -= 1;
            }
        }

        private void SubtractGoalsToTeams(Game game, Team homeTeam, Team awayTeam)
        {
            homeTeam.GoalsFor -= game.HomeTeamGoals;
            homeTeam.GoalsAgainst -= game.AwayTeamGoals;
            awayTeam.GoalsFor -= game.AwayTeamGoals;
            awayTeam.GoalsAgainst -= game.HomeTeamGoals;
        }
    }
}
