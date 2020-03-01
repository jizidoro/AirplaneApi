using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class AtivoConfiguration : IEntityTypeConfiguration<Ativo>
	{
		public void Configure(EntityTypeBuilder<Ativo> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.UnidadeOperativa).WithMany(c => c.Ativos).HasForeignKey(c => c.UnidadeOperativaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.Property(c => c.Nome).HasMaxLength(20).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(20).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255).IsRequired();
			builder.HasMany(c => c.Ueps).WithOne(c => c.Ativo).HasForeignKey(c => c.AtivoId);

			builder.HasIndex(c => c.Codigo).HasName("IX_Ativos_Codigo").IsUnique();
		}
	}
}
