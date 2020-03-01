using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Validations;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Core.Services;
using AirplaneProject.CrossCutting.Identity;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirplaneProject.CrossCutting.IoC
{
    public static class NativeInjectorBootStraper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config, bool isTest, IHostingEnvironment env)
        {
            // AspNetUser
            services.AddScoped<IUser, AspNetUser>();

            // Application - Extensions

            // Core - Services
            services.AddScoped<IAirplaneService, AirplaneService>();

            // Core - Validations
            services.AddScoped<IAirplaneValidation, AirplaneValidation>();

            // Infra - Data
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            if (!isTest)
            {
                services.AddDbContext<GestaoAirplaneContext>(options => options
                    .UseSqlServer(config.GetConnectionString("DefaultConnection")));
            }
        }

        public static void UpdateDatabase(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetService<GestaoAirplaneContext>();
            context.Database.Migrate();
        }
    }
}
