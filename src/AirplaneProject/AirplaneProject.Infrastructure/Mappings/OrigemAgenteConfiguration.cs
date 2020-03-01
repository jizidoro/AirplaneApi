using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class OrigemAgenteConfiguration : IEntityTypeConfiguration<OrigemAgente>
	{
		public void Configure(EntityTypeBuilder<OrigemAgente> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.Origem).WithMany(c => c.OrigemAgentes).HasForeignKey(c => c.OrigemId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Agente).WithMany(c => c.OrigemAgentes).HasForeignKey(c => c.AgenteId).OnDelete(DeleteBehavior.Restrict).IsRequired();
		}
	}
}
