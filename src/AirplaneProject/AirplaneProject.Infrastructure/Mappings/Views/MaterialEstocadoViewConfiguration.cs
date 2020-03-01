using AirplaneProject.Domain.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings.Views
{
	public class MaterialEstocadoViewConfiguration : IEntityTypeConfiguration<MaterialEstocadoView>
	{
		public void Configure(EntityTypeBuilder<MaterialEstocadoView> builder)
		{
			builder.ToTable("vwMaterialEstocado");

			builder.HasKey(c => c.Id);
			builder.Property(c => c.MaterialFornecidoId).IsRequired();
			builder.Property(c => c.MaterialFornecidoCodigo).HasMaxLength(120).IsRequired();
			builder.Property(c => c.MaterialFornecidoNM).HasMaxLength(120).IsRequired();
			builder.Property(c => c.MaterialFornecidoPartNumber).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SituacaoMaterialId).IsRequired();
			builder.Property(c => c.SituacaoMaterialCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.SituacaoMaterialNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.ClasseMaterialId).IsRequired();
			builder.Property(c => c.ClasseMaterialCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.ClasseMaterialNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.CategoriaMaterialId).IsRequired();
			builder.Property(c => c.CategoriaMaterialCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.CategoriaMaterialNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.FabricanteId).IsRequired();
			builder.Property(c => c.FabricanteCodigo).HasMaxLength(120).IsRequired();
			builder.Property(c => c.FabricanteNome).HasMaxLength(120).IsRequired();
			builder.Property(c => c.MrpId).IsRequired();
			builder.Property(c => c.MrpCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.MrpNome).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AlmoxarifadoId).IsRequired();
			builder.Property(c => c.AlmoxarifadoCodigo).HasMaxLength(50).IsRequired();
			builder.Property(c => c.AlmoxarifadoNome).HasMaxLength(50).IsRequired();

			builder.Property(c => c.DescricaoCodigo).HasMaxLength(1023).IsRequired();
		}
	}
}
