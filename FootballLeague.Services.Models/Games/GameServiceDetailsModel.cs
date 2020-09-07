namespace FootballLeague.Services.Models.Games
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Data.Models;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Contracts;

    public class GameServiceDetailsModel : IServiceDetailsModel<int>, IMapFrom<Game>, IMapTo<Game>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int HomeTeamGoals { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int AwayTeamGoals { get; set; }


        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }
    }
}
