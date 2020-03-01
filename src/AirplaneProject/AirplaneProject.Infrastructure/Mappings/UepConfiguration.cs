using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class UepConfiguration : IEntityTypeConfiguration<Uep>
	{
		public void Configure(EntityTypeBuilder<Uep> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.Ativo).WithMany(c => c.Ueps).HasForeignKey(c => c.AtivoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.UepTipo).WithMany().HasForeignKey(c => c.UepTipoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Operacao).WithMany(c => c.Ueps).HasForeignKey(c => c.OperacaoId);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255).IsRequired();

			builder.HasMany(c => c.Esds).WithOne(c => c.Uep).HasForeignKey(c => c.UepId);

			builder.HasIndex(c => c.Codigo).HasName("IX_Ueps_Codigo").IsUnique();
		}
	}
}
