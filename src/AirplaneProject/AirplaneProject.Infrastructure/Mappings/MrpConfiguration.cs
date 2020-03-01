using AirplaneProject.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Domain.Models
{
	public class MrpConfiguration : IEntityTypeConfiguration<Mrp>
	{
		public void Configure(EntityTypeBuilder<Mrp> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);

			builder.HasMany(c => c.MrpRegraEstoques).WithOne(c => c.Mrp).HasForeignKey(c => c.MrpId);

			builder.HasIndex(c => c.Codigo).HasName("IX_Mrps_Codigo");
		}
	}
}