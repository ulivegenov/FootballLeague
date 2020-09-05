namespace FootballLeague.Services.Models.Teams
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Services.Models.Contracts;

    public class TeamServiceImputModel : IServiceInputModel
    {
        [Required]
        [MaxLength(EntitiesAttributesConstraints.NameMaxLength)]
        public string Name { get; set; }

        public int Points { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }
    }
}
