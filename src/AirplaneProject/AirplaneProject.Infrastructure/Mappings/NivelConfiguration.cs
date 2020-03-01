using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class NivelConfiguration : IEntityTypeConfiguration<Nivel>
	{
		public void Configure(EntityTypeBuilder<Nivel> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.AnpNivel).WithMany(c => c.Niveis).HasForeignKey(c => c.AnpNivelId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.Property(c => c.Nome).HasMaxLength(20).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(20).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);
			builder.HasMany(c => c.NivelOperacoes).WithOne(c => c.Nivel).HasForeignKey(c => c.NivelId);

			builder.HasIndex(c => c.Codigo).HasName("IX_Niveis_Codigo");
		}
	}
}
