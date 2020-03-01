using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class MotivoCausaConfiguration : IEntityTypeConfiguration<MotivoCausa>
	{
		public void Configure(EntityTypeBuilder<MotivoCausa> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.Motivo).WithMany(c => c.MotivoCausas).HasForeignKey(c => c.MotivoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Causa).WithMany(c => c.MotivoCausas).HasForeignKey(c => c.CausaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
		}
	}
}
