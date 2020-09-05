﻿namespace FootballLeague.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Data.Models.Enums.Team;

    public class Game : BaseDeletableEntity<int>
    {
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int HomeTeamGoals { get; set; }

        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int AwayTeamGoals { get; set; }

        public GameStatus Status { get; set; }

        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }
    }
}
