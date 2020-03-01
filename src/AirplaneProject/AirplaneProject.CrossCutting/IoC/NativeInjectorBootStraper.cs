using AirplaneProject.Application.Interfaces;
using AirplaneProject.Application.Services;
using AirplaneProject.Core.Bus;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Validations;
using AirplaneProject.Core.Notifications;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Core.Services;
using AirplaneProject.CrossCutting.Authorization;
using AirplaneProject.CrossCutting.Bus;
using AirplaneProject.CrossCutting.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirplaneProject.CrossCutting.IoC
{
    public static class NativeInjectorBootStraper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // AspNetUser
            services.AddScoped<IUser, AspNetUser>();

            // Application - Extensions
            services.AddScoped<IAirplaneAppService, AirplaneAppService>();

            // Core - Services
            services.AddScoped<IAirplaneService, AirplaneService>();

            // Core - Validations
            services.AddScoped<IAirplaneValidation, AirplaneValidation>();

            // Infra - Data
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();


            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }

        public static void UpdateDatabase(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetService<GestaoAirplaneContext>();
            context.Database.Migrate();
        }
    }
}
