using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class UepAlmoxarifadoConfiguration : IEntityTypeConfiguration<UepAlmoxarifado>
	{
		public void Configure(EntityTypeBuilder<UepAlmoxarifado> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.Uep).WithMany(c => c.UepAlmoxarifados).HasForeignKey(c => c.UepId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Almoxarifado).WithMany(c => c.UepAlmoxarifados).HasForeignKey(c => c.AlmoxarifadoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
		}
	}
}
