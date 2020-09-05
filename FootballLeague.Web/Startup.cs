namespace FootballLeague.Web
{
    using System.Reflection;
    using FootballLeague.Data;
    using FootballLeague.Data.Models;
    using FootballLeague.Data.Repositories;
    using FootballLeague.Services.Data;
    using FootballLeague.Services.Mapping;
    using FootballLeague.Services.Models.Teams;
    using FootballLeague.Web.ViewModels.Teams;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FootballLeagueDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();

            // Data repositories
            services.AddScoped(typeof(BaseEntityRepository<Team, int>), typeof(TeamsRepository));
            services.AddScoped(typeof(BaseEntityRepository<Game, int>), typeof(GamesRepository));

            // Application services
            services.AddTransient<BaseService<Game, int>, GamesService>();
            services.AddTransient<BaseService<Team, int>, TeamsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(TeamWebInputModel).GetTypeInfo().Assembly,
                typeof(TeamServiceInputModel).GetTypeInfo().Assembly);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
