using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class AnpNivelConfiguration : IEntityTypeConfiguration<AnpNivel>
	{
		public void Configure(EntityTypeBuilder<AnpNivel> builder)
		{
			builder.HasKey(c => c.Id);			
			builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Codigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255).IsRequired();
			builder.HasMany(c => c.Niveis).WithOne(c => c.AnpNivel).HasForeignKey(c => c.AnpNivelId);
		}
	}
}
