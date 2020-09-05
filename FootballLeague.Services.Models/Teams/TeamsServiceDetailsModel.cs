namespace FootballLeague.Services.Models.Teams
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;
    using FootballLeague.Data.Models;
    using FootballLeague.Services.Models.Contracts;

    public class TeamsServiceDetailsModel : IServiceDetailsModel<int>
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(EntitiesAttributesConstraints.NameMaxLength)]
        public string Name { get; set; }

        public int Points { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public ICollection<Game> HomeGames { get; set; } = new List<Game>();

        public ICollection<Game> AwayGames { get; set; } = new List<Game>();
    }
}
