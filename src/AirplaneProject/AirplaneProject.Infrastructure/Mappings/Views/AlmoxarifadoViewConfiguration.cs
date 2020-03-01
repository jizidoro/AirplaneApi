using AirplaneProject.Domain.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings.Views
{
	public class AlmoxarifadoViewConfiguration : IEntityTypeConfiguration<AlmoxarifadoView>
	{
		public void Configure(EntityTypeBuilder<AlmoxarifadoView> builder)
		{
			builder.ToTable("vwAlmoxarifado");

			builder.HasKey(c => c.Id);
			builder.Property(c => c.AlmoxarifadoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AlmoxarifadoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.UnidadeId).IsRequired();
			builder.Property(c => c.UnidadeCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.UnidadeNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AtivoId).IsRequired();
			builder.Property(c => c.AtivoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AtivoNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.UepId).IsRequired();
			builder.Property(c => c.UepCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.UepNome).HasMaxLength(50).IsRequired();
		}
	}
}
