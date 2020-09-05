namespace FootballLeague.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballLeague.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class TeamsRepository : BaseEntityRepository<Team, int>
    {
        private readonly FootballLeagueDbContext footballLeagueDbContext;

        public TeamsRepository(FootballLeagueDbContext footballLeagueDbContext)
            : base(footballLeagueDbContext)
        {
            this.footballLeagueDbContext = footballLeagueDbContext;
        }

        public override async Task<Team> AddAsync(Team entity)
        {
            var result = await this.footballLeagueDbContext.Teams.AddAsync(entity);

            return result.Entity;
        }

        public override IQueryable<Team> GetAll()
            => this.footballLeagueDbContext.Teams
                                           .Where(e => !e.IsDeleted);

        public override async Task<Team> HardDelete(int entityId)
        {
            var result = await this.GetEntityFromDbAsync(entityId);

            if (result != null)
            {
                this.footballLeagueDbContext.Teams.Remove(result);
                await this.footballLeagueDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        protected override async Task<Team> GetEntityFromDbAsync(Team entity)
            => await this.footballLeagueDbContext.Teams
                                                 .Where(e => e.Id.Equals(entity.Id))
                                                 .FirstOrDefaultAsync();

        protected override async Task<Team> GetEntityFromDbAsync(int entityId)
            => await this.footballLeagueDbContext.Teams
                                                 .Where(e => e.Id.Equals(entityId))
                                                 .FirstOrDefaultAsync();

        protected override void MapModelToDbEntity(Team dbEntity, Team entity)
        {
            dbEntity.Id = entity.Id;
            dbEntity.Name = entity.Name;
            dbEntity.Points = entity.Points;
            dbEntity.CreatedOn = dbEntity.CreatedOn;
            dbEntity.DeletedOn = entity.DeletedOn;
            dbEntity.GoalsAgainst = entity.GoalsAgainst;
            dbEntity.GoalsFor = entity.GoalsFor;
            dbEntity.IsDeleted = entity.IsDeleted;
            this.CopyElementsFromSourceCollectionToTarget(entity.HomeGames, dbEntity.HomeGames);
            this.CopyElementsFromSourceCollectionToTarget(entity.AwayGames, dbEntity.AwayGames);
        }

        protected override void MarkEntityAsDeleted(Team dbEntity, Team entity)
        {
            dbEntity.Id = entity.Id;
            dbEntity.Name = entity.Name;
            dbEntity.Points = entity.Points;
            dbEntity.CreatedOn = dbEntity.CreatedOn;
            dbEntity.DeletedOn = entity.DeletedOn;
            dbEntity.GoalsAgainst = entity.GoalsAgainst;
            dbEntity.GoalsFor = entity.GoalsFor;
            dbEntity.IsDeleted = !entity.IsDeleted;
            this.CopyElementsFromSourceCollectionToTarget(entity.HomeGames, dbEntity.HomeGames);
            this.CopyElementsFromSourceCollectionToTarget(entity.AwayGames, dbEntity.AwayGames);
        }

        private void CopyElementsFromSourceCollectionToTarget(ICollection<Game> source, ICollection<Game> target)
        {
            foreach (var item in source)
            {
                target.Add(item);
            }
        }
    }
}
