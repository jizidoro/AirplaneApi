using AirplaneProject.Domain.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings.Views
{
	public class EsdViewConfiguration : IEntityTypeConfiguration<EsdView>
	{
		public void Configure(EntityTypeBuilder<EsdView> builder)
		{
			builder.ToTable("vwEsd");

			builder.HasKey(c => c.Id);
			builder.Property(c => c.DataEvento).IsRequired();
			builder.Property(c => c.UnidadeId).IsRequired();
			builder.Property(c => c.UnidadeCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.UnidadeNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AtivoId).IsRequired();
			builder.Property(c => c.AtivoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AtivoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.UepId).IsRequired();
			builder.Property(c => c.UepCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.UepNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.NivelOperacaoId).IsRequired();
			builder.Property(c => c.NivelId).IsRequired();
			builder.Property(c => c.NivelNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.NivelCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.EventoIniciadorId).IsRequired();
			builder.Property(c => c.EventoId).IsRequired();
			builder.Property(c => c.EventoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.EventoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.IniciadorId).IsRequired();
			builder.Property(c => c.IniciadorNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.IniciadorCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.MotivoCausaId).IsRequired();
			builder.Property(c => c.MotivoId).IsRequired();
			builder.Property(c => c.MotivoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.MotivoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.CausaId).IsRequired();
			builder.Property(c => c.CausaNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.CausaCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SituacaoId).IsRequired();
			builder.Property(c => c.SituacaoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SituacaoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.OrigemAgenteId).IsRequired();
			builder.Property(c => c.OrigemId).IsRequired();
			builder.Property(c => c.OrigemNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.OrigemCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AgenteId).IsRequired();
			builder.Property(c => c.AgenteNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AgenteCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.LinkSitop).HasMaxLength(255);
			builder.Property(c => c.LinkCadinc).HasMaxLength(255);
			builder.Property(c => c.LinkGip).HasMaxLength(255);
			builder.Property(c => c.LinkRta).HasMaxLength(255);
			builder.Property(c => c.Alarme).HasMaxLength(20);
			builder.Property(c => c.AlarmeCodigo).HasMaxLength(20);
			builder.Property(c => c.Descricao).HasMaxLength(255);
			builder.Property(c => c.DescricaoCodigo).HasMaxLength(1024);
		}
	}
}
