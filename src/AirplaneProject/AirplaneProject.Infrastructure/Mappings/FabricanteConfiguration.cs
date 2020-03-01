using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class FabricanteConfiguration : IEntityTypeConfiguration<Fabricante>
	{
		public void Configure(EntityTypeBuilder<Fabricante> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(120).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(120).IsRequired();
			builder.Property(c => c.CodigoSAP).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);

			builder.HasMany(c => c.MaterialFornecidos).WithOne(c => c.Fabricante).HasForeignKey(c => c.FabricanteId);

			builder.HasIndex(c => c.Codigo).HasName("IX_Fabricantes_Codigo").IsUnique();
		}
	}
}
