using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class EsdConfiguration : IEntityTypeConfiguration<Esd>
	{
		public void Configure(EntityTypeBuilder<Esd> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.OrigemAgente).WithMany(c => c.Esds).HasForeignKey(c => c.OrigemAgenteId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.EventoIniciador).WithMany(c => c.Esds).HasForeignKey(c => c.EventoIniciadorId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.MotivoCausa).WithMany(c => c.Esds).HasForeignKey(c => c.MotivoCausaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.NivelOperacao).WithMany(c => c.Esds).HasForeignKey(c => c.NivelOperacaoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Uep).WithMany(c => c.Esds).HasForeignKey(c => c.UepId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Situacao).WithMany(c => c.Esds).HasForeignKey(c => c.SituacaoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasMany(c => c.Historicos).WithOne(c => c.Esd).HasForeignKey(c => c.EsdId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasMany(c => c.Arquivos).WithOne(c => c.Esd).HasForeignKey(c => c.EsdId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.Property(c => c.DataEvento).IsRequired();
			builder.Property(c => c.Descricao).HasMaxLength(255);
			builder.Property(c => c.DescricaoCodigo).HasMaxLength(512);

            builder.Property(c => c.NomeUsuario).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ChaveUsuario).HasMaxLength(12).IsRequired();
			builder.Property(c => c.DataRegistro).IsRequired();

            builder.Property(c => c.LinkSitop).HasMaxLength(255);
			builder.Property(c => c.LinkCadinc).HasMaxLength(255);
			builder.Property(c => c.LinkGip).HasMaxLength(255);
			builder.Property(c => c.LinkRta).HasMaxLength(255);
			builder.Property(c => c.Alarme).HasMaxLength(20);
			builder.Property(c => c.AlarmeCodigo).HasMaxLength(20);

			builder.HasIndex(c => c.DescricaoCodigo).HasName("IX_Esds_Codigo");
			builder.HasIndex(c => c.AlarmeCodigo).HasName("IX_Esds_AlarmeCodigo");
		}
	}
}
