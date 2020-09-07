namespace FootballLeague.Services.Models.Games
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Data.Models;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Contracts;

    public class GameServiceInputModel : IServiceInputModel, IMapTo<Game>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int HomeTeamGoals { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int AwayTeamGoals { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public int HomeTeamId { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public virtual int AwayTeamId { get; set; }
    }
}
