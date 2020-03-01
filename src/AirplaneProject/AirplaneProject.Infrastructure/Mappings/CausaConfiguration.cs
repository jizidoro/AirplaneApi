using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class CausaConfiguration : IEntityTypeConfiguration<Causa>
	{
		public void Configure(EntityTypeBuilder<Causa> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);

			builder.HasIndex(c => c.Codigo).HasName("IX_Causas_Codigo");

			builder.Ignore(c => c.DadosAssociados);
			builder.Ignore(c => c.Include);
		}
	}
}
