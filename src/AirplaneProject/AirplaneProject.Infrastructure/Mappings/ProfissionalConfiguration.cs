using AirplaneProject.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Domain.Models
{
	public class ProfissionalConfiguration : IEntityTypeConfiguration<Profissional>
	{
		public void Configure(EntityTypeBuilder<Profissional> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
			builder.Property(c => c.Chave).HasMaxLength(12).IsRequired();

			builder.HasIndex(c => c.Chave).HasName("IX_Profissionais_Chave");
		}
	}
}