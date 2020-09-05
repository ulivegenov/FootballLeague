namespace FootballLeague.Web.ViewModels.Teams
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Teams;
    using FootballLeague.Web.ViewModels.Contracts;

    public class TeamWebInputModel : IWebInputModel, IMapTo<TeamServiceInputModel>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [MaxLength(EntitiesAttributesConstraints.NameMaxLength)]
        public string Name { get; set; }

        public int Points { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }
    }
}
