namespace FootballLeague.Web.ViewModels.Games
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Games;
    using FootballLeague.Web.ViewModels.Contracts;
    using FootballLeague.Web.ViewModels.Teams;

    public class GameWebInputModel : IWebInputModel, IMapTo<GameServiceInputModel>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        [Display(Name = "Home Team Goals")]
        public int HomeTeamGoals { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Range(EntitiesAttributesConstraints.TeamGoalsMinValue, int.MaxValue)]
        [Display(Name = "Away Team Goals")]
        public int AwayTeamGoals { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Display(Name = "Home Team")]
        public int HomeTeamId { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [Display(Name = "Away Team")]
        public int AwayTeamId { get; set; }

        public ICollection<TeamWebDetailsModel> Teams { get; set; } = new HashSet<TeamWebDetailsModel>();
    }
}
