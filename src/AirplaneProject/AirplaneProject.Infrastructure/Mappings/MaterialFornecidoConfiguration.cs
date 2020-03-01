using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class MaterialFornecidoConfiguration : IEntityTypeConfiguration<MaterialFornecido>
	{
		public void Configure(EntityTypeBuilder<MaterialFornecido> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(255).IsRequired();
			builder.Property(c => c.NM).HasMaxLength(255).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(120).IsRequired();
			builder.Property(c => c.Modelo).HasMaxLength(255).IsRequired();
			builder.Property(c => c.PartNumber).HasMaxLength(50).IsRequired();
			builder.HasOne(c => c.Fabricante).WithMany(c => c.MaterialFornecidos).HasForeignKey(c => c.FabricanteId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.ClasseMaterial).WithMany(c => c.MaterialFornecidos).HasForeignKey(c => c.ClasseMaterialId).OnDelete(DeleteBehavior.Restrict).IsRequired();

			builder.HasMany(c => c.MaterialEstocados).WithOne(c => c.MaterialFornecido).HasForeignKey(c => c.MaterialFornecidoId);

			builder.HasIndex(c => c.Codigo).HasName("IX_MaterialFornecidos_Codigo").IsUnique();
		}
	}
}
