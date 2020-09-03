namespace FootballLeague.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FootballLeague.Common;
    using FootballLeague.Data.Models.Enums.Team;

    public class Game
    {
        public int Id { get; set; }

        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int HomeTeamGoals { get; set; }

        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int AwayTeamGoals { get; set; }

        public GameStatus Status { get; set; }

        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }
    }
}
