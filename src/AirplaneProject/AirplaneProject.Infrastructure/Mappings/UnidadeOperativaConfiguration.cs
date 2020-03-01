using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class UnidadeOperativaConfiguration : IEntityTypeConfiguration<UnidadeOperativa>
	{
		public void Configure(EntityTypeBuilder<UnidadeOperativa> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(20).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(20).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255).IsRequired();
			builder.HasMany(c => c.Ativos).WithOne(c => c.UnidadeOperativa).IsRequired();

			builder.HasIndex(c => c.Codigo).HasName("IX_UnidadesOperativas_Codigo").IsUnique();
		}
	}
}
