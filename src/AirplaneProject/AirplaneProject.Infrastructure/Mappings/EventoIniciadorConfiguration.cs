using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
	public class EventoIniciadorConfiguration : IEntityTypeConfiguration<EventoIniciador>
	{
		public void Configure(EntityTypeBuilder<EventoIniciador> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasOne(c => c.Iniciador).WithMany(c => c.EventoIniciadores).HasForeignKey(c => c.IniciadorId).OnDelete(DeleteBehavior.Restrict).IsRequired();
			builder.HasOne(c => c.Evento).WithMany(c => c.EventoIniciadores).HasForeignKey(c => c.EventoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
		}
	}
}
