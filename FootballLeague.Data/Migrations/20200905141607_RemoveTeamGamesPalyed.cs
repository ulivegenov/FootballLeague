using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballLeague.Data.Migrations
{
    public partial class RemoveTeamGamesPalyed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "Teams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
