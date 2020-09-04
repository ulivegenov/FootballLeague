using FootballLeague.Data.Models;
using FootballLeague.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly FootballLeagueDbContext footballLeagueDbContext;

        public GamesRepository(FootballLeagueDbContext footballLeagueDbContext)
        {
            this.footballLeagueDbContext = footballLeagueDbContext;
        }

        public async Task<Game> AddAsync(Game entity)
        {
            var result = await this.footballLeagueDbContext.Games.AddAsync(entity);

            return result.Entity;
        }

        public async Task<Game> DeleteAsync(Game entity)
        {
            var result = await this.footballLeagueDbContext.Games.FirstOrDefaultAsync(e => e.Id.Equals(entity.Id));

            //TODO: Implement AutoMapper
        }

        public Task<IEnumerable<Game>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Game> HardDelete(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Game> UpdateAsync(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
