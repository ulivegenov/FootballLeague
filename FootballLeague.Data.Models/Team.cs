namespace FootballLeague.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballLeague.Common;

    public class Team : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(EntitiesAttributesConstraints.NameMaxLength)]
        public string Name { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losts { get; set; }

        public int Points { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public virtual ICollection<Game> HomeGames { get; set; } = new List<Game>();

        public virtual ICollection<Game> AwayGames { get; set; } = new List<Game>();
    }
}
