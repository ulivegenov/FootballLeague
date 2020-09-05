namespace FootballLeague.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballLeague.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class GamesRepository : BaseEntityRepository<Game>
    {
        private readonly FootballLeagueDbContext footballLeagueDbContext;

        public GamesRepository(FootballLeagueDbContext footballLeagueDbContext)
            : base(footballLeagueDbContext)
        {
            this.footballLeagueDbContext = footballLeagueDbContext;
        }

        public override async Task<Game> AddAsync(Game entity)
        {
            var result = await this.footballLeagueDbContext.Games.AddAsync(entity);

            return result.Entity;
        }

        public override async Task<IEnumerable<Game>> GetAllAsync()
            => await this.footballLeagueDbContext.Games
                                                 .Where(e => !e.IsDeleted)
                                                 .ToListAsync();

        public override async Task<Game> HardDelete(int entityId)
        {
            var result = await this.GetEntityFromDbAsync(entityId);

            if (result != null)
            {
                this.footballLeagueDbContext.Games.Remove(result);
                await this.footballLeagueDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        protected override async Task<Game> GetEntityFromDbAsync(int entityId)
            => await this.footballLeagueDbContext.Games
                                                 .Where(e => e.Id.Equals(entityId))
                                                 .FirstOrDefaultAsync();
        protected override async Task<Game> GetEntityFromDbAsync(Game game)
            => await this.footballLeagueDbContext.Games
                                                 .Where(e => e.Id.Equals(game.Id))
                                                 .FirstOrDefaultAsync();

        protected override void MapModelToDbEntity(Game dbEntity, Game entity)
        {
            dbEntity.Id = entity.Id;
            dbEntity.AwayTeamId = entity.AwayTeamId;
            dbEntity.AwayTeamGoals = entity.AwayTeamGoals;
            dbEntity.HomeTeamId = entity.HomeTeamId;
            dbEntity.HomeTeamGoals = entity.HomeTeamGoals;
            dbEntity.IsDeleted = entity.IsDeleted;
            dbEntity.Status = entity.Status;
            dbEntity.CreatedOn = entity.CreatedOn;
            dbEntity.DeletedOn = entity.DeletedOn;
        }
    }
}
