namespace FootballLeague.Web.ViewModels.Games
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Data.Models.Enums.Team;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Games;
    using FootballLeague.Web.ViewModels.Contracts;

    public class GameWebInputModel : IWebInputModel, IMapTo<GameServiceInputModel>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int HomeTeamGoals { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        public int AwayTeamGoals { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public GameStatus Status { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public int HomeTeamId { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        public int AwayTeamId { get; set; }
    }
}
