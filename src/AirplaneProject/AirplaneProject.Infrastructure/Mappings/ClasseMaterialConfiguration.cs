using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class ClasseMaterialConfiguration : IEntityTypeConfiguration<ClasseMaterial>
	{
		public void Configure(EntityTypeBuilder<ClasseMaterial> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);
			builder.HasOne(c => c.CategoriaMaterial).WithMany().HasForeignKey(c => c.CategoriaMaterialId).OnDelete(DeleteBehavior.Restrict).IsRequired();

			builder.HasMany(c => c.MaterialFornecidos).WithOne(c => c.ClasseMaterial).HasForeignKey(c => c.ClasseMaterialId);

			builder.HasIndex(c => c.Codigo).HasName("IX_ClasseMaterials_Codigo").IsUnique();
		}
	}
}
