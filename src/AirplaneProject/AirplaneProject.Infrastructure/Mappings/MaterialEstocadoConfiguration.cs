using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class MaterialEstocadoConfiguration : IEntityTypeConfiguration<MaterialEstocado>
	{
		public void Configure(EntityTypeBuilder<MaterialEstocado> builder)
		{
			builder.HasKey(c => c.Id);

			builder.HasOne(c => c.Mrp).WithMany(c => c.MaterialEstocados).HasForeignKey(c => c.MrpId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Almoxarifado).WithMany(c => c.MaterialEstocados).HasForeignKey(c => c.AlmoxarifadoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.MaterialFornecido).WithMany(c => c.MaterialEstocados).HasForeignKey(c => c.MaterialFornecidoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.SituacaoMaterial).WithMany(c => c.MaterialEstocados).HasForeignKey(c => c.SituacaoMaterialId).OnDelete(DeleteBehavior.Restrict).IsRequired();

			builder.Property(c => c.Minimo).IsRequired();
			builder.Property(c => c.Maximo).IsRequired();
			builder.Property(c => c.QuantidadeEstoque).IsRequired();

			builder.Property(c => c.DataRegistro).IsRequired();

		}
	}
}
