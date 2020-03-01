using AirplaneProject.Domain.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings.Views
{
	public class AlteracaoViewConfiguration : IEntityTypeConfiguration<AlteracaoView>
	{
		public void Configure(EntityTypeBuilder<AlteracaoView> builder)
		{
			builder.ToTable("vwAlteracao");

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
			builder.Property(c => c.FinalidadeId).IsRequired();
			builder.Property(c => c.FinalidadeNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.FinalidadeCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.CamadaId).IsRequired();
			builder.Property(c => c.CamadaNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.CamadaCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.FuncaoId).IsRequired();
			builder.Property(c => c.FuncaoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.FuncaoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SistemaId).IsRequired();
			builder.Property(c => c.SistemaNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SistemaCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SituacaoId).IsRequired();
			builder.Property(c => c.SituacaoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SituacaoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SolicitanteId).IsRequired();
			builder.Property(c => c.SolicitanteNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SolicitanteChave).HasMaxLength(50).IsRequired();			
			builder.Property(c => c.ExecutorId);
			builder.Property(c => c.ExecutorNome).HasMaxLength(50);
			builder.Property(c => c.ExecutorChave).HasMaxLength(50);			
			builder.Property(c => c.AprovadorId);
			builder.Property(c => c.AprovadorNome).HasMaxLength(50);
			builder.Property(c => c.AprovadorChave).HasMaxLength(50);			
			builder.Property(c => c.AutorizadorId);
			builder.Property(c => c.AutorizadorNome).HasMaxLength(50);
			builder.Property(c => c.AutorizadorChave).HasMaxLength(50);
			builder.Property(c => c.VerificadorId);
			builder.Property(c => c.VerificadorNome).HasMaxLength(50);
			builder.Property(c => c.VerificadorChave).HasMaxLength(50);
			builder.Property(c => c.Checksum).HasMaxLength(255);
			builder.Property(c => c.Descricao).HasMaxLength(255);
			builder.Property(c => c.DescricaoCodigo).HasMaxLength(1024);
		}
	}
}
