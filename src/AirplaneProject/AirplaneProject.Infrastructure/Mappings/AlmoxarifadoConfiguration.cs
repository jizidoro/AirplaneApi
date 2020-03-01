using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class AlmoxarifadoConfiguration : IEntityTypeConfiguration<Almoxarifado>
	{
		public void Configure(EntityTypeBuilder<Almoxarifado> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.CodigoCentroMrp).HasMaxLength(50).IsRequired();
			builder.Property(c => c.CodigoAreaMrp).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);

			builder.HasMany(c => c.MaterialEstocados).WithOne(c => c.Almoxarifado).HasForeignKey(c => c.AlmoxarifadoId);

			builder.HasIndex(c => c.Codigo).HasName("IX_Almoxarifados_Codigo").IsUnique();
		}
	}
}
