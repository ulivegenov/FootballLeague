namespace Fruitify.Data
{
    using System.IO;
    using FootballLeague.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FootballLeagueDbContext>
    //{
    //    public FootballLeagueDbContext CreateDbContext(string[] args)
    //    {
    //        var configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //            .Build();

    //        var builder = new DbContextOptionsBuilder<FootballLeagueDbContext>();
    //        var connectionString = configuration.GetConnectionString("DefaultConnection");
    //        builder.UseSqlServer(connectionString);
    //        builder.UseLazyLoadingProxies();

    //        return new FootballLeagueDbContext(builder.Options);
    //    }
    //}
}
