using AirplaneProject.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Domain.Models
{
	public class CamadaConfiguration : IEntityTypeConfiguration<Camada>
	{
		public void Configure(EntityTypeBuilder<Camada> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);

			builder.HasIndex(c => c.Codigo).HasName("IX_Camadas_Codigo");
		}
	}
}