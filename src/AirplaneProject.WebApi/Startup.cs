using AirplaneProject.Application.Bases;
using AirplaneProject.CrossCutting.IoC;
using AirplaneProject.WebApi.Configurations;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace AirplaneProject.WebApi
{
    public class Startup
    {


        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public static IHostingEnvironment Env { get; set; }
        public static ILogger<ConsoleLoggerProvider> AppLogger = null;
        public static ILoggerFactory loggerFactory = null;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                //builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Trace)
            );
            loggerFactory = services.BuildServiceProvider().GetService<ILoggerFactory>();
            AppLogger = loggerFactory.CreateLogger<ConsoleLoggerProvider>();


            // Setting DBContexts
            services.AddDatabaseSetup(Configuration);

            // ASP.NET Identity Settings & JWT
            services.AddIdentitySetup(Configuration);

            // WebAPI Config
            services.AddControllers();

            // AutoMapper Settings
            services.AddAutoMapperSetup();

            // Authorization
            services.AddAuthSetup(Configuration);

            // Swagger Config
            services.AddSwaggerSetup();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.RegisterServices(Configuration, false, Env);

            services.AddMvc()
                .AddApplicationPart(typeof(Startup).Assembly)
                .AddFluentValidation(fv => {
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    fv.RegisterValidatorsFromAssemblyContaining<DtoValidation<EntityDto>>();
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                NativeInjectorBootStraper.UpdateDatabase(scope);
            }
        }
    }
}