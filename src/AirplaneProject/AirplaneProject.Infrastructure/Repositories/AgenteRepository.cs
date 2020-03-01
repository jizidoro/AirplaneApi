using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class AgenteRepository : Repository<Agente>, IAgenteRepository
	{
        public AgenteRepository(GestaoEsdContext context)
			: base(context)
        {
		}
	}
}