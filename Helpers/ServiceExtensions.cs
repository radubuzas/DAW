using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Repository.CarteRepository;
using WebApplication1.Repository.ImprumutRepository;
using WebApplication1.Services;

namespace WebApplication1.Helpers {
    public static class ServiceExtensions {
        public static IServiceCollection AddServices(this IServiceCollection services) {
            services.AddTransient<IUtilizatorService, UtilizatorService>();
            services.AddTransient<IImprumutService, ImprumutService>();
            services.AddTransient<ICarteService, CarteService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddTransient<IUtilizatorRepository, UtilizatorRepository>();
            services.AddTransient<IImprumutRepository, ImprumutRepository>();
            services.AddTransient<ICarteRepository, CarteRepository>();
            return services;  
        }
    }
}