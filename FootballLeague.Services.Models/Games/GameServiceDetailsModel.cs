namespace FootballLeague.Services.Models.Games
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Data.Models;
    using FootballLeague.Data.Models.Enums.Team;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Contracts;

    public class GameServiceDetailsModel : IServiceDetailsModel<int>, IMapFrom<Game>, IMapTo<Game>
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int HomeTeamGoals { get; set; }

        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int AwayTeamGoals { get; set; }

        public GameStatus Status { get; set; }

        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }
    }
}
