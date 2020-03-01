using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Validations;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Core.Repositories.Views;
using AirplaneProject.Core.Services;
using AirplaneProject.CrossCutting.Identity;
using AirplaneProject.CrossCutting.Security;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Repositories;
using AirplaneProject.Infrastructure.Repositories.Views;
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
            services.AddScoped<IAtivoService, AtivoService>();
            services.AddScoped<IEsdService, EsdService>();
            services.AddScoped<IAlteracaoService, AlteracaoService>();
            services.AddScoped<IEsdArquivoService, EsdArquivoService>();
            services.AddScoped<IMaterialEstocadoService, MaterialEstocadoService>();
            services.AddScoped<IMaterialFornecidoService, MaterialFornecidoService>();
            services.AddScoped<IUepService, UepService>();
            services.AddScoped<IUnidadeOperativaService, UnidadeOperativaService>();
            services.AddScoped<IAlmoxarifadoService, AlmoxarifadoService>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IMrpService, MrpService>();
            services.AddScoped<IMrpRegraEstoqueService, MrpRegraEstoqueService>();
            services.AddScoped<IClasseMaterialService, ClasseMaterialService>();
            services.AddScoped<IProfissionalService, ProfissionalService>();
            services.AddScoped(typeof(IAutomacaoEntityService<,,>), typeof(AutomacaoEntityService<,,>));
            services.AddScoped(typeof(IBaseAutomacaoEntityService<>), typeof(BaseAutomacaoEntityService<>));
            services.AddScoped(typeof(IAssociacaoEntityService<>), typeof(AssociacaoEntityService<>));

            // Core - Validations
            services.AddScoped<IAtivoValidation, AtivoValidation>();
            services.AddScoped<IEsdValidation, EsdValidation>();
            services.AddScoped<IAlteracaoValidation, AlteracaoValidation>();
            services.AddScoped<IMaterialEstocadoValidation, MaterialEstocadoValidation>();
            services.AddScoped<IMaterialFornecidoValidation, MaterialFornecidoValidation>();
            services.AddScoped<IUepValidation, UepValidation>();
            services.AddScoped<IUnidadeOperativaValidation, UnidadeOperativaValidation>();
            services.AddScoped<IAlmoxarifadoValidation, AlmoxarifadoValidation>();
            services.AddScoped<IClasseMaterialValidation, ClasseMaterialValidation>();
            services.AddScoped<IFabricanteValidation, FabricanteValidation>();
            services.AddScoped<IMrpValidation, MrpValidation>();
            services.AddScoped<IMrpRegraEstoqueValidation, MrpRegraEstoqueValidation>();
            services.AddScoped<IProfissionalValidation, ProfissionalValidation>();
            services.AddScoped(typeof(IAutomacaoEntityValidation<>), typeof(AutomacaoEntityValidation<>));
            services.AddScoped(typeof(IBaseAutomacaoEntityValidation<>), typeof(BaseAutomacaoEntityValidation<>));
            services.AddScoped(typeof(IAssociacaoEntityValidation<>), typeof(AssociacaoEntityValidation<>));


            services.AddSingleton<ISecurityService, SecurityServiceFake>();
            services.AddScoped<IBasicSecurityService, BasicSecurityService>();
            // Infra - Data
            services.AddScoped<IAgenteRepository, AgenteRepository>();
            services.AddScoped<IAlteracaoRepository, AlteracaoRepository>();
            services.AddScoped<IAnpNivelRepository, AnpNivelRepository>();
            services.AddScoped<IAtivoRepository, AtivoRepository>();
            services.AddScoped<ICausaRepository, CausaRepository>();
            services.AddScoped<ICamadaRepository, CamadaRepository>();
            services.AddScoped<IFinalidadeRepository, FinalidadeRepository>();
            services.AddScoped<ISistemaRepository, SistemaRepository>();
            services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
            services.AddScoped<ISituacaoMaterialRepository, SituacaoMaterialRepository>();
            services.AddScoped<ISituacaoRepository, SituacaoRepository>();
            services.AddScoped<IFuncaoRepository, FuncaoRepository>();
            services.AddScoped<IEventoIniciadorRepository, EventoIniciadorRepository>();
            services.AddScoped<IIniciadorRepository, IniciadorRepository>();
            services.AddScoped<IEsdRepository, EsdRepository>();
            services.AddScoped<IEsdArquivoRepository, EsdArquivoRepository>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<IHistoricoAlteracaoRepository, HistoricoAlteracaoRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IMotivoRepository, MotivoRepository>();
            services.AddScoped<IMotivoCausaRepository, MotivoCausaRepository>();
            services.AddScoped<INivelRepository, NivelRepository>();
            services.AddScoped<INivelOperacaoRepository, NivelOperacaoRepository>();
            services.AddScoped<IOperacaoRepository, OperacaoRepository>();
            services.AddScoped<IOrigemAgenteRepository, OrigemAgenteRepository>();
            services.AddScoped<IOrigemRepository, OrigemRepository>();
            services.AddScoped<IUepRepository, UepRepository>();
            services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
            services.AddScoped<IUepTipoRepository, UepTipoRepository>();
            services.AddScoped<IUnidadeOperativaRepository, UnidadeOperativaRepository>();
            services.AddScoped<IProfissionalRepository, ProfissionalRepository>();

            services.AddScoped<IAlmoxarifadoRepository, AlmoxarifadoRepository>();
            services.AddScoped<IClasseMaterialRepository, ClasseMaterialRepository>();
            services.AddScoped<ICategoriaMaterialRepository, CategoriaMaterialRepository>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IMaterialEstocadoRepository, MaterialEstocadoRepository>();
            services.AddScoped<IMaterialFornecidoRepository, MaterialFornecidoRepository>();
            services.AddScoped<IMrpRepository, MrpRepository>();
            services.AddScoped<IMrpRegraEstoqueRepository, MrpRegraEstoqueRepository>();
            services.AddScoped<IUepAlmoxarifadoRepository, UepAlmoxarifadoRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAutomacaoEntityRepository<>), typeof(AutomacaoEntityRepository<>));
            services.AddScoped(typeof(IBaseAutomacaoEntityRepository<>), typeof(BaseAutomacaoEntityRepository<>));

            // Infra - Data - Views			
            services.AddScoped<IEsdViewRepository, EsdViewRepository>();
            services.AddScoped<IAlmoxarifadoViewRepository, AlmoxarifadoViewRepository>();
            services.AddScoped<IMaterialEstocadoViewRepository, MaterialEstocadoViewRepository>();
            services.AddScoped<ISobressalenteViewRepository, SobressalenteViewRepository>();
            services.AddScoped<IConclusaoAlteracaoViewRepository, ConclusaoAlteracaoViewRepository>();
            services.AddScoped<IAlteracaoViewRepository, AlteracaoViewRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            if (!isTest)
            {
                services.AddDbContext<GestaoEsdContext>(options => options
                    .UseSqlServer(config.GetConnectionString("DefaultConnection")));
            }
        }

        public static void UpdateDatabase(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetService<GestaoEsdContext>();
            context.Database.Migrate();
        }
    }
}
