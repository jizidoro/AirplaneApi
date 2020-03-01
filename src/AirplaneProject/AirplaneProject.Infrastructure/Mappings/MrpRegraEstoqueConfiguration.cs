using AirplaneProject.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Domain.Models
{
	public class MrpRegraEstoqueConfiguration : IEntityTypeConfiguration<MrpRegraEstoque>
	{
		public void Configure(EntityTypeBuilder<MrpRegraEstoque> builder)
		{
			builder.HasKey(c => c.Id);

			builder.HasOne(c => c.Mrp).WithMany(c => c.MrpRegraEstoques).HasForeignKey(c => c.MrpId).OnDelete(DeleteBehavior.Restrict);
			builder.Property(c => c.Campo).HasColumnType("int").IsRequired();
			builder.Property(c => c.SituacaoRegraEstoque).HasColumnType("int").IsRequired();
			builder.Property(c => c.Operador).HasColumnType("int").IsRequired();
			builder.Property(c => c.Quantidade).IsRequired();
			

		}
	}
}