using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class OrigemRepository : Repository<Origem>, IOrigemRepository
	{
		public OrigemRepository(GestaoEsdContext context)
			: base(context)
		{
		}
	}
}