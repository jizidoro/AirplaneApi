using AirplaneProject.Domain.Models;
using AirplaneProject.Domain.Models.Views;
using AirplaneProject.Infrastructure.Mappings;
using AirplaneProject.Infrastructure.Mappings.Views;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Data
{
	public class GestaoEsdContext : DbContext
	{
		private const string JSON_PATH = "Automacao.Infrastructure.SeedData";

		public GestaoEsdContext(DbContextOptions<GestaoEsdContext> options)
			: base(options)
		{			
		}

		// Tabelas
		public DbSet<Ativo> Ativos { get; set; }
		public DbSet<AnpNivel> AnpNiveis { get; set; }        
        public DbSet<Causa> Causas { get; set; }
        public DbSet<Iniciador> Iniciadores { get; set; }
        public DbSet<EventoIniciador> EventoIniciadores { get; set; }
        public DbSet<Esd> Esds { get; set; }
		public DbSet<EsdArquivo> EsdArquivos { get; set; }
		public DbSet<Historico> Historicos { get; set; }
        public DbSet<Evento> Eventos { get; set; }        
        public DbSet<Motivo> Motivos { get; set; }
		public DbSet<MotivoCausa> MotivoCausas { get; set; }
		public DbSet<Operacao> Operacoes { get; set; }
		public DbSet<Origem> Origens { get; set; }
		public DbSet<OrigemAgente> OrigemAgentes { get; set; }
		public DbSet<Nivel> Niveis { get; set; }
        public DbSet<NivelOperacao> NivelOperacoes { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Uep> Ueps { get; set; }
        public DbSet<UepTipo> UepTipos { get; set; }
		public DbSet<UnidadeOperativa> UnidadesOperativas { get; set; }
		
		public DbSet<Alteracao> Alteracoes { get; set; }
		public DbSet<Camada> Camadas { get; set; }
		public DbSet<Funcao> Funcoes { get; set; }
		public DbSet<Finalidade> Finalidades { get; set; }
		public DbSet<Profissional> Profissionais { get; set; }
		public DbSet<Sistema> Sistemas { get; set; }
		public DbSet<Situacao> Situacoes { get; set; }
		public DbSet<HistoricoAlteracao> HistoricoAlteracoes { get; set; }
		//AS003_ModuloAlteracao

		public DbSet<Almoxarifado> Almoxarifados { get; set; }
		public DbSet<MaterialEstocado> MaterialEstocados { get; set; }
		public DbSet<MaterialFornecido> MaterialFornecidos { get; set; }
		public DbSet<ClasseMaterial> ClasseMateriais { get; set; }
		public DbSet<CategoriaMaterial> CategoriaMateriais { get; set; }
		public DbSet<Fabricante> Fabricantes { get; set; }
		public DbSet<SituacaoMaterial> SituacaoMateriais { get; set; }
		public DbSet<Mrp> Mrps { get; set; }
		public DbSet<MrpRegraEstoque> MrpRegraEstoques { get; set; }
		public DbSet<UepAlmoxarifado> UepAlmoxarifados { get; set; }

		// Views
		public DbSet<EsdView> EsdsView { get; set; }
		public DbSet<AlteracaoView> AlteracoesView { get; set; }
		public DbSet<AlmoxarifadoView> AlmoxarifadosView { get; set; }
		public DbSet<MaterialEstocadoView> MaterialEstocadosView { get; set; }
		public DbSet<SobressalenteView> SobressalentesView { get; set; }

		public DbSet<ConclusaoAlteracaoView> ConclusaoAlteracoesView { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Tabelas
			modelBuilder.ApplyConfiguration(new AgenteConfiguration());
			modelBuilder.ApplyConfiguration(new AnpNivelConfiguration());
			modelBuilder.ApplyConfiguration(new AtivoConfiguration());
            modelBuilder.ApplyConfiguration(new EsdArquivoConfiguration());
			modelBuilder.ApplyConfiguration(new CausaConfiguration());
			modelBuilder.ApplyConfiguration(new IniciadorConfiguration());
			modelBuilder.ApplyConfiguration(new EventoIniciadorConfiguration());
			modelBuilder.ApplyConfiguration(new EsdConfiguration());
			modelBuilder.ApplyConfiguration(new HistoricoConfiguration());
			modelBuilder.ApplyConfiguration(new EventoConfiguration());
			modelBuilder.ApplyConfiguration(new MotivoConfiguration());
			modelBuilder.ApplyConfiguration(new MotivoCausaConfiguration());
			modelBuilder.ApplyConfiguration(new NivelConfiguration());
			modelBuilder.ApplyConfiguration(new NivelOperacaoConfiguration());
			modelBuilder.ApplyConfiguration(new OperacaoConfiguration());
			modelBuilder.ApplyConfiguration(new OrigemConfiguration());
			modelBuilder.ApplyConfiguration(new OrigemAgenteConfiguration());
			modelBuilder.ApplyConfiguration(new UepConfiguration());
			modelBuilder.ApplyConfiguration(new UepTipoConfiguration());			
			modelBuilder.ApplyConfiguration(new UnidadeOperativaConfiguration());

			modelBuilder.ApplyConfiguration(new AlteracaoConfiguration());
			modelBuilder.ApplyConfiguration(new CamadaConfiguration());
			modelBuilder.ApplyConfiguration(new FuncaoConfiguration());
			modelBuilder.ApplyConfiguration(new FinalidadeConfiguration());
			modelBuilder.ApplyConfiguration(new ProfissionalConfiguration());
			modelBuilder.ApplyConfiguration(new SistemaConfiguration());
			modelBuilder.ApplyConfiguration(new SituacaoConfiguration());
			modelBuilder.ApplyConfiguration(new HistoricoAlteracaoConfiguration());
			
			modelBuilder.ApplyConfiguration(new AlmoxarifadoConfiguration());
			modelBuilder.ApplyConfiguration(new MaterialEstocadoConfiguration());
			modelBuilder.ApplyConfiguration(new MaterialFornecidoConfiguration());
			modelBuilder.ApplyConfiguration(new ClasseMaterialConfiguration());
			modelBuilder.ApplyConfiguration(new CategoriaMaterialConfiguration());
			modelBuilder.ApplyConfiguration(new FabricanteConfiguration());
			modelBuilder.ApplyConfiguration(new SituacaoMaterialConfiguration());
			modelBuilder.ApplyConfiguration(new MrpConfiguration());
			modelBuilder.ApplyConfiguration(new MrpRegraEstoqueConfiguration());
			modelBuilder.ApplyConfiguration(new UepAlmoxarifadoConfiguration());

			// Views			
			modelBuilder.ApplyConfiguration(new EsdViewConfiguration());
			modelBuilder.ApplyConfiguration(new AlteracaoViewConfiguration());
			modelBuilder.ApplyConfiguration(new AlmoxarifadoViewConfiguration());
			modelBuilder.ApplyConfiguration(new MaterialEstocadoViewConfiguration());
			modelBuilder.ApplyConfiguration(new SobressalenteViewConfiguration());
			modelBuilder.ApplyConfiguration(new ConclusaoAlteracaoViewConfiguration());
		}
	}
}
