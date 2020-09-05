namespace FootballLeague.Services.Models.Games
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Data.Models.Enums.Team;
    using FootballLeague.Services.Models.Contracts;

    public class GameServiceInputModel : IServiceInputModel
    {
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int HomeTeamGoals { get; set; }

        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int AwayTeamGoals { get; set; }

        public GameStatus Status { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public virtual int AwayTeamId { get; set; }
    }
}
