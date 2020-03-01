using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class OperacaoConfiguration : IEntityTypeConfiguration<Operacao>
	{
		public void Configure(EntityTypeBuilder<Operacao> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);
			builder.HasMany(c => c.Ueps).WithOne(c => c.Operacao).HasForeignKey(c => c.OperacaoId);
		}
	}
}
