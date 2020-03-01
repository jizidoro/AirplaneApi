using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class CausaRepository : Repository<Causa>, ICausaRepository
	{
		public CausaRepository(GestaoEsdContext context)
			: base(context)
		{			
		}
	}
}