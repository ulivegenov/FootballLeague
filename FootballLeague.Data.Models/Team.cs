namespace FootballLeague.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GamesPlayed { get; set; }

        public int Points { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }
    }
}
