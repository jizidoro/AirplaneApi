using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class EventoRepository : Repository<Evento>, IEventoRepository
	{
		public EventoRepository(GestaoEsdContext context)
			: base(context)
		{			
		}
	}
}