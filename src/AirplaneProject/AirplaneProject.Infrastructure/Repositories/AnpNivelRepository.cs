using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class AnpNivelRepository : Repository<AnpNivel>, IAnpNivelRepository
	{
		public AnpNivelRepository(GestaoEsdContext context)
			: base(context)
		{
		}
	}
}