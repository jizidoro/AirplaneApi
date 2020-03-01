using System;
using AirplaneProject.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Domain.Models
{
	public class AlteracaoConfiguration : IEntityTypeConfiguration<Alteracao>
	{
		public void Configure(EntityTypeBuilder<Alteracao> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.Aprovador).WithMany().HasForeignKey(c => c.AprovadorId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(c => c.Autorizador).WithMany().HasForeignKey(c => c.AutorizadorId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(c => c.Verificador).WithMany().HasForeignKey(c => c.VerificadorId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(c => c.Executor).WithMany().HasForeignKey(c => c.ExecutorId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Camada).WithMany(c => c.Alteracoes).HasForeignKey(c => c.CamadaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Funcao).WithMany(c => c.Alteracoes).HasForeignKey(c => c.FuncaoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Finalidade).WithMany(c => c.Alteracoes).HasForeignKey(c => c.FinalidadeId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Sistema).WithMany(c => c.Alteracoes).HasForeignKey(c => c.SistemaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Situacao).WithMany(c => c.Alteracoes).HasForeignKey(c => c.SituacaoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Solicitante).WithMany().HasForeignKey(c => c.SolicitanteId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Uep).WithMany().HasForeignKey(c => c.UepId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasMany(c => c.HistoricoAlteracoes).WithOne(c => c.Alteracao).HasForeignKey(c => c.AlteracaoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.Property(c => c.Checksum).HasMaxLength(255);
			builder.Property(c => c.Descricao).HasMaxLength(255);
			builder.Property(c => c.DataEvento).IsRequired();
			builder.Property(c => c.DataRegistro).IsRequired();

			builder.Property(c => c.NomeUsuario).HasMaxLength(100).IsRequired();
			builder.Property(c => c.ChaveUsuario).HasMaxLength(12).IsRequired();
		}
	}
}