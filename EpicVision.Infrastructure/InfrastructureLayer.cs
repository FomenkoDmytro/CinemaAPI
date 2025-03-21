using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EpicVision.Infrastructure_DAL.Data;
using EpicVision.Infrastructure_DAL.Repositories;

namespace EpicVision.Infrastructure_DAL
{
    public static class InfrastructureLayer
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
