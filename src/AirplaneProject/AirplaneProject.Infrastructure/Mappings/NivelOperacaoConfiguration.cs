using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class NivelOperacaoConfiguration : IEntityTypeConfiguration<NivelOperacao>
	{
		public void Configure(EntityTypeBuilder<NivelOperacao> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.Operacao).WithMany(c => c.NivelOperacoes).HasForeignKey(c => c.OperacaoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Nivel).WithMany(c => c.NivelOperacoes).HasForeignKey(c => c.NivelId).OnDelete(DeleteBehavior.Restrict).IsRequired();
		}
	}
}
