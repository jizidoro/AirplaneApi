using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class CategoriaMaterialConfiguration : IEntityTypeConfiguration<CategoriaMaterial>
	{
		public void Configure(EntityTypeBuilder<CategoriaMaterial> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);

			builder.HasMany(c => c.ClasseMateriais).WithOne(c => c.CategoriaMaterial).HasForeignKey(c => c.CategoriaMaterialId);

			builder.HasIndex(c => c.Codigo).HasName("IX_CategoriaMaterials_Codigo").IsUnique();
		}
	}
}
