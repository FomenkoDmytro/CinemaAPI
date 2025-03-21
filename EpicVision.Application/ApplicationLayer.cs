using EpicVision.Application_BLL.Interfaces;
using EpicVision.Application_BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EpicVision.Application_BLL
{
    public static class ApplicationLayer
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IFileService, FileService>();

            return services;
        } 
    }
}
