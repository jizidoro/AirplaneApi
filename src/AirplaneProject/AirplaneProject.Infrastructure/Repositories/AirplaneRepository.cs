using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
	{
		public AirplaneRepository(GestaoAirplaneContext context)
			: base(context)
		{
		}
	}
}