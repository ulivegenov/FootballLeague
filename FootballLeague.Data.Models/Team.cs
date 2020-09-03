namespace FootballLeague.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;

    public class Team
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EntitiesAttributesConstraints.NameMaxLength)]
        public string Name { get; set; }

        public int GamesPlayed { get; set; }

        public int Points { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }
    }
}
