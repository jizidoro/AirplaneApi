using AirplaneProject.Application.Interfaces;
using AirplaneProject.Application.Services;
using AirplaneProject.Core.Bus;
using AirplaneProject.Core.Events;
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
using AirplaneProject.Infrastructure.EventSourcing;
using AirplaneProject.Infrastructure.Repositories;
using AirplaneProject.Infrastructure.Repository.EventSourcing;
using AirplaneProject.Infrastructure.UoW;
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
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IAirplaneAppService, AirplaneAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();


            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();

            services.AddScoped<GestaoAirplaneContext>();

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
