using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class CategoriaMaterialRepository : Repository<CategoriaMaterial>, ICategoriaMaterialRepository
	{
		public CategoriaMaterialRepository(GestaoEsdContext context)
			: base(context)
		{			
		}
	}
}