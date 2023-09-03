using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Repository.CarteRepository;
using WebApplication1.Repository.ImprumutRepository;
using WebApplication1.Services.CarteService;
using WebApplication1.Services;
using WebApplication1.Services.UtilizatorService;

namespace WebApplication1.Helpers {
    public static class ServiceExtensions {
        
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddTransient<ICarteRepository, CarteRepository>();
            services.AddTransient<IUtilizatorRepository, UtilizatorRepository>();
            services.AddTransient<IImprumutRepository, ImprumutRepository>();
            return services;  
        }
        public static IServiceCollection AddServices(this IServiceCollection services) {
            services.AddTransient<ICarteService, CarteService>();
            services.AddTransient<IUtilizatorService, UtilizatorService>();
            services.AddTransient<IImprumutService, ImprumutService>();
            return services;
        }
    }
}