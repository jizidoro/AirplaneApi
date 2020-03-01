using AirplaneProject.Domain.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings.Views
{
	public class ConclusaoAlteracaoViewConfiguration : IEntityTypeConfiguration<ConclusaoAlteracaoView>
	{
		public void Configure(EntityTypeBuilder<ConclusaoAlteracaoView> builder)
		{
			builder.ToTable("vwConclusaoAlteracao");

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
			builder.Property(c => c.SituacaoId).IsRequired();
			builder.Property(c => c.SituacaoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SituacaoCodigo).HasMaxLength(50).IsRequired();
		}
	}
}
