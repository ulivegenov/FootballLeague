namespace FootballLeague.Services.Models.Teams
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Data.Models;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Contracts;

    public class TeamServiceInputModel : IServiceInputModel, IMapTo<Team>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredFieldMessage)]
        [MaxLength(EntitiesAttributesConstraints.NameMaxLength)]
        public string Name { get; set; }
    }
}
