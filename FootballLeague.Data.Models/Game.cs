namespace FootballLeague.Data.Models
{
    using FootballLeague.Data.Models.Enums.Team;

    public class Game
    {
        public int Id { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public GameStatus Status { get; set; }

        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }
    }
}
